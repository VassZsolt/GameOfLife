namespace GameOfLife.UnitTest;

public class EngineTests
{
    #region _baseRules
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
    public void FourCrossNeighbor()
    {
        // Test of overpopulation, middle should die
        const string input = """
        .x.
        xxx
        .x.
        """;

        const string expectedOutput = """
        xxx
        x.x
        xxx
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void FourDiagonalNeighbor()
    {
        // Test of overpopulation, middle should die
        const string input = """
        x.x
        .x.
        x.x
        """;

        const string expectedOutput = """
        .x.
        x.x
        .x.
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void TwoDiagonalNeighbor()
    {
        // Test of rule 3, each cell with two or three neighbors survives
        //Middle should survive
        const string input = """
        x..
        .x.
        ..x
        """;

        const string expectedOutput = """
        ...
        .x.
        ...
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void ThreeNeighbor()
    {
        // Test of rule 3, each cell with two or three neighbors survives
        // Middle should survive
        const string input = """
        x..
        .xx
        ..x
        """;

        const string expectedOutput = """
        .x.
        .xx
        .xx
        """;

        TestOneTick(input, expectedOutput);
    }


    [Fact]
    public void ShouldBecomePopulated()
    {
        // Test of rule 4, each cell with three neighbors becomes populated
        // Middle should become populated
        const string input = """
        x..
        ..x
        ..x
        """;

        const string expectedOutput = """
        ...
        .x.
        ...
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void ShouldBecomePopulated2()
    {
        // Test of rule 4, each cell with three neighbors becomes populated
        // Middle should become populated
        const string input = """
        x..
        ...
        .xx
        """;

        const string expectedOutput = """
        ...
        .x.
        ...
        """;

        TestOneTick(input, expectedOutput);
    }
    #endregion
    #region _stillLifes

    [Fact]
    public void Block()
    {
        const string input = """
        ......
        .xx...
        .xx...
        ......
        """;

        const string expectedOutput = """"
        ......
        .xx...
        .xx...
        ......
        """";

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void Beehive()
    {
        const string input = """
        ..xx..
        .x..x.
        ..xx..
        ......
        """;

        const string expectedOutput = """"
        ..xx..
        .x..x.
        ..xx..
        ......
        """";

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void Loaf()
    {
        const string input = """
        ..xx..
        .x..x.
        ..x.x.
        ...x..
        """;

        const string expectedOutput = """"
        ..xx..
        .x..x.
        ..x.x.
        ...x..
        """";

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void Boat()
    {
        const string input = """
        .xx...
        .x.x..
        ..x...
        ......
        """;

        const string expectedOutput = """"
        .xx...
        .x.x..
        ..x...
        ......
        """";

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void Tub()
    {
        const string input = """
        ..x...
        .x.x..
        ..x...
        ......
        """;

        const string expectedOutput = """"
        ..x...
        .x.x..
        ..x...
        ......
        """";

        TestOneTick(input, expectedOutput);
    }


    #endregion
    #region _Oscillators
    [Fact]
    public void BlinkerStep1()
    {
        const string input = """
        ......
        .xxx..
        ......
        ......
        """;

        const string expectedOutput = """
        ..x...
        ..x...
        ..x...
        ......
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void BlinkerStep2()
    {
        const string input = """
        ..x...
        ..x...
        ..x...
        ......
        """;

        const string expectedOutput = """
        ......
        .xxx..
        ......
        ......
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

    [Fact]
    public void BeaconStep1()
    {
        const string input = """
        .xx....
        .xx....
        ...xx..
        ...xx..
        """;

        const string expectedOutput = """
        .xx....
        .x.....
        ....x..
        ...xx..
        """;

        TestOneTick(input, expectedOutput);
    }

    [Fact]
    public void BeaconStep2()
    {
        const string input = """
        .xx....
        .x.....
        ....x..
        ...xx..
        """;

        const string expectedOutput = """
        .xx....
        .xx....
        ...xx..
        ...xx..
        """;

        TestOneTick(input, expectedOutput);
    }
    #endregion


    private static void TestOneTick(string input, string expectedOutput)
    {
        bool[,] boardBefore = Engine.ParseBoard(input);

        bool[,] boardAfter = Engine.Tick(boardBefore);

        bool[,] expectedBoard = Engine.ParseBoard(expectedOutput);
        Assert.Equal(expectedBoard, boardAfter);
    }
}