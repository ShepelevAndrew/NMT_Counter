using NMT_Counter.BLL.Domain;
using NMT_Counter.BLL.Helpers;
using NMT_Counter.BLL.Services.Interfaces;

namespace NMT_Counter.BLL.Services.Implementations;
public class CounterService : ICounterService
{
    public double Count(List<double> nmtMarks, List<double> coefficient, List<Subjects> subjects)
    {
        if(subjects.Count != 0) {
            nmtMarks = CountFromMarksToNMTMarks(nmtMarks, subjects);
        }

        var nmtMark = CountNMTMark(nmtMarks, coefficient);

        return nmtMark;
    }

    public Dictionary<double, double> CountThreeVariants(List<double> nmtMarks, List<List<double>> coefficient, List<Subjects> subjects)
    {
        var finallyNmtMarks = new Dictionary<double, double>();

        if (subjects.Count != 0)
        {
            nmtMarks = CountFromMarksToNMTMarks(nmtMarks, subjects);
        }

        var coefsOfSubjs = new List<double>();
        foreach (var coefList in coefficient) {

            if(coefList.Count == 1)
            {
                coefsOfSubjs.Add(coefList[0]);
            }
            else if (coefList.Count == 3)
            {
                foreach(var coef in coefList) {
                    coefsOfSubjs.Add(coef);

                    finallyNmtMarks.Add(coef, CountNMTMark(nmtMarks, coefsOfSubjs));

                    int lastIndexOfItem = coefsOfSubjs.LastIndexOf(coef);
                    if (lastIndexOfItem != -1)
                    {
                        coefsOfSubjs.RemoveAt(lastIndexOfItem);
                    }
                }
            }
        }

        return finallyNmtMarks;
    }

    public Dictionary<double, double> FindIntersection(List<double> nmtMarks, List<List<double>> coefficient, List<Subjects> subjects)
    {
        if (subjects.Count != 0)
        {
            nmtMarks = CountFromMarksToNMTMarks(nmtMarks, subjects);
        }

        var index = coefficient.FindIndex(c => c.Count > 1);

        var coefOfSubj = new List<double>();
        foreach(var coefList in coefficient) { 
            if(coefList.Count == 1)
            {
                coefOfSubj.Add(coefList[0]);
            }
            else
            {
                coefOfSubj.AddRange(coefficient[index]);
            }
        }

        double sumOfCoef = coefOfSubj[0] + coefOfSubj[1];

        double formulaOfIntersection = Math.Abs(((nmtMarks[0] * coefOfSubj[0] + nmtMarks[1] * coefOfSubj[1]) * ( (sumOfCoef + coefOfSubj[2]) - (sumOfCoef + coefOfSubj[3]) ))
                                     / (coefOfSubj[3] * (sumOfCoef + coefOfSubj[2]) - coefOfSubj[2] * (sumOfCoef + coefOfSubj[3])));

        var resultDict = new Dictionary<double, double>();

        for(int i = 2; i < coefOfSubj.Count; i++)
            resultDict.Add(coefOfSubj[i], formulaOfIntersection);

        return resultDict;

        /*foreach(int nmtMark in nmtMarks) {
            if(nmtMark == 0) {
                    var index = nmtMarks.LastIndexOf(nmtMark);
                    
                for (int i = minNMTMark; i < maxNMTMark; i++)
                {
                    nmtMarks[index] = i;

                    var resultNMTMark = CountThreeVariants(nmtMarks, coefficient, subjects);

                    resultNMTMarks.Add(resultNMTMark);
                }
            }
        }*/
    }

    private double CountNMTMark(List<double> nmtMarks, List<double> coefficient)
    {
        double nmtMark = (coefficient[0] * nmtMarks[0] + coefficient[1] * nmtMarks[1] + coefficient[2] * nmtMarks[2])
                       / (coefficient[0] + coefficient[1] + coefficient[2]);

        return nmtMark;
    }

    private List<double> CountFromMarksToNMTMarks(List<double> nmtMarks, List<Subjects> subjects)
    {
        var jsonLoader = new JsonLoader();

        int i = 0;
        foreach (var subject in subjects)
        {
            var marksDictionary = jsonLoader.LoadInfoFromJson(subject);
            var mark = marksDictionary[nmtMarks[i]];

            nmtMarks[i] = mark;
            i++;
        }

        return nmtMarks;
    }
}