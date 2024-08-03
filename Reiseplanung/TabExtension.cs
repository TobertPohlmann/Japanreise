namespace Reiseplanung;

public static class TabExtension
{
    public static string GetTabs(this string eintrag, int tabCount = 3)
    {
        int characterPerTab = 8;
        tabCount -= eintrag.Length / characterPerTab;
        var result = "";
        for (int i = 0; i < tabCount; i++)
        {
            result += "\t";
        }
        return result;
    }

    public static string WithTabs(this string eintrag, int tabCount = 3)
    {
        return eintrag + eintrag.GetTabs(tabCount);
    }

    public static int TabCount(this string eintrag) 
    {
        int characterPerTab = 8;
        return eintrag.Length / characterPerTab;
    }

}