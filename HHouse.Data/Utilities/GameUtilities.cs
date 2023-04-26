
public static class GameUtilities
{
    public static List<InGameItem> InitializePlayerStartupItems()
    {
        var textListOfStuff = File.ReadAllLines(
            @"C:\ElevenFiftyProjects\codingFoundations\dotnetProjects\A_HauntedHouse\HHouse.Data\Entities\PlayerEntities\InGameItems.txt");

        List<InGameItem> playerStartingItems = new List<InGameItem>();

        for (int i = 0; i < textListOfStuff.Length; i++)
        {
            if (textListOfStuff[i] == "|")
            {
                var inGameItem = new InGameItem
                {
                    ID = int.Parse(textListOfStuff[++i]),
                    Name = textListOfStuff[++i],
                    TimesCanBeUsed = int.Parse(textListOfStuff[++i])
                };
                playerStartingItems.Add(inGameItem);
            }
        }
        return playerStartingItems;
    }

    public static void FoundPistolCatriage(int roundValue, Player player)
    {
        player.LoadPlasmaPistol(roundValue);
    }

    public static void TellTheStory(string storySection)
    {
        System.Console.WriteLine(storySection);
    }

    public static void DisplayFloorInfo(HauntedHouse _house)
    {
        foreach (var challenge in _house.FloorsInHouse)
        {
            System.Console.WriteLine(challenge);
        }
    }

}
