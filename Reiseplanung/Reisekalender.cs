namespace Reiseplanung;

public class Reisekalender
{
    private Dictionary<DateOnly, Unternehmung> _kalender = new();
    private static Dictionary<int, string> _monthsDictionary = new Dictionary<int, string>()
    {
        {1,"Januar"},
        {2,"Februar"},
        {3,"März"},
        {4,"April"},
        {5,"Mai"},
        {6,"Juni"},
        {7,"Juli"},
        {8,"August"},
        {9,"September"},
        {10,"Oktober"},
        {11,"November"},
        {12,"Dezember"}
    };
    
    private static Dictionary<int, string> _weekdayDictionary = new Dictionary<int, string>()
    {
        {0,"Sonntag"},
        {1,"Montag"},
        {2,"Dienstag"},
        {3,"Mittwoch"},
        {4,"Donnerstag"},
        {5,"Freitag"},
        {6,"Samstag"},
    };
    
    private readonly DateOnly _startTag;
    private readonly DateOnly _endTag;
    private List<string> _warnungen = new();
    private DateOnly _neuesterEintrag;

    public Reisekalender(DateOnly startTag, DateOnly endTag)
    {
        //_kalender[startTag] = new Unternehmung("Hamburg", 1, "--","Hinflug");
        //_kalender[endTag.AddDays(1)] = new Unternehmung("Hamburg", 1,"--", "Ankunft");
        _startTag = startTag;
        _neuesterEintrag = startTag;
        _endTag = endTag;
    }

    public void AddUnternehmung(string wo, int wieLange, string hotel, params string[] was)
    {
        AddUnternehmung(wo,wieLange,hotel,GetNächsterFreierTagAb(_neuesterEintrag),was);
    }
    public void AddUnternehmung(string wo, int wieLange, string hotel, DateOnly startTag, params string[] was)
    {
        var unternehmung = new Unternehmung(wo,wieLange,hotel,was);
        bool isValid = Validate(startTag,unternehmung);
        if (isValid)
        {
            _kalender[startTag] = unternehmung;
            _neuesterEintrag = startTag.AddDays(wieLange-1);
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

    private DateOnly GetNächsterFreierTagAb(DateOnly tag)
    {
        while (_kalender.ContainsKey(tag) && tag < _endTag)
        {
            tag = tag.AddDays(_kalender[tag].Dauer);
        }
        return tag;
    }

    private List<string> GeneratePrintVersion()
    {
        var result = new List<string>();
        int maxHotelTabs = GetMaximumTabs((Unternehmung t) => { return t.Hotel.TabCount(); });
        int maxOrtTabs = GetMaximumTabs((Unternehmung t) => { return t.Ort.TabCount(); });

        result.Add("Reiseplanung 2024: ");
        result.Add("------------------------------------");

        DateOnly tag = _startTag;
        while (tag <= _endTag)
        {
            if (_kalender.ContainsKey(tag))
            {
                var eintrag = _kalender[tag];
                result = result.Concat(PrintEintrag(tag, eintrag, maxOrtTabs, maxHotelTabs)).ToList();
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

    private int GetMaximumTabs(Func<Unternehmung,int> getPropertyTabs)
    {
        int maxTabCount = 2;
        foreach(var tag in _kalender)
        {
            maxTabCount = (getPropertyTabs(tag.Value) > maxTabCount) ? getPropertyTabs(tag.Value) : maxTabCount;
        }
        return maxTabCount + 1;
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
        var path = "/mnt/Windows-Daten/Tobi/Programmiersachen/Reiseplanung/";
        using (StreamWriter outputFile = new StreamWriter(Path.Combine(path,filename)))
        {
            foreach (string line in printKalender)
                outputFile.WriteLine(line);
        }   
        Console.WriteLine("Gespeichert als: "+path+"/"+filename);
    }

    private List<string> PrintEintrag(DateOnly startTag, Unternehmung unternehmung, int ortTabs = 3, int hotelTabs = 3)
    {
        string[] unternehmungen = unternehmung.GetString(ortTabs,hotelTabs);
        int counter = 0;
        DateOnly tag;
        var result = new List<string>();
        foreach (var u in unternehmungen)
        {
            tag = startTag.AddDays(counter);
            result.Add(_weekdayDictionary[(int)tag.DayOfWeek].WithTabs(2) + tag.Day + "."+ _monthsDictionary[tag.Month] +"\t" +  u);
            counter++;
        }
        return result;
    }
    
    
}