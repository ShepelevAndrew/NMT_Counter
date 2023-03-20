using NMT_Counter.BLL.Domain;

namespace NMT_Counter.Models;
public class CounterThreeVariantsViewModel
{
    public List<double> Marks { get; set; }
    public List<List<double>> Coefficient { get; set; }
    public List<Subjects> Subjects { get; set; }
}
