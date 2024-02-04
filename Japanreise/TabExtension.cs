namespace Japanreise;

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
}