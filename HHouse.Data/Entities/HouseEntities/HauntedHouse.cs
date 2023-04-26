
public class HauntedHouse
{
    public HauntedHouse()
    {
        Name = "Boonville Farms";
        Address = "1357 Evil Lane";
        City = "Monsterville, Indiana";
        Player = new Player();
    }

    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public Player Player { get; set; }
    public List<Floor> FloorsInHouse { get; set; } = new List<Floor>();

    //ever obj in C# has a .ToString() method (virtual method)
    // we are going to override this 

    public override string ToString()
    {
        var str = $"ID: {ID}\n" +
            $"Name: {Name}\n" +
            $"Address: {Address}\n" +
            $"City: {City}\n" +
            $"Player: {Player}\n" +
            "=== Floors In House ===\n";

        foreach (Floor floor in FloorsInHouse)
        {
            str += $"FloorID: {floor.ID}\n" +
                $"Floor Name: {floor.Name}\n" +
                "=== Challenges on Floor ===\n";
            foreach (Challenge floorChallenge in floor.Challenges)
            {
                str += $"Floor Challenge Id: {floorChallenge.ID}\n" +
                    $"Floor Description: {floorChallenge.ChallengeDescription}\n";
                foreach (string task in floorChallenge.ChallengeTasks)
                {
                    str += $"{task}";
                }
                str += $"Floor Challenge Complete: {floorChallenge.IsComplete}\n";
            }
        }
        return str;
    }
}
