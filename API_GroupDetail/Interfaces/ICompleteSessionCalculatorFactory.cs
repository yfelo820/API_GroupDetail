using API_GroupDetail.Factories.CompleteSessionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Interfaces
{
    public interface ICompleteSessionCalculatorFactory
    {
        CompleteSesssionCalculator Create(string subject);
    }
}
