
public class HauntedHouseRepository
{
    private FloorRepository _hHouseFloorRepo = new FloorRepository();
    private readonly List<HauntedHouse> _hHouseDb = new List<HauntedHouse>();

    private int _count;

    public bool AddHauntedHouse(HauntedHouse hHouse)
    {
        if (hHouse is null)
        {
            return false;
        }
        else
        {
            //increment _count
            _count++;
            hHouse.ID = _count;
            _hHouseDb.Add(hHouse);
            return true;
        }
    }

    public List<HauntedHouse> GetHauntedHouses()
    {
        return _hHouseDb;
    }

    public HauntedHouse GetHauntedHouse()
    {
        // L.I.N.Q

         return _hHouseDb.FirstOrDefault()!;
        // return _hHouseDb.Find(h => h.ID == id)!;
        // return _hHouseDb.First();
        // return _hHouseDb.Single();
        // return _hHouseDb.SingleOrDefault(x=>x.ID ==id);
        // return _hHouseDb.Last();
    }

    public bool HasCompletedGame(List<Floor> rooms)
    {
        if (rooms.Count == 0)
        {
            System.Console.WriteLine("You beat the game!!!!");
            return true;
        }

        return false;
    }

    public void SeedHouseData()
    {
        var hauntedHouse = new HauntedHouse();
        hauntedHouse.FloorsInHouse = _hHouseFloorRepo.GetFloors();
        AddHauntedHouse(hauntedHouse);
    }
}
