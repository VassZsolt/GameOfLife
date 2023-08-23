namespace GameOfLife.UnitTest;

public class EngineTests
// TODO: More test cases such as https://playgameoflife.com/info rules
{
    [Fact]
    public void NoNeighbor()
    {
        // Test of solitude
        const string input = """
        x
        """;

        const string expectedOutput = """
        .
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void OneHorizontalNeighbor()
    { 
        // Test of solitude
        const string input = """
        xx
        """;

        const string expectedOutput = """
        ..
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void OneVerticalNeighbor()
    {
        // Test of solitude
        const string input = """
        x
        x
        """;

        const string expectedOutput = """
        .
        .
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void OneDiagonalNeighbor()
    {
        // Test of solitude
        const string input = """
        x.
        .x
        """;

        const string expectedOutput = """
        ..
        ..
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void OneDiagonal2Neighbor()
    {
        // Test of solitude
        const string input = """
        .x
        x.
        """;

        const string expectedOutput = """
        ..
        ..
        """;

        TestOneTick(input, expectedOutput);
    }


    [Fact]
    public void ToadStep1()
    {
        const string input = """
        ......
        .xxx..
        ..xxx.
        ......
        """;

        const string expectedOutput = """
        ..x...
        .x..x.
        .x..x.
        ...x..
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void ToadStep2()
    {
        const string input = """
        ..x...
        .x..x.
        .x..x.
        ...x..
        """;

        const string expectedOutput = """
        ......
        .xxx..
        ..xxx.
        ......
        """;

        TestOneTick(input, expectedOutput);
    }

    private static void TestOneTick(string input, string expectedOutput)
    {
        bool[,] boardBefore = Engine.ParseBoard(input);

        bool[,] boardAfter = Engine.Tick(boardBefore);

        bool[,] expectedBoard = Engine.ParseBoard(expectedOutput);
        Assert.Equal(expectedBoard, boardAfter);
    }
}