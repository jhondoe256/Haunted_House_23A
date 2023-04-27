
public class FloorRepository
{

    public FloorRepository()
    {
        SeedFloors();
    }

    private readonly ChallengeRepository _challengeRepo = new ChallengeRepository();
    private List<Floor> _hHouseFloorDb = new List<Floor>();

    private int _count = 0;

    public bool AddFloor(Floor floor)
    {
        return (floor is null) ? false : SaveToDatabase(floor);
    }

    private bool SaveToDatabase(Floor floor)
    {
        AssignId(floor);
        _hHouseFloorDb.Add(floor);
        return true;
    }

    private void AssignId(Floor floor)
    {
        _count++;
        floor.ID = _count;
    }

    public List<Floor> GetFloors()
    {
        return _hHouseFloorDb;
    }

    public Floor GetFloorByID(int id)
    {
        // foreach (var floor in _hHouseFloorDb)
        // {
        //     if (floor.ID == id)
        //     {
        //         return floor;
        //     }
        // }
        // return null;

        return _hHouseFloorDb.SingleOrDefault(f => f.ID == id)!;
    }

    public bool CompletedFloor(Floor floor)
    {
        foreach (Challenge c in floor.Challenges)
        {
            if (c.IsComplete)
                return true;
        }
        return false;
    }

    public void SeedFloors()
    {
        var floor = new Floor
        {
            ID = 1,
            Name = "Main Floor",
            Challenges = _challengeRepo.GetChallenges().Where(c => c.GetType() == typeof(FloorChallenge)).ToList()
        };

        var floor2 = new Floor
        {
            ID = 2,
            Name = "Second Floor",
            Challenges = _challengeRepo.GetChallenges().Where(c => c.GetType() == typeof(BossChallenge)).ToList()
        };

        _hHouseFloorDb.Add(floor);
        _hHouseFloorDb.Add(floor2);
    }
}
