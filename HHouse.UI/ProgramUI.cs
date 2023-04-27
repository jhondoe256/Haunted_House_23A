using static System.Console;


public class ProgramUI
{
    //Globally Scoped -> thes variables can be used within any method
    private readonly HauntedHouseRepository _hHouseRepo = new HauntedHouseRepository();
    private HauntedHouse _house;
    private int _challengeCounter = 0;
    private bool IsRunning = true;
    private bool _hasMiddleRoomKey;
    private bool _hasPuzzlePiece;
    //------------------------------------------------------

    public ProgramUI()
    {
        SeedData();
        _house = _hHouseRepo.GetHauntedHouse();
    }

    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        Clear();

        while (IsRunning)
        {
            WriteLine("Welcom to the Haunted House, Please make a selection:\n" +
            "1. Start Game\n" +
            "2. End Game\n");

            var userInput = ReadLine();

            switch (userInput)
            {
                case "1":
                    StartGame();
                    break;
                case "2":
                    IsRunning = CloseGame();
                    break;
                default:
                    WriteLine("Invalid Selection");
                    break;
            }
        }
    }

    private bool CloseGame()
    {
        WriteLine("Thanks for Playing");
        PressAnyKeyToContinue();
        Clear();
        return false;
    }

    private void PressAnyKeyToContinue()
    {
        WriteLine("Press any Key to continue!");
        ReadKey();
    }

    private void StartGame()
    {
        Clear();
        while (_house.Player.IsDead == false && IsRunning == true)
        {
            GameUtilities.TellTheStory($"You are a Paranormal Investigator,\nand you have been ordered to enter a haunted house on {_house.Address}\n" +
                                        $"You notice... Press Any Key to Continue...");
            ReadKey();
            while (_hasMiddleRoomKey == false)
            {
                LoadFirstChallenge();
            }

            GameUtilities.TellTheStory("You use the key to open the Middle Room Door!");
            GameUtilities.TellTheStory("You go up the stairs, your on the Next Floor!");

            while (_hasPuzzlePiece == false)
            {
                LoadSecondChallenge();
            }

            LoadFinalChallenge();
            ReadKey();
        }
    }

    private void LoadSecondChallenge()
    {
        Clear();
        var currentChallenge = _house.FloorsInHouse[(int)ChallengesIndex.FirstChallenge].Challenges[++_challengeCounter];

        GameUtilities.TellTheStory("There is a large Puzze in the middle of the Hall.");
        GameUtilities.TellTheStory(currentChallenge.ChallengeDescription);
        GameUtilities.TellTheStory("Which room will you select this time?\n" +
                                 "1. The room down the hall and to the Left?\n" +
                                 "2. The room down the hall and to the Right?\n");
        var userInput = ReadLine();

        switch (userInput)
        {
            case "1":
                LoadTheRoomDownTheHall_ToTheLeft();
                break;
            case "2":
                LoadTheRoomDownTheHall_ToTheRight();
                break;
            default:
                WriteLine("Invalid Selection.");
                break;
        }

    }

    private void LoadTheRoomDownTheHall_ToTheLeft()
    {
        bool hasLeftRoom = false;
        while (!hasLeftRoom)
        {
            Clear();
            GameUtilities.TellTheStory("You entered the Room. Its some sort of Theater of Lost Souls, Lest Investigate\n" +
            "1. Inside the Broken Globe in the middle of the room.\n" +
            "2. A Random Purse on the Floor\n" +
            "3. A Dead Body that was stapled to the wall\n" +
            "4. Leave the Room");

            var userInput = ReadLine();

            switch (userInput)
            {
                case "1":
                    Clear();
                    GameUtilities.TellTheStory("You look inside...NOTHING...");
                    PressAnyKeyToContinue();
                    break;
                case "2":
                    Clear();
                    GameUtilities.TellTheStory("You look inside...Random stuff...");
                    PressAnyKeyToContinue();
                    break;
                case "3":
                    Clear();
                    GameUtilities.TellTheStory("You move it around... Yuck! Its head falls off!");
                    PressAnyKeyToContinue();
                    break;
                case "4":
                    Clear();
                    GameUtilities.TellTheStory("You Exit the Room.");
                    PressAnyKeyToContinue();
                    hasLeftRoom = true;
                    LoadSecondChallenge(); //
                    break;
                default:
                    WriteLine("Invalid Selection.");
                    break;
            }
        }
    }

    private void LoadTheRoomDownTheHall_ToTheRight()
    {
        bool hasLeftRoom = false;
        while (!hasLeftRoom)
        {
            Clear();
            GameUtilities.TellTheStory("You entered the room. Its just a basic room.\nLets Investigate further\n" +
            "1. Inside Random Coffie Cup\n" +
            "2. A shiny box (It looks like a puzzle box)\n" +
            "3. Dead body thats slumped over by the fireplace.\n" +
            "4. Leave the Room");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    Clear();
                    GameUtilities.TellTheStory("You look inside...NOTHING...");
                    PressAnyKeyToContinue();
                    break;
                case "2":
                    Clear();
                    GameUtilities.TellTheStory("You Rub the box... it reconfigures itself...it looks like what we have been looking for!");
                    _hasPuzzlePiece = true;
                    hasLeftRoom = true;
                    PressAnyKeyToContinue();
                    break;
                case "3":
                    Clear();
                    GameUtilities.TellTheStory("You move it around... Yuck! Its head falls off!");
                    PressAnyKeyToContinue();
                    break;
                case "4":
                    Clear();
                    GameUtilities.TellTheStory("You Exit the Room.");
                    PressAnyKeyToContinue();
                    hasLeftRoom = true;
                    LoadSecondChallenge();
                    break;
                default:
                    WriteLine("Invalid Selection.");
                    break;
            }

        }
    }

    private void LoadFinalChallenge()
    {
        Clear();
        ClearChallengeCounter();
        var currentChallenge = _house.FloorsInHouse[(int)ChallengesIndex.SecondChallenge].Challenges[_challengeCounter];

        GameUtilities.TellTheStory("You place the puzzle piece inside of the missing seciton fo the Puzzle\nDARKNESS SURROUNDS YOU\n" +
                                  "A creepy individual with pins in his head approaches, what will you do?\n" +
                                  "1. Shoot the damn Deamon!\n" +
                                  "2. Ask him what he wants\n" +
                                  "3. Try to Escape\n");
        var userInput = ReadLine();

        switch (userInput)
        {
            case "1":
                ShootTheDamnDemon();
                break;
            case "2":
                AskWhatHeWants();
                break;
            case "3":
                TryToEscape();
                break;
            default:
                WriteLine("Invalid Selection, THIS CAN COST YOU YOUR LIFE!");
                break;
        }
    }

    private void ShootTheDamnDemon()
    {
        Clear();
        BossChallenge currentChallenge = (BossChallenge)_house.FloorsInHouse[1].Challenges[0];
        GameUtilities.TellTheStory("You shoot the Damn Demon!");
        _house.Player.ShootPlasmaPistol(currentChallenge.Boss, 50);

        while (currentChallenge.Boss.HealthPoints > 0)
        {
            GameUtilities.TellTheStory("Will you shoot again? y/n");
            var userInput = ReadLine();
            if (userInput != "Y".ToLower())
            {
                Clear();
                GameUtilities.TellTheStory("You ask him what he wants\n" +
                "He replies 'Your Soul'\n" +
                "You try to get away, Fish hooks fly from nowhere and attach to you.\nTHEY RIP YOU APART\n" +
                "The man with pins in his head laughs, HAAAAAAAAAA,HA, HA,A!");
                currentChallenge.Boss.Attack(_house.Player, 1000, "Fish-Hooks of Destruction!");
            }
            else
            {
                _house.Player.ShootPlasmaPistol(currentChallenge.Boss, 20);
            }
        }
        WriteLine("You killed the Demon..or..so you thought...");
        IsRunning = CloseGame();
    }

    private void AskWhatHeWants()
    {
        Clear();
        BossChallenge currentChallenge = (BossChallenge)_house.FloorsInHouse[1].Challenges[0];
        GameUtilities.TellTheStory("You ask him what he wants\n" +
        "He replies 'Your Soul'\n" +
        "You try to get away, Fish hooks fly from nowhere and attach to you.\nTHEY RIP YOU APART\n" +
        "The man with pins in his head laughs, HAAAAAAAAAA,HA, HA,A!");

        currentChallenge.Boss.Attack(_house.Player, 1000, "Fish-Hooks of Destruction!");
        _hasPuzzlePiece = false;
    }

    private void TryToEscape()
    {
        Clear();
        BossChallenge currentChallenge = (BossChallenge)_house.FloorsInHouse[1].Challenges[0];
        GameUtilities.TellTheStory("You ask him what he wants\n" +
        "He replies 'Your Soul'\n" +
        "You try to get away, Fish hooks fly from nowhere and attach to you.\nTHEY RIP YOU APART\n" +
        "The man with pins in his head laughs, HAAAAAAAAAA,HA, HA,A!");

        currentChallenge.Boss.Attack(_house.Player, 1000, "Fish-Hooks of Destruction!");
        _hasPuzzlePiece = false;
    }

    private void ClearChallengeCounter()
    {
        _challengeCounter = 0;
    }

    private void LoadFirstChallenge()
    {
        var currentChallenge = _house.FloorsInHouse[(int)ChallengesIndex.FirstChallenge].Challenges[_challengeCounter];

        GameUtilities.TellTheStory(currentChallenge.ChallengeDescription);

        GameUtilities.TellTheStory("Which Room will your select?\n" +
                                        "1. Room on the Left\n" +
                                        "2. Room on the Right\n");

        var userInput = ReadLine();
        switch (userInput)
        {
            case "1":
                YouChoseTheLeftRoom();
                break;
            case "2":
                YouChoseTheRightRoom();
                break;
            default:
                WriteLine("Invalid Selection.");
                break;
        }
    }

    private void YouChoseTheRightRoom()
    {
        Clear();
        bool hasLeftRoom = false;
        while (!hasLeftRoom)
        {

            GameUtilities.TellTheStory("You entered the Right Room. It's the Kitchen, and its a mess. But lets investigate fruther.\n" +
                "1. In the Refrigerator\n" +
                "2. On Top of the Kitchen Island\n" +
                "3. In the lower Cabinets\n" +
                "4. Leave The Room.");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    Clear();
                    GameUtilities.TellTheStory("You open the door...NOTHING...");
                    PressAnyKeyToContinue();
                    break;
                case "2":
                    Clear();
                    GameUtilities.TellTheStory("You look on top of the kitchen island. It's completely covered with random stuff..");
                    PressAnyKeyToContinue();
                    break;
                case "3":
                    Clear();
                    GameUtilities.TellTheStory("You check the lower cabinets...Again THERES NOTHING...");
                    PressAnyKeyToContinue();
                    break;
                case "4":
                    Clear();
                    GameUtilities.TellTheStory("You Exit the Room.");
                    PressAnyKeyToContinue();
                    hasLeftRoom = true;
                    LoadFirstChallenge();
                    break;
                default:
                    WriteLine("Invalid Selection.");
                    break;
            }
        }

    }

    private void YouChoseTheLeftRoom()
    {
        Clear();
        bool hasLeftRoom = false;

        while (!hasLeftRoom)
        {
            GameUtilities.TellTheStory("You entered the Left Room.\nIts the Living Room, and its a mess\nBut, Lets investigate further.\nWhere do you want to look?\n" +
                "1. On the Couch\n" +
                "2. On the Coffie Table\n" +
                "3. Inside the broken Television\n" +
                "4. Leave The Room.");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    Clear();
                    GameUtilities.TellTheStory("You Check the couch...Nothing...");
                    PressAnyKeyToContinue();
                    break;
                case "2":
                    Clear();
                    GameUtilities.TellTheStory("You check the coffie table...Nothing.\nYou take a seat on the couch and notice that there is something shiny inside the broken Tv screen.");
                    PressAnyKeyToContinue();
                    break;
                case "3":
                    Clear();
                    GameUtilities.TellTheStory("You check inside the broken Tv screen, You found the key to the Middle Room!");
                    _hasMiddleRoomKey = true;
                    hasLeftRoom = true;
                    GameUtilities.TellTheStory("You Exit the Room.");
                    PressAnyKeyToContinue();
                    break;
                case "4":
                    Clear();
                    GameUtilities.TellTheStory("You Exit the Room.");
                    hasLeftRoom = true;
                    break;
                default:
                    WriteLine("Invalid Selection.");
                    break;
            }
        }
        ReadKey();
    }

    private void SeedData()
    {
        _hHouseRepo.SeedHouseData();
    }
}
