using API_GroupDetail.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Factories.CompleteSessionFactory
{
    public class CompleteSessionLudiCalculator : CompleteSesssionCalculator
    {
        public override bool CompletedSession(List<StudentAnswer> studentAnwsers)
        {
            if (studentAnwsers.All(b => b.Grade >= 0) && studentAnwsers.Count == Config.Config.StageCountInLudiSession)
                return true;
            return false;
        }

        public override int MaxDifficulty()
        {
            return Config.Config.MaxDifficultyLudi;
        }

        public override int StagesForForwardSuccessfuly()
        {
            return Config.Config.StageCountInLudiSession;
        }
    }
}
