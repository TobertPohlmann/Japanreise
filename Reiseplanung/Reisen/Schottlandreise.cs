namespace Reiseplanung;

public class Schottlandreise
{
    private Reisekalender _reise;
    
    public Schottlandreise()
    {
        _reise = new Reisekalender(new DateOnly(2024,9,19), new DateOnly(2024,10,2));
        _reise.AddUnternehmung("Amsterdam",1,"DFDS-Fähre","Fahrt nach Newcastle ~17:30");
        _reise.AddUnternehmung("Edinburgh",1,"","Newcastle - Edinburgh, 2:30h; Edinburgh Castle");
        _reise.AddUnternehmung("Glendronach",1,"","Edinburgh - Glendronach 3h, Glendronach Tour 14:00?");
        _reise.AddUnternehmung("Aviemore",1,"","Glendronach Tour 14:00?, Glendronach - Aviemore ~1.5h");
        _reise.AddUnternehmung("Aviemore",1,"","Dampflok fahren, strathspeyrailway.co.uk");
        _reise.AddUnternehmung("Wolfburn (Thurso)",1,"","Aviemore - Thurso ~3:00h");
        _reise.AddUnternehmung("Talisker (Broadford)",1,"","Thurso - Talisker ~5:00h");
        _reise.AddUnternehmung("Talisker (Broadford)",1,"",new DateOnly(2024,9,26),"Brennerei angucken");
        _reise.AddUnternehmung("Campbeltown",1,"","Talisker - Campbeltown ~5h");
        _reise.AddUnternehmung("Campbeltown",1,"","Springbank angucken");
        _reise.AddUnternehmung("Loch Lomond",1,"Winnock Hotel","Campbeltown - Loch Lomond ~3h");
        _reise.AddUnternehmung("Dumfries",1,"","Loch Lomond - Dumfries ~2h");
        _reise.AddUnternehmung("Newcastle",1,"DFDS-Fähre", new DateOnly(2024,10,2),"Rückfahrt nach Amsterdam ~17:00");
    }

    public void Write()
    {
        _reise.PrintKalender();
        _reise.WriteToFile("Schottlandreise_2024.txt");
    }
}