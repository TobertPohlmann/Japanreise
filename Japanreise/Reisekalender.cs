namespace Japanreise;

public class Reisekalender
{
    private Dictionary<DateOnly, Unternehmung> _kalender = new();
    private readonly DateOnly _startTag;
    private readonly DateOnly _endTag;
    private List<string> _warnungen = new();

    public Reisekalender(DateOnly startTag, DateOnly endTag)
    {
        _kalender[startTag] = new Unternehmung("Hamburg", 1, "--","Hinflug");
        _kalender[startTag.AddDays(1)] = new Unternehmung("Osaka", 1,"--", "Ankunft ~17:00");
        _kalender[endTag.AddDays(1)] = new Unternehmung("Hamburg", 1,"--", "Ankunft");
        _startTag = startTag;
        _endTag = endTag;
    }

    public void AddUnternehmung(string wo, int wieLange, string hotel, params string[] was)
    {
        AddUnternehmung(wo,wieLange,hotel,GetNaechsterFreierTag(),was);
    }
    public void AddUnternehmung(string wo, int wieLange, string hotel, DateOnly startTag, params string[] was)
    {
        var unternehmung = new Unternehmung(wo,wieLange,hotel,was);
        bool isValid = Validate(startTag,unternehmung);
        if (isValid)
        {
            _kalender[startTag] = unternehmung;
        }
    }

    private bool Validate(DateOnly startTag, Unternehmung unternehmung)
    {
        DateOnly tag;
        for (int i = 0; i < unternehmung.Dauer; i++)
        {
            tag = startTag.AddDays(i);
            if (_kalender.ContainsKey(tag))
            {
                var kollision = _kalender[tag];
                _warnungen.Add("Der Aufenthalt in " + unternehmung.Ort + " kollidiert am " + tag +
                               " mit einer Unternehmung in " + kollision.Ort + ".");
                return false;
            }
        }
        return true;
    }

    private DateOnly GetNaechsterFreierTag()
    {
        var tag = _startTag;
        while (_kalender.ContainsKey(tag) && tag < _endTag)
        {
            tag = tag.AddDays(_kalender[tag].Dauer);
        }
        return tag;
    }

    private List<string> GeneratePrintVersion()
    {
        var result = new List<string>();
        result.Add("Japanreise 2024: ");
        result.Add("------------------------------------");

        DateOnly tag = _startTag;
        while (tag <= _endTag.AddDays(1))
        {
            if (_kalender.ContainsKey(tag))
            {
                var eintrag = _kalender[tag];
                result = result.Concat(PrintEintrag(tag, eintrag)).ToList();
                tag = tag.AddDays(eintrag.Dauer);
            }
            else
            {
                result = result.Concat(PrintEintrag(tag, new Unternehmung("--",1,"--"))).ToList();
                tag = tag.AddDays(1);
            }
        }
        result.Add("-------------------------------------");
        return result;
    }
    
    public void PrintKalender()
    {
        List<string> printKalender = GeneratePrintVersion();

        foreach (var line in printKalender)
        {
            Console.WriteLine(line);
        }
        
        if (_warnungen.Count != 0)
        {
            Console.WriteLine("Warnungen: ");
            foreach (var warnung in _warnungen)
            {
                Console.WriteLine(warnung);
            }
        }
    }

    public void WriteToFile(string filename)
    {
        // Write the string array to a new file named "WriteLines.txt".
        List<string> printKalender = GeneratePrintVersion();
        var path = "/mnt/Windows-Daten/Tobi/Programmiersachen/Japanreise/Japanreise/";
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(path,filename)))
        {
            foreach (string line in printKalender)
                outputFile.WriteLine(line);
        }   
        Console.WriteLine("Gespeichert als: "+path+"/"+filename);
    }

    private List<string> PrintEintrag(DateOnly startTag, Unternehmung unternehmung)
    {
        string[] unternehmungen = unternehmung.GetString();
        int counter = 0;
        DateOnly tag;
        var result = new List<string>();
        foreach (var u in unternehmungen)
        {
            tag = startTag.AddDays(counter);
            result.Add(tag.DayOfWeek + tag.DayOfWeek.ToString().GetTabs(2) + tag.Day + ". April\t" +  u);
            counter++;
        }
        return result;
    }
}