using NMT_Counter.BLL.Domain;

namespace NMT_Counter.Models;
public class CounterViewModel
{
    public List<double> Marks { get; set; }
    public List<double> Coefficient { get; set; }
    public List<Subjects> Subjects { get; set; }
}