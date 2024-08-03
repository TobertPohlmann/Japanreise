namespace Reiseplanung;

public class Schottlandreise
{
    private Reisekalender _reise;
    
    public Schottlandreise()
    {
        _reise = new Reisekalender(new DateOnly(2024,9,19), new DateOnly(2024,10,2));
        _reise.AddUnternehmung("Amsterdam",1,"DFDS-Fähre","Fahrt nach Newcastle ~17:30");
        _reise.AddUnternehmung("Newcastle",1,"DFDS-Fähre", new DateOnly(2024,10,2),"Rückfahrt nach Amsterdam ~17:00");
    }

    public void Write()
    {
        _reise.PrintKalender();
        _reise.WriteToFile("Schottlandreise_2024.txt");
    }
}