
public abstract class Challenge  //'base class'
{
    //todo: 'Key' unique identifier for each challenge
    public int ID { get; set; }

    public string ChallengeDescription {get;set;} = string.Empty;

    public List<string> ChallengeTasks {get;set;} = new List<string>();

    public bool IsComplete
    {
        get
        {
            return (ChallengeTasks.Count() <= 0) ? true : false;

            // if(ChallengeTasks.Count() <= 0)
            // {
            //     return true;
            // }
            // else
            // {
            //     return false;
            // }
        }
    }
}
