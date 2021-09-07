using API_GroupDetail.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Factories.CompleteSessionFactory
{
    public abstract class CompleteSesssionCalculator
    {
        public abstract bool CompletedSession(List<StudentAnswer> studentAnwsers);
        public abstract int StagesForForwardSuccessfuly();
        public abstract int MaxDifficulty();
    }
}
