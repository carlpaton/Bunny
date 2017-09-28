using Bunny.Repository.Schema;
using System.Collections.Generic;

namespace Bunny.Repository.Interface
{
    public interface IScoreRepository
    {
        int Insert(ScoreModel obj);
        ScoreModel Select(int id);
        List<ScoreModel> SelectList();
    }
}
