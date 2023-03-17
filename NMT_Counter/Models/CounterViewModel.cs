using NMT_Counter.BLL.BusinessModels;

namespace NMT_Counter.Models;
public class CounterViewModel
{
    public NMTMarks Marks { get; set; }
    public Coefficients Coefficient { get; set; }
}