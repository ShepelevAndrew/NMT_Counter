using NMT_Counter.BLL.BusinessModels;

namespace NMT_Counter.BLL.Services.Interfaces
{
    public interface ICounterService
    {
        double Count(NMTMarks marks, Coefficients coefficient);
    }
}
