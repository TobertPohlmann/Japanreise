using System.Runtime.InteropServices.JavaScript;
using Microsoft.VisualBasic;

namespace Japanreise;

public class Unternehmung
{
    public string Ort { get; set; }
    public int Dauer { get; set; }
    public string Hotel { get; set; }
    public string[] Unternehmungen  { get; set; }

    public Unternehmung(string wo, int wieLange, string hotel, params string[] was)
    {
        Ort = wo;
        Dauer = wieLange;
        Unternehmungen = was;
        Hotel = hotel;
    }


    public string[] GetString()
    {
        var result = new string[Dauer];
        for (int i = 0; i < Dauer; i++)
        {
            result[i] = Ort + Ort.GetTabs() + Hotel + Hotel.GetTabs();
        }

        result[0] += SerializeUnternehmungen();
        return result;
    }

    public string SerializeUnternehmungen()
    {
        if (Unternehmungen.Length == 0)
        {
            return "";
        }
        
        string result = "";
        foreach (var unternehmung in Unternehmungen)
        {
            result += unternehmung + ", ";
        }

        return result.Substring(0,result.Length -2);
    }
}