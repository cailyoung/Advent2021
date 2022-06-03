using FluentAssertions;

namespace Day12.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData(false, 10)]
    [InlineData(true, 36)]
    public void SmallExampleHasTenPaths(bool isPartTwo, int expectedPathCount)
    {
        var input = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end".Split(Environment.NewLine);

        var actualCaveSystem = FileHelper.ParseInput(input);

        var actualPaths = !isPartTwo ? actualCaveSystem.ValidPartOnePaths : actualCaveSystem.ValidPartTwoPaths;

        actualPaths.Should().Be(expectedPathCount);
    }

    [Fact]
    public void MediumExampleHasNineteenPaths()
    {
        var input = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc".Split(Environment.NewLine);
        
        var actualCaveSystem = FileHelper.ParseInput(input);

        var actualPaths = actualCaveSystem.ValidPartOnePaths;

        actualPaths.Should().Be(19);
    }


    [Fact]
    public void LargeExampleHas226Paths()
    {
        var input = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW".Split(Environment.NewLine);
        
        var actualCaveSystem = FileHelper.ParseInput(input);

        var actualPaths = actualCaveSystem.ValidPartOnePaths;

        actualPaths.Should().Be(226);
    }
}