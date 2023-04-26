
public class Player
{
    public Player()
    {
        SetupPlayerInitialization();
    }

    public Player(string name)
    {
        Name = name;
    }

    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public int HealthPoints { get; set; } = 100;
    public bool IsDead
    {
        get
        {
            return (HealthPoints <= 0) ? true : false;
        }
    }

    public void DecreaseHealth(int pointValue = 5)
    {
        HealthPoints -= pointValue;
    }
    public void IncreaseHealth(int pointValue = 5)
    {
        HealthPoints += pointValue;
    }

    public List<InGameItem> Items;
    private InGameItem PlasmaPistol;
    private InGameItem FlashLight;
    private InGameItem Map;
    private InGameItem Knife;

    public void ShootPlasmaPistol(Enemy enemy, int attackPower = 15)
    {
        if (PlasmaPistol.IsUsable)
        {
            PlasmaPistol.TimesCanBeUsed--;
            System.Console.WriteLine($"You shot the Plasma Pistol at {enemy.Name}!\n" +
                $"You have {PlasmaPistol.TimesCanBeUsed} bullits left!");

            if (enemy.HealthPoints >= 0)
            {
                enemy.DecreaseHealth(attackPower);
            }
        }
        else
        {
            System.Console.WriteLine("Shoot! I Better find some bullits!");
        }
    }

    public void LoadPlasmaPistol(int roundValue)
    {
        PlasmaPistol.TimesCanBeUsed += roundValue;
    }

    public void SetupPlayerInitialization()
    {
        Items = GameUtilities.InitializePlayerStartupItems();
        Knife = Items[0];
        Map = Items[1];
        FlashLight = Items[2];
        PlasmaPistol = Items[3];
    }
}
