using FluentAssertions;
using Moq;

namespace Bowlings.Tests;

public class UnitTest1
{
    [Fact]
    public void LoadFile_ShouldReturnCorrectContent()
    {
        // Arrange
        var fileSystemMock = new Mock<IFileSystem>();
        var fileLoader = new FileLoader(fileSystemMock.Object);
        var fileName = "testFile";
        
        string expectedContent = "Sjaak, 1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6\n" +
                                 "Piet, 10,1,3,8,2,10,0,0,8,0,7,2,8,1,10,10,10,6";

        fileSystemMock.Setup(system => system.FileExists(fileName)).Returns(true);
        fileSystemMock.Setup(system => system.LoadFile(fileName)).Returns(expectedContent);
        
        // Act
        var content = fileLoader.LoadFile(fileName);
        
        // Assert
        content.Should().Be(expectedContent);
        fileSystemMock.Verify(fs => fs.LoadFile(fileName), Times.Once);
    }
    
    [Fact]
    public void LoadNonExistingFile_Abort()
    {
        // Arrange
        var fileSystemMock = new Mock<IFileSystem>();
        var fileLoader = new FileLoader(fileSystemMock.Object);
        var fileName = "testFile";
        fileSystemMock.Setup(system => system.FileExists(fileName)).Returns(false);
        
        // Act
        Action act = () => fileLoader.LoadFile(fileName);
        
        // Assert
        act.Should().Throw<FileNotFoundException>();
        fileSystemMock.Verify(fs => fs.LoadFile(fileName), Times.Never);
    }
    
    [Fact]
    public void ParseFileContent_ShouldReturnRightPlayers()
    {
        // Arrange
        var playerContentParser = new PlayerContentParser();
        string fileContent = "Sjaak, 1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6\n" +
                            "Piet, 10,1,3,8,2,10,0,0,8,0,7,2,8,1,10,10,10,6";
        
        // Act
        var playerContents = playerContentParser.Parse(fileContent);
        
        // Assert
        var playerNames = playerContents.Select(pc => pc.Name).ToList();
        playerNames.Should().BeEquivalentTo(new List<string> { "Sjaak", "Piet" });
    }
    
        
    [Fact]
    public void ParseFileContent_ShouldReturnRightScores()
    {
        // Arrange
        var playerContentParser = new PlayerContentParser();
        string fileContent = "Sjaak, 1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6\n" +
                             "Piet, 10,1,3,8,2,10,0,0,8,0,7,2,8,1,10,10,10,6";
        
        // Act
        var playerContents = playerContentParser.Parse(fileContent);
        
        // Assert
        var playerScores = playerContents.Select(pc => pc.Scores).ToList();
        playerScores.Should().BeEquivalentTo(new List<List<int>> { 
            new() {1,4,4,5,6,4,5,5,10,0,1,7,3,6,4,10,2,8,6}, 
            new() {10,1,3,8,2,10,0,0,8,0,7,2,8,1,10,10,10,6}
        });
    }
}