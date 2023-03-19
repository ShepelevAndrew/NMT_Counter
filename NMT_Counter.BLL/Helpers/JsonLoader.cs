using Newtonsoft.Json;
using NMT_Counter.BLL.Domain;

namespace NMT_Counter.BLL.Helpers;
public class JsonLoader
{
    private string _fileName;

    public JsonLoader()
    {

    }

    public Dictionary<double, double> LoadInfoFromJson(Subjects subject)
    {
        //TODO: reduce
        switch (subject)
        {
            case Subjects.Ukrainian:
                _fileName = @"..\NMT_Counter.DAL\DAL_Json\" + Enum.GetName(typeof(Subjects), Subjects.Ukrainian) + ".json";
                break;

            case Subjects.Math:
                _fileName = @"..\NMT_Counter.DAL\DAL_Json\" + Enum.GetName(typeof(Subjects), Subjects.Math) + ".json";
                break;

            case Subjects.History:
                _fileName = @"..\NMT_Counter.DAL\DAL_Json\" + Enum.GetName(typeof(Subjects), Subjects.History) + ".json";
                break;

            case Subjects.English:
                _fileName = @"..\NMT_Counter.DAL\DAL_Json\" + Enum.GetName(typeof(Subjects), Subjects.English) + ".json";
                break;

            case Subjects.Physics:
                _fileName = @"..\NMT_Counter.DAL\DAL_Json\" + Enum.GetName(typeof(Subjects), Subjects.Physics) + ".json";
                break;

            case Subjects.Biology:
                _fileName = @"..\NMT_Counter.DAL\DAL_Json\" + Enum.GetName(typeof(Subjects), Subjects.Biology) + ".json";
                break;

            case Subjects.Chemistry:
                _fileName = @"..\NMT_Counter.DAL\DAL_Json\" + Enum.GetName(typeof(Subjects), Subjects.Chemistry) + ".json";
                break;
        }

        string json = Reader(_fileName);
        var info = JsonConvert.DeserializeObject<Dictionary<double, double>>(json);

        return info;
    }

    private string Reader(string filename)
    {
        string json;
        using (StreamReader r = new StreamReader(filename))
        {
            json = r.ReadToEnd();
        }

        return json;
    }
}
