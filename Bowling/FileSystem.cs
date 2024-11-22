namespace Bowlings;

public interface IFileSystem
{
    public bool FileExists(string fileName);
    public string LoadFile(string fileName);
}

public class FileSystem : IFileSystem
{
    public bool FileExists(string fileName)
    {
        return File.Exists(fileName);
    }

    public string LoadFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}