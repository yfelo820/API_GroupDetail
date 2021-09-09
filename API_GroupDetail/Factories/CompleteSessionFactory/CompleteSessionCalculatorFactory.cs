using API_GroupDetail.Factories.Config;
using API_GroupDetail.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.Factories.CompleteSessionFactory
{
    public class CompleteSessionCalculatorFactory : ICompleteSessionCalculatorFactory
    {
        public CompleteSesssionCalculator Create(string subject)
        {
            switch (subject)
            {
                case SubjectKey.Emat: return new CompleteSessionEmatCalculator();
                case SubjectKey.EmatCat: return new CompleteSessionEmatCalculator();
                case SubjectKey.EmatMx: return new CompleteSessionEmatCalculator();

                case SubjectKey.EmatInfantil: return new CompleteSessionEmatInfantilCalculator();

                case SubjectKey.Ludi: return new CompleteSessionLudiCalculator();
                case SubjectKey.LudiCat: return new CompleteSessionLudiCalculator();

                case SubjectKey.Superletras: return new CompleteSessionSuperLetrasCalculator();
                case SubjectKey.SuperletrasCat: return new CompleteSessionSuperLetrasCatCalculator();

                default: throw new KeyNotFoundException();
            }
        }
    }
}
