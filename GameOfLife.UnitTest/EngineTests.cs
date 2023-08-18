namespace GameOfLife.UnitTest;

public class EngineTests
    // TODO: More test cases 
{
    [Fact]
    public void ToadStep1()
    {
        // Arrange
        const string input = """
        ......
        .xxx..
        ..xxx.
        ......
        """;

        bool[,] boardBefore = Engine.ParseBoard(input);

        // Act
        bool[,] boardAfter = Engine.Tick(boardBefore);

        // Assert
        const string expectedOutput = """
        ..x...
        .x..x.
        .x..x.
        ...x..
        """;

        bool[,] expectedBoard = Engine.ParseBoard(expectedOutput);
        Assert.Equal(expectedBoard, boardAfter);
    }

    [Fact]
    public void ToadStep2()
    {
        // Arrange
        const string input = """
        ..x...
        .x..x.
        .x..x.
        ...x..
        """;

        bool[,] boardBefore = Engine.ParseBoard(input);

        // Act
        bool[,] boardAfter = Engine.Tick(boardBefore);

        // Assert
        const string expectedOutput = """
        ......
        .xxx..
        ..xxx.
        ......
        """;

        bool[,] expectedBoard = Engine.ParseBoard(expectedOutput);
        Assert.Equal(expectedBoard, boardAfter);
    }
}