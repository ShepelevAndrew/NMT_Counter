using NMT_Counter.BLL.BusinessModels;
using NMT_Counter.BLL.Domain;

namespace NMT_Counter.BLL.Services.Interfaces;
public interface ICounterService
{
    double Count(List<double> marks, List<double> coefficient, List<Subjects> subjects);
    Dictionary<double, double> CountThreeVariants(List<double> nmtMarks, List<List<double>> coefficient, List<Subjects> subjects);
    Dictionary<double, double> FindIntersection(List<double> nmtMarks, List<List<double>> coefficient, List<Subjects> subjects);
}
