using CoCaro.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Model
{
    public interface IDataSource
    {
        ChessBoard CreateNewGame(bool isCoThe, int coTheGameId = -1);
        void EndGame(int id, int winner, int duration);
        void StoreMove(int id, string move);
        List<ChessBoard> GetHistory();
        ChessBoard GetGameRecord(int id);
        List<CoTheGameLevel> GetAllCoTheGameLevels();
        void SaveCoTheLevel(CoTheGameLevel gameLevel);
        void AddCoTheLevel(CoTheGameLevel gameLevel);
        void DeleteCoTheLevel(int gameLevelId);
    }
}
