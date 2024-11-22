namespace Bowlings;

public interface IPlayerContentParser
{
    public List<PlayerContent> Parse(string fileContent);
}

public class PlayerContentParser : IPlayerContentParser
{
    public List<PlayerContent> Parse(string fileContent)
    {
        if (string.IsNullOrWhiteSpace(fileContent))
            throw new ArgumentException("File content cannot be null or empty");

        return fileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line =>
            {
                var parts = line.Split(',', StringSplitOptions.TrimEntries);
                var name = parts[0];
                var scores = parts.Skip(1).Select(int.Parse).ToList();

                return new PlayerContent(name, scores);
            }).ToList();
    }
}