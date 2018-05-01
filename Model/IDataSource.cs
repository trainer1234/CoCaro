using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    public interface IDataSource
    {
        ChessBoard CreateNewGame();
        void EndGame(int id, int winner, int duration);
        void StoreMove(int id, string move);
        List<ChessBoard> GetHistory();
        ChessBoard GetGameRecord(int id);
        ChessBoard[] GetAllCoTheGameLevels();
        void SaveCoTheLevel(ChessBoard gameLevel);
        void AddCoTheLevel(ChessBoard gameLevel);
        void DeleteCoTheLevel(int gameLevelId);
    }
}
