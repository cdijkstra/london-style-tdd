namespace Bowlings;

public class BowlingManager(IFileLoader fileLoader, IPlayerContentParser playerContentParser)
{
    public string PlayGame(string fileName)
    {
        var fileContent = fileLoader.LoadFile(fileName);
        var playerContent = playerContentParser.Parse(fileContent);

        return "Bla";
    }
}
