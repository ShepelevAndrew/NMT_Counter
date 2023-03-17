using NMT_Counter.BLL.BusinessModels;
using NMT_Counter.BLL.Domain;
using NMT_Counter.BLL.Services.Interfaces;

namespace NMT_Counter.BLL.Services.Implementations;
public class CounterService : ICounterService
{
    public double Count(NMTMarks marks, Coefficients coefficient, List<Subjects>? subjects)
    {
        if(subjects is not null)
        {

        }

        double nmtMark = (coefficient.FirstCoef * marks.FirstSubject + coefficient.SecondCoef * marks.SecondSubject + coefficient.ThirdCoef * marks.ThirdSubject) 
                       / (coefficient.FirstCoef + coefficient.SecondCoef + coefficient.ThirdCoef);

        return nmtMark;
    }
}