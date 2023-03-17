using NMT_Counter.BLL.BusinessModels;
using NMT_Counter.BLL.Domain;

namespace NMT_Counter.BLL.Services.Interfaces
{
    public interface ICounterService
    {
        double Count(NMTMarks marks, Coefficients coefficient, List<Subjects> subjects = null);
    }
}
