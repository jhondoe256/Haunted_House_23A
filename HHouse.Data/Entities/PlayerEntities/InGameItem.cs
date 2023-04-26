
public class InGameItem
{
    public int ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public int TimesCanBeUsed { get; set; }
    public bool IsUsable
    {
        get
        {
            return (TimesCanBeUsed > 0) ? true : false;
        }
    }
}
