using API_GroupDetail.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Factories.CompleteSessionFactory
{
    public class CompleteSessionEmatCalculator : CompleteSesssionCalculator
    {
        public override bool CompletedSession(List<StudentAnswer> studentAnwsers)
        {
            if (studentAnwsers.All(b => b.Grade >= Config.Config.PassGrade) && studentAnwsers.Count == Config.Config.StageCountInEmatSession)
                return true;
            return false;
        }

        public override int MaxDifficulty()
        {
            return Config.Config.MaxDifficultyEmat;
        }

        public override int StagesForForwardSuccessfuly()
        {
            return Config.Config.StageCountInEmatSession;
        }
    }
}
