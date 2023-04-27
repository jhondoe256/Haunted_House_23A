
public class Floor
{
    //unique Identifier
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<Challenge> Challenges { get; set; } = new List<Challenge>();

    public void PrintChallenges()
    {
        foreach (Challenge challenge in Challenges)
        {
            System.Console.WriteLine(challenge);
        }
    }
}
