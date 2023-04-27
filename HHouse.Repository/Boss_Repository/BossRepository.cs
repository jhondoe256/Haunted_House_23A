public class BossRepository
{
    public BossRepository()
    {
        SeedBossData();
    }
    private List<Boss> _hHouseBossDb = new List<Boss>();

    //we will auto increment the ID value, no-long working with a string (at the moment)
    private int _count = 0;

    //C.R.U.D

    //TODO: Create Method (C)
    public bool AddBoss(Boss boss)
    {
        return (boss is null) ? false : SaveToDatabase(boss);
    }

    private bool SaveToDatabase(Boss boss)
    {
        AssignId(boss);

        _hHouseBossDb.Add(boss);

        return true;
    }
    private void AssignId(Boss boss)
    {
        _count++;
        boss.ID = _count;
    }

    //TODO: GetBoss (R => Read #1)
    public Boss GetBoss(int id)
    {
        //use LINQ -> give me the first 'boss' you find with the ID = id, or just return null (class)
        return _hHouseBossDb.FirstOrDefault(x => x.ID == id)!;
    }

    //Seeding Data From this object
    public void SeedBossData()
    {
        var pinHead = new Boss
        {
            Name = "Deamon with Pins In His Head!"
        };

        AddBoss(pinHead);
    }

}
