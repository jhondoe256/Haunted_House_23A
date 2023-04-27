
public class ChallengeRepository
{
    public ChallengeRepository()
    {
        SeedChallenges();
    }
    private BossRepository _hHouseBossRepo = new BossRepository();

    private List<Challenge> _hHouseChallengeDb = new List<Challenge>();
    private int _count = 0;

    public bool AddChallenge(Challenge challenge)
    {
        return (challenge is null) ? false : SaveToDatabase(challenge);
    }

    private bool SaveToDatabase(Challenge challenge)
    {
        AssingId(challenge);
        _hHouseChallengeDb.Add(challenge);
        return true;
    }

    private void AssingId(Challenge challenge)
    {
        _count++;
        challenge.ID = _count;
    }

    public List<Challenge> GetChallenges()
    {
        return _hHouseChallengeDb;
    }

    public Challenge GetChallenge(int challengeID)
    {
        //  return _hHouseChallengeDb.SingleOrDefault(x => x.ID == challengeID)!;

        foreach (var challenge in _hHouseChallengeDb)
        {
            if (challenge.ID == challengeID)
            {
                return challenge;
            }
        }
        return null;
    }

    public void CompletedChallengeTask(int challengeID, string challengeStringValue)
    {
        foreach (Challenge c in _hHouseChallengeDb)
        {
            if (c.ID == challengeID)
            {
                if (c.IsComplete == false)
                {
                    if (c.ChallengeTasks.Remove(challengeStringValue))
                        System.Console.WriteLine($"{challengeStringValue}: Complete!");
                    else
                        System.Console.WriteLine("Challenge not Complete!");
                }
                else
                {
                    System.Console.WriteLine("You have completed this Rooms Challenges!");
                }
            }
        }
    }

    public void SeedChallenges()
    {
        FloorChallenge floor1 = new FloorChallenge
        {
            ID = 1,
            ChallengeDescription =
            "There are Three Rooms.\n" +
            "The Left and the Right ones are unlocked.\n" +
            "Find Middle Room Key\n",
            ChallengeTasks = new List<string>
            {
                "Find Middle Room Key\n"
            }
        };
        FloorChallenge floor2 = new FloorChallenge
        {
            ID = 2,
            ChallengeDescription = "Find the missing Puzzle Piece and Put it back in its place.",
            ChallengeTasks = new List<string>
            {
                "Find Missing Painting Piece\n",
                "Put It Back in its place\n"
            }
        };
        BossChallenge floor3 = new BossChallenge
        {
            ID = 3,
            Boss = _hHouseBossRepo.GetBoss(1),
            ChallengeDescription = "Defeat the Deamon with the Pins in His Head!"
        };

        _hHouseChallengeDb.Add(floor1);
        _hHouseChallengeDb.Add(floor2);
        _hHouseChallengeDb.Add(floor3);
    }
}
