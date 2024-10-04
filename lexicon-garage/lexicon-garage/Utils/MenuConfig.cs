namespace lexicon_garage.Utils;

//TODO Kanske ska byta Action till Func för att kunna returna
public class MenuConfig
{
    public List<string> Options { get; private set; }
    public List<Action> Actions { get; private set; }

    public MenuConfig()
    {
        Options = new List<string>();
        Actions = new List<Action>();
    }

    public void AddOption(string option, Action action)
    {
        Options.Add(option);
        Actions.Add(action);
    }
}
