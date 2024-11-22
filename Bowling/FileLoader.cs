namespace Bowlings;

public interface IFileLoader
{
    public string LoadFile(string fileName);
}

public class FileLoader : IFileLoader
{
    private IFileSystem _fileSystem;
    public FileLoader(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public string LoadFile(string fileName)
    {
        if (!_fileSystem.FileExists(fileName))
        {
            throw new FileNotFoundException($"The file {fileName} does not exist.");
        }

        return _fileSystem.LoadFile(fileName);
    }
}

public record PlayerContent(string Name, List<int> Scores);