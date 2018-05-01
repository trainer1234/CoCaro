using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoCaro.Model;
using CoCaro.View.PlayWithCom;

namespace CoCaro.Presenter.PlayWIthCom
{
    public class PlayWithComPresenter : IPlayWithComPresenter
    {
        private IPlayWithComView view;
        private IDataSource dataSource;

        private ChessBoard _ChessBoard;
        private Chess LastMove;

        public PlayWithComPresenter(IPlayWithComView view, IDataSource dataSource)
        {
            this.view = view;
            this.view.Presenter = this;
            this.dataSource = dataSource;
        }

        public int CheckGame(ChessBoard chessBoard, int row, int column)
        {
            this._ChessBoard = chessBoard;
            this.LastMove = chessBoard.Chesses[row, column];

            if (chessBoard.Moves.Count== ChessBoard.BoardRows * ChessBoard.BoardColumns)
            {
                return 0;
            }
            if (CheckHorizontal() || CheckVertical() ||
                CheckInclined() || CheckReverseInclined())
            {
                return 1;
            }
            return -1;
        }

        public bool CheckHorizontal()
        {
            int count = 1;
            for (int i = 1; count < 5; i++, count++)
            {
                if (LastMove.Column + i > ChessBoard.BoardColumns)
                {
                    break;
                }
                Chess chess = _ChessBoard.Chesses[LastMove.Row, LastMove.Column + i];
                if (chess.Owner != LastMove.Owner)
                {
                    break;
                }
            }
            if (count == 5)
            {
                return true;
            }
            else
            {
                for (int i = 1; count < 5; i++, count++)
                {
                    if (LastMove.Column - i < 1)
                    {
                        break;
                    }
                    Chess chess = _ChessBoard.Chesses[LastMove.Row, LastMove.Column - i];
                    if (chess.Owner != LastMove.Owner)
                    {
                        break;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CheckInclined()
        {
            int count = 1;
            for (int i = 1; count < 5; i++, count++)
            {
                if (LastMove.Column + i > ChessBoard.BoardColumns ||
                    LastMove.Row + i > ChessBoard.BoardRows)
                {
                    break;
                }
                Chess chess = _ChessBoard.Chesses[LastMove.Row + i, LastMove.Column + i];
                if (chess.Owner != LastMove.Owner)
                {
                    break;
                }
            }
            if (count == 5)
            {
                return true;
            }
            else
            {
                for (int i = 1; count < 5; i++, count++)
                {
                    if (LastMove.Column - i < 1 ||
                        LastMove.Row - i < 1)
                    {
                        break;
                    }
                    Chess chess = _ChessBoard.Chesses[LastMove.Row - i, LastMove.Column - i];
                    if (chess.Owner != LastMove.Owner)
                    {
                        break;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CheckReverseInclined()
        {
            int count = 1;
            for (int i = 1; count < 5; i++, count++)
            {
                if (LastMove.Column - i < 1 ||
                    LastMove.Row + i > ChessBoard.BoardRows)
                {
                    break;
                }
                Chess chess = _ChessBoard.Chesses[LastMove.Row + i, LastMove.Column - i];
                if (chess.Owner != LastMove.Owner)
                {
                    break;
                }
            }
            if (count == 5)
            {
                return true;
            }
            else
            {
                for (int i = 1; count < 5; i++, count++)
                {
                    if (LastMove.Column + i > ChessBoard.BoardColumns ||
                        LastMove.Row - i < 1)
                    {
                        break;
                    }
                    Chess chess = _ChessBoard.Chesses[LastMove.Row - i, LastMove.Column + i];
                    if (chess.Owner != LastMove.Owner)
                    {
                        break;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool CheckVertical()
        {
            int count = 1;
            for (int i = 1; count < 5; i++, count++)
            {
                if (LastMove.Row + i > ChessBoard.BoardRows)
                {
                    break;
                }
                Chess chess = _ChessBoard.Chesses[LastMove.Row + i, LastMove.Column];
                if (chess.Owner != LastMove.Owner)
                {
                    break;
                }
            }
            if (count == 5)
            {
                return true;
            }
            else
            {
                for (int i = 1; count < 5; i++, count++)
                {
                    if (LastMove.Row - i < 1)
                    {
                        break;
                    }
                    Chess chess = _ChessBoard.Chesses[LastMove.Row - i, LastMove.Column];
                    if (chess.Owner != LastMove.Owner)
                    {
                        break;
                    }
                }
                if (count == 5)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ChessBoard CreateNewGame()
        {
            _ChessBoard = dataSource.CreateNewGame();
            return _ChessBoard;
        }

        public void EndGame(int id, int winner, int duration)
        {
            dataSource.EndGame(id, winner, duration);
        }

        public void StoreMove(int id, int row, int column)
        {
            _ChessBoard.Chesses[row, column].Owner = _ChessBoard.TurnOwner;
            string move = "";
            move += ((char)(column - 1 + 'A')).ToString();
            move += (row).ToString();
            //MessageBox.Show(move);
            _ChessBoard.Moves.Add(move);
            dataSource.StoreMove(id, move);
        }

        #region TTNT-AI(Artificial Intelligence)
        private long[] _MD_TC = new long[6] { 0, 64, 4096, 262144, 16777216, 1073741824 }; //Điểm tấn công
        private long[] _MD_PT = new long[6] { 0, 8, 512, 32768, 2097152, 134217728 }; // Điểm phòng thủ
        public void ComputerMove(ChessBoard chessBoard)
        {
            this._ChessBoard = chessBoard;
            if (_ChessBoard.Moves.Count == 0)
            {
                view.ComSetChess(ChessBoard.BoardRows / 2, ChessBoard.BoardColumns / 2);
            }
            else
            {
                KeyValuePair<int, int> location = Tim_Kiem_Nuoc_Di();
                view.ComSetChess(location.Key, location.Value);                                
            }

        }
        private KeyValuePair<int, int> Tim_Kiem_Nuoc_Di()
        {
            KeyValuePair<int, int> result = new KeyValuePair<int, int>();
            long _Diem_Max = 0;
            for (int i = 1; i <= ChessBoard.BoardRows; i++)
            {
                for (int j = 1; j <= ChessBoard.BoardColumns; j++)
                {
                    if (_ChessBoard.Chesses[i, j].Owner == 0)
                    {
                        long _Diem_TC = DTC_DuyetDoc(i, j) + DTC_DuyetNgang(i, j) + DTC_DuyetCheoXuoi(i, j) + DTC_DuyetCheoNguoc(i, j);
                        long _Diem_PT = DPT_DuyetNgang(i, j) + DPT_DuyetDoc(i, j) + DPT_DuyetCheoXuoi(i, j) + DPT_DuyetCheoNguoc(i, j);
                        long _Diem_Tam_Thoi = _Diem_TC > _Diem_PT ? _Diem_TC : _Diem_PT;
                        long _Diem_Tong = (_Diem_PT + _Diem_TC) > _Diem_Tam_Thoi ? (_Diem_PT + _Diem_TC) : _Diem_Tam_Thoi;
                        if (_Diem_Max < _Diem_Tong)
                        {
                            _Diem_Max = _Diem_Tong;
                            result = new KeyValuePair<int, int>(i, j);
                            //_ocoResult = new O_Co(_Mang_O_Co[i, j].Row, _Mang_O_Co[i, j].Column, _Mang_O_Co[i, j].Location, _Mang_O_Co[i, j].Own);
                        }
                    }
                }
            }
            return result;
        }
        // Duyệt điểm tấn công
        #region DuyetDiemTanCong
        private long DTC_DuyetDoc(int crRow, int crColumn)
        {
            long _Diem_Tong = 0;
            int _SoQT = 0;
            int _SoQD = 0;
            int _SoQT2 = 0;
            int _SoQD2 = 0;            
            for (int dem = 1; dem < 5 && crRow + dem <= ChessBoard.BoardRows; dem++)
            {                
                if (_ChessBoard.Chesses[crRow + dem, crColumn].Owner == 1)
                {
                    _SoQT++;
                }
                else if (_ChessBoard.Chesses[crRow + dem, crColumn].Owner == 2)
                {
                    _SoQD++;
                    break;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crRow + dem2 <= ChessBoard.BoardRows; dem2++)
                        if (_ChessBoard.Chesses[crRow + dem2, crColumn].Owner == 1)
                        {
                            _SoQT2++;
                        }
                        else if (_ChessBoard.Chesses[crRow + dem2, crColumn].Owner == 2)
                        {
                            _SoQD2++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int dem = 1; dem < 5 && crRow - dem >= 1; dem++)
            {
                if (_ChessBoard.Chesses[crRow - dem, crColumn].Owner == 1)
                {
                    _SoQT++;
                }
                else if (_ChessBoard.Chesses[crRow - dem, crColumn].Owner == 2)
                {
                    _SoQD++;
                    break;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crRow - dem2 >= 1; dem2++)
                        if (_ChessBoard.Chesses[crRow - dem2, crColumn].Owner == 1)
                        {
                            _SoQT2++;
                        }
                        else if (_ChessBoard.Chesses[crRow - dem2, crColumn].Owner == 2)
                        {
                            _SoQD2++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            if (_SoQD == 2)
                return 0;
            if (_SoQD == 0)
                _Diem_Tong += _MD_TC[_SoQT] * 2;
            else
                _Diem_Tong += _MD_TC[_SoQT];
            if (_SoQD2 == 0)
                _Diem_Tong += _MD_TC[_SoQT2] * 2;
            else
                _Diem_Tong += _MD_TC[_SoQT2];
            if (_SoQT >= _SoQT2)
                _Diem_Tong -= 1;
            else
                _Diem_Tong -= 2;
            if (_SoQT == 4)
                _Diem_Tong *= 2;
            if (_SoQT == 0)
                _Diem_Tong += _MD_PT[_SoQD] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD];
            if (_SoQT2 == 0)
                _Diem_Tong += _MD_PT[_SoQD2] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD2];
            return _Diem_Tong;
        }
        private long DTC_DuyetNgang(int crRow, int crColumn)
        {
            long _Diem_Tong = 0;
            int _SoQT = 0;
            int _SoQD = 0;
            int _SoQT2 = 0;
            int _SoQD2 = 0;            
            for (int dem = 1; dem < 5 && crColumn + dem <= ChessBoard.BoardColumns; dem++)
            {
                if (_ChessBoard.Chesses[crRow, crColumn + dem].Owner == 1)
                {
                    _SoQT++;
                }
                else if (_ChessBoard.Chesses[crRow, crColumn + dem].Owner == 2)
                {
                    _SoQD++;
                    break;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crColumn + dem2 <= ChessBoard.BoardColumns; dem2++)
                        if (_ChessBoard.Chesses[crRow, crColumn + dem2].Owner == 1)
                        {
                            _SoQT2++;
                        }
                        else if (_ChessBoard.Chesses[crRow, crColumn + dem2].Owner == 2)
                        {
                            _SoQD2++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int dem = 1; dem < 5 && crColumn - dem >= 1; dem++)
            {
                if (_ChessBoard.Chesses[crRow, crColumn - dem].Owner == 1)
                {
                    _SoQT++;
                }
                else if (_ChessBoard.Chesses[crRow, crColumn - dem].Owner == 2)
                {
                    _SoQD++;
                    break;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crColumn - dem2 >= 1; dem2++)
                        if (_ChessBoard.Chesses[crRow, crColumn - dem2].Owner == 1)
                        {
                            _SoQT2++;
                        }
                        else if (_ChessBoard.Chesses[crRow, crColumn - dem2].Owner == 2)
                        {
                            _SoQD2++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            if (_SoQD == 2)
                return 0;
            if (_SoQD == 0)
                _Diem_Tong += _MD_TC[_SoQT] * 2;
            else
                _Diem_Tong += _MD_TC[_SoQT];
            if (_SoQD2 == 0)
                _Diem_Tong += _MD_TC[_SoQT2] * 2;
            else
                _Diem_Tong += _MD_TC[_SoQT2];
            if (_SoQT >= _SoQT2)
                _Diem_Tong -= 1;
            else
                _Diem_Tong -= 2;
            if (_SoQT == 4)
                _Diem_Tong *= 2;
            if (_SoQT == 0)
                _Diem_Tong += _MD_PT[_SoQD] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD];
            if (_SoQT2 == 0)
                _Diem_Tong += _MD_PT[_SoQD2] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD2];
            return _Diem_Tong;
        }
        private long DTC_DuyetCheoXuoi(int crRow, int crColumn)
        {
            long _Diem_Tong = 0;
            int _SoQT = 0;
            int _SoQD = 0;
            int _SoQT2 = 0;
            int _SoQD2 = 0;                        
            for (int dem = 1; dem < 5 && crColumn + dem <= ChessBoard.BoardColumns 
                && crRow + dem <= ChessBoard.BoardRows; dem++)
            {
                if (_ChessBoard.Chesses[crRow + dem, crColumn + dem].Owner == 1)
                {
                    _SoQT++;
                }
                else if (_ChessBoard.Chesses[crRow + dem, crColumn + dem].Owner == 2)
                {
                    _SoQD++;
                    break;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crColumn + dem2 <= ChessBoard.BoardColumns 
                        && crRow + dem2 <= ChessBoard.BoardRows; dem2++)
                        if (_ChessBoard.Chesses[crRow + dem2, crColumn + dem2].Owner == 1)
                        {
                            _SoQT2++;
                        }
                        else if (_ChessBoard.Chesses[crRow + dem2, crColumn + dem2].Owner == 2)
                        {
                            _SoQD2++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int dem = 1; dem < 5 && crColumn - dem >= 1 && crRow - dem >= 1; dem++)
            {
                if (_ChessBoard.Chesses[crRow - dem, crColumn - dem].Owner == 1)
                {
                    _SoQT++;
                }
                else if (_ChessBoard.Chesses[crRow - dem, crColumn - dem].Owner == 2)
                {
                    _SoQD++;
                    break;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crColumn - dem2 >= 1 && crRow - dem2 >= 1; dem2++)
                        if (_ChessBoard.Chesses[crRow - dem2, crColumn - dem2].Owner == 1)
                        {
                            _SoQT2++;
                        }
                        else if (_ChessBoard.Chesses[crRow - dem2, crColumn - dem2].Owner == 2)
                        {
                            _SoQD2++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            if (_SoQD == 2)
                return 0;
            if (_SoQD == 0)
                _Diem_Tong += _MD_TC[_SoQT] * 2;
            else
                _Diem_Tong += _MD_TC[_SoQT];
            if (_SoQD2 == 0)
                _Diem_Tong += _MD_TC[_SoQT2] * 2;
            else
                _Diem_Tong += _MD_TC[_SoQT2];
            if (_SoQT >= _SoQT2)
                _Diem_Tong -= 1;
            else
                _Diem_Tong -= 2;

            if (_SoQT == 4)
                _Diem_Tong *= 2;
            if (_SoQT == 0)
                _Diem_Tong += _MD_PT[_SoQD] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD];
            if (_SoQT2 == 0)
                _Diem_Tong += _MD_PT[_SoQD2] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD2];
            return _Diem_Tong;
        }
        private long DTC_DuyetCheoNguoc(int crRow, int crColumn)
        {
            long _Diem_Tong = 0;
            int _SoQT = 0;
            int _SoQD = 0;
            int _SoQT2 = 0;
            int _SoQD2 = 0;            
            for (int dem = 1; dem < 5 && crColumn + dem <= ChessBoard.BoardColumns 
                && crRow - dem > 1; dem++)
            {
                if (_ChessBoard.Chesses[crRow - dem, crColumn + dem].Owner == 1)
                {
                    _SoQT++;
                }
                else if (_ChessBoard.Chesses[crRow - dem, crColumn + dem].Owner == 2)
                {
                    _SoQD++;
                    break;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crColumn + dem2 <= ChessBoard.BoardColumns
                        && crRow - dem2 > 1; dem2++)
                        if (_ChessBoard.Chesses[crRow - dem2, crColumn + dem2].Owner == 1)
                        {
                            _SoQT2++;
                        }
                        else if (_ChessBoard.Chesses[crRow - dem2, crColumn + dem2].Owner == 2)
                        {
                            _SoQD2++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int dem = 1; dem < 5 && crColumn - dem >= 1 
                && crRow + dem <= ChessBoard.BoardRows; dem++)
            {
                if (_ChessBoard.Chesses[crRow + dem, crColumn - dem].Owner == 1)
                {
                    _SoQT++;
                }
                else if (_ChessBoard.Chesses[crRow + dem, crColumn - dem].Owner == 2)
                {
                    _SoQD++;
                    break;
                }
                else // Own = 0
                {
                    for (int dem2 = 1; dem2 < 6 && crColumn - dem2 >= 1 && 
                        crRow + dem2 <= ChessBoard.BoardRows; dem2++)
                        if (_ChessBoard.Chesses[crRow + dem2, crColumn - dem2].Owner == 1)
                        {
                            _SoQT2++;
                        }
                        else if (_ChessBoard.Chesses[crRow + dem2, crColumn - dem2].Owner == 2)
                        {
                            _SoQD2++;
                            break;
                        }
                        else
                            break;
                    break;
                }
            }
            if (_SoQD == 2)
                return 0;
            if (_SoQD == 0)
                _Diem_Tong += _MD_TC[_SoQT] * 2;
            else
                _Diem_Tong += _MD_TC[_SoQT];
            if (_SoQD2 == 0)
                _Diem_Tong += _MD_TC[_SoQT2] * 2;
            else
                _Diem_Tong += _MD_TC[_SoQT2];
            if (_SoQT >= _SoQT2)
                _Diem_Tong -= 1;
            else
                _Diem_Tong -= 2;
            if (_SoQT == 4)
                _Diem_Tong *= 2;
            if (_SoQT == 0)
                _Diem_Tong += _MD_PT[_SoQD] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD];
            if (_SoQT2 == 0)
                _Diem_Tong += _MD_PT[_SoQD2] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD2];
            return _Diem_Tong;
        }
        #endregion
        // Duyệt điểm phòng thủ
        #region DuyetDiemPhongThu
        private long DPT_DuyetDoc(int crRow, int crColumn)
        {
            long _Diem_Tong = 0;
            int _SoQT = 0;
            int _SoQD = 0;
            int _SoQT2 = 0;
            int _SoQD2 = 0;
            for (int dem = 1; dem < 5 && crRow + dem <= ChessBoard.BoardRows; dem++)
            {
                if (_ChessBoard.Chesses[crRow + dem, crColumn].Owner == 1)
                {
                    _SoQT++;
                    break;
                }
                else if (_ChessBoard.Chesses[crRow + dem, crColumn].Owner == 2)
                {
                    _SoQD++;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crRow + dem2 <= ChessBoard.BoardRows; dem2++)
                        if (_ChessBoard.Chesses[crRow + dem, crColumn].Owner == 1)
                        {
                            _SoQT2++;
                            break;
                        }
                        else if (_ChessBoard.Chesses[crRow + dem, crColumn].Owner == 2)
                        {
                            _SoQD2++;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int dem = 1; dem < 5 && crRow - dem >= 1; dem++)
            {
                if (_ChessBoard.Chesses[crRow - dem, crColumn].Owner == 1)
                {
                    _SoQT++;
                    break;
                }
                else if (_ChessBoard.Chesses[crRow - dem, crColumn].Owner == 2)
                {
                    _SoQD++;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crRow - dem2 >= 1; dem2++)
                        if (_ChessBoard.Chesses[crRow - dem2, crColumn].Owner == 1)
                        {
                            _SoQT2++;
                            break;
                        }
                        else if (_ChessBoard.Chesses[crRow - dem2, crColumn].Owner == 2)
                        {
                            _SoQD2++;
                        }
                        else
                            break;
                    break;
                }
            }
            if (_SoQT == 2)
                return 0;
            if (_SoQT == 0)
                _Diem_Tong += _MD_PT[_SoQD] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD];
            /* 
            if (_SoQT2 == 0)
                _Diem_Tong += _MD_PT[_SoQD2] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD2];
            */
            if (_SoQD >= _SoQD2)
                _Diem_Tong -= 1;
            else
                _Diem_Tong -= 2;
            if (_SoQD == 4)
                _Diem_Tong *= 2;
            return _Diem_Tong;
        }
        private long DPT_DuyetNgang(int crRow, int crColumn)
        {
            long _Diem_Tong = 0;
            int _SoQT = 0;
            int _SoQD = 0;
            int _SoQT2 = 0;
            int _SoQD2 = 0;
            for (int dem = 1; dem < 5 && crColumn + dem <= ChessBoard.BoardColumns; dem++)
            {
                if (_ChessBoard.Chesses[crRow, crColumn + dem].Owner == 1)
                {
                    _SoQT++;
                    break;
                }
                else if (_ChessBoard.Chesses[crRow, crColumn + dem].Owner == 2)
                {
                    _SoQD++;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crColumn + dem2 <= ChessBoard.BoardColumns; dem2++)
                        if (_ChessBoard.Chesses[crRow, crColumn + dem2].Owner == 1)
                        {
                            _SoQT2++;
                            break;
                        }
                        else if (_ChessBoard.Chesses[crRow, crColumn + dem2].Owner == 2)
                        {
                            _SoQD2++;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int dem = 1; dem < 5 && crColumn - dem >= 1; dem++)
            {
                if (_ChessBoard.Chesses[crRow, crColumn - dem].Owner == 1)
                {
                    _SoQT++;
                    break;
                }
                else if (_ChessBoard.Chesses[crRow, crColumn - dem].Owner == 2)
                {
                    _SoQD++;
                }
                else // Own = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crColumn - dem2 >= 1; dem2++)
                        if (_ChessBoard.Chesses[crRow, crColumn - dem2].Owner == 1)
                        {
                            _SoQT2++;
                            break;
                        }
                        else if (_ChessBoard.Chesses[crRow, crColumn - dem2].Owner == 2)
                        {
                            _SoQD2++;
                        }
                        else break;
                    break;
                }
            }
            if (_SoQT == 2)
                return 0;
            if (_SoQT == 0)
                _Diem_Tong += _MD_PT[_SoQD] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD];
            /* 
            if (_SoQT2 == 0)
                _Diem_Tong += _MD_PT[_SoQD2] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD2];
            */
            if (_SoQD >= _SoQD2)
                _Diem_Tong -= 1;
            else
                _Diem_Tong -= 2;
            if (_SoQD == 4)
                _Diem_Tong *= 2;
            return _Diem_Tong;
        }
        private long DPT_DuyetCheoXuoi(int crRow, int crColumn)
        {
            long _Diem_Tong = 0;
            int _SoQT = 0;
            int _SoQD = 0;
            int _SoQT2 = 0;
            int _SoQD2 = 0;
            for (int dem = 1; dem < 5 && crColumn + dem <= ChessBoard.BoardColumns 
                && crRow + dem <= ChessBoard.BoardRows; dem++)
            {
                if (_ChessBoard.Chesses[crRow + dem, crColumn + dem].Owner == 1)
                {
                    _SoQT++;
                    break;
                }
                else if (_ChessBoard.Chesses[crRow + dem, crColumn + dem].Owner == 2)
                {
                    _SoQD++;
                }
                else // Owner = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crRow + dem2 <= ChessBoard.BoardRows 
                        && crColumn + dem2 <= ChessBoard.BoardColumns; dem2++)
                        if (_ChessBoard.Chesses[crRow + dem2, crColumn + dem2].Owner == 1)
                        {
                            _SoQT2++;
                            break;
                        }
                        else if (_ChessBoard.Chesses[crRow + dem2, crColumn + dem2].Owner == 2)
                        {
                            _SoQD2++;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int dem = 1; dem < 5 && crColumn - dem >= 1 
                && crRow - dem >= 1; dem++)
            {
                if (_ChessBoard.Chesses[crRow - dem, crColumn - dem].Owner == 1)
                {
                    _SoQT++;
                    break;
                }
                else if (_ChessBoard.Chesses[crRow - dem, crColumn - dem].Owner == 2)
                {
                    _SoQD++;
                }
                else // Owner = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crColumn - dem2 >= 1 
                        && crRow - dem2 >= 1; dem2++)
                        if (_ChessBoard.Chesses[crRow - dem2, crColumn - dem2].Owner == 1)
                        {
                            _SoQT2++;
                            break;
                        }
                        else if (_ChessBoard.Chesses[crRow - dem2, crColumn - dem2].Owner == 2)
                        {
                            _SoQD2++;
                        }
                        else
                            break;
                    break;
                }
            }
            if (_SoQT == 2)
                return 0;
            if (_SoQT == 0)
                _Diem_Tong += _MD_PT[_SoQD] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD];
            /* 
            if (_SoQT2 == 0)
                _Diem_Tong += _MD_PT[_SoQD2] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD2];
            */
            if (_SoQD >= _SoQD2)
                _Diem_Tong -= 1;
            else
                _Diem_Tong -= 2;
            if (_SoQD == 4)
                _Diem_Tong *= 2;
            return _Diem_Tong;
        }
        private long DPT_DuyetCheoNguoc(int crRow, int crColumn)
        {
            long _Diem_Tong = 0;
            int _SoQT = 0;
            int _SoQD = 0;
            int _SoQT2 = 0;
            int _SoQD2 = 0;
            for (int dem = 1; dem < 5 && crColumn + dem <= ChessBoard.BoardColumns 
                && crRow - dem > 1; dem++)
            {
                if (_ChessBoard.Chesses[crRow - dem, crColumn + dem].Owner == 1)
                {
                    _SoQT++;
                    break;
                }
                else if (_ChessBoard.Chesses[crRow - dem, crColumn + dem].Owner == 2)
                {
                    _SoQD++;
                }
                else // Owner = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crRow - dem2 >= 1 
                        && crColumn + dem2 <= ChessBoard.BoardColumns; dem2++)
                        if (_ChessBoard.Chesses[crRow - dem2, crColumn + dem2].Owner == 1)
                        {
                            _SoQT2++;
                            break;
                        }
                        else if (_ChessBoard.Chesses[crRow - dem2, crColumn + dem2].Owner == 2)
                        {
                            _SoQD2++;
                        }
                        else
                            break;
                    break;
                }
            }
            for (int dem = 1; dem < 5 && crColumn - dem >= 1 
                && crRow + dem <= ChessBoard.BoardRows; dem++)
            {
                if (_ChessBoard.Chesses[crRow + dem, crColumn - dem].Owner == 1)
                {
                    _SoQT++;
                    break;
                }
                else if (_ChessBoard.Chesses[crRow + dem, crColumn - dem].Owner == 2)
                {
                    _SoQD++;
                }
                else // Owner = 0
                {
                    for (int dem2 = 2; dem2 < 6 && crRow + dem2 <= ChessBoard.BoardRows 
                        && crColumn - dem2 >= 1; dem2++)
                        if (_ChessBoard.Chesses[crRow + dem2, crColumn - dem2].Owner == 1)
                        {
                            _SoQT2++;
                            break;
                        }
                        else if (_ChessBoard.Chesses[crRow + dem2, crColumn - dem2].Owner == 2)
                        {
                            _SoQD2++;
                        }
                        else
                            break;
                    break;
                }
            }
            if (_SoQT == 2)
                return 0;
            if (_SoQT == 0)
                _Diem_Tong += _MD_PT[_SoQD] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD];
            /* 
            if (_SoQT2 == 0)
                _Diem_Tong += _MD_PT[_SoQD2] * 2;
            else
                _Diem_Tong += _MD_PT[_SoQD2];
            */
            if (_SoQD >= _SoQD2)
                _Diem_Tong -= 1;
            else
                _Diem_Tong -= 2;
            if (_SoQD == 4)
                _Diem_Tong *= 2;
            return _Diem_Tong;
        }
        #endregion
        #endregion
    }
}
