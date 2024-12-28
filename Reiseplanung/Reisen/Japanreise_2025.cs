namespace Reiseplanung;

public class Japanreise_2025
{
    private Reisekalender _reise;
    
    public Japanreise_2025()
    {
        _reise = new Reisekalender(new DateOnly(2025,4,18), new DateOnly(2025,5,9));

        _reise.AddUnternehmung("Osaka", 2, "APA Hotel Umeda-eki Tower", "Ankunft ~17:00", "Rumbummeln/Jetlag");
        _reise.AddUnternehmung("Koyasan",1,"--");
        _reise.AddUnternehmung("Wakayama", 7, "--", "Kumano Kodo / Wandern");
        
        
        /*
        _reise.AddUnternehmung("Nakatsugawa",1,"Ryokan O","Von Osaka: 4-5h","Ankunft: 18 Uhr");
        _reise.AddUnternehmung("Nakatsugawa",1,"Ryokan O","Magome-Tsumago-Pfad","Museumsdorf");
        _reise.AddUnternehmung("Matsumoto",1, "Mitsubikiya", "Wasabifarm","Burg Matsumoto");
        _reise.AddUnternehmung("Takayama",1,"Wanosato",new DateOnly(2024,4,12));
        _reise.AddUnternehmung("Takayama",4,"Wing International","Frühlingsfest","Shirakawago");
        _reise.AddUnternehmung("Osaka",1,"Hokke Club","Anreise, Übernachtung");
        _reise.AddUnternehmung("Osaka",1,"Hokke Club","Dragon Quest Land");
        _reise.AddUnternehmung("Tanabe",1,"The CUE",new DateOnly(2024,4,19),"Anreise nach Tanabe, Rumpimmeln in Tanabe");
        _reise.AddUnternehmung("Chikatsuyu", 1, "Minshuku WAGO",new DateOnly(2024,4,20), "Kumano-Kodo-Pfad, Takajiri->Chikatsuyu");
        _reise.AddUnternehmung("Hongu", 1, "--", "Kumano-Kodo-Pfad, Chikatsuyu->Hongu");
        _reise.AddUnternehmung("Nachi",1,"--",new DateOnly(2024,4,22),"Bootstour->Hayatama, Hayatama angucken, nach Nachi laufen");
        _reise.AddUnternehmung("Osaka",1,"APA Hotel Umeda-eki Tower",new DateOnly(2024,4,23),"Nachi Taisha angucken, RÜckfahrt nach Osaka");
        _reise.AddUnternehmung("Osaka",1,"--",new DateOnly(2024,4,24),"Rumbummeln","Burg Osaka","Dotonburi","Pokemon Cafe,Rückflug");
    */
    }

    public void Write()
    {
        _reise.PrintKalender();
        _reise.WriteToFile("Japanreise_2024.txt");
    }
}