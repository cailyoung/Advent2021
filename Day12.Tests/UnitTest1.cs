using FluentAssertions;

namespace Day12.Tests;

public class UnitTest1
{
    [Fact]
    public void SmallExampleHasTenPaths()
    {
        var input = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end".Split(Environment.NewLine);

        var actualCaveSystem = FileHelper.ParseInput(input);

        var actualPaths = actualCaveSystem.ValidPaths;

        actualPaths.Should().Be(10);
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

        var actualPaths = actualCaveSystem.ValidPaths;

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

        var actualPaths = actualCaveSystem.ValidPaths;

        actualPaths.Should().Be(226);
    }
}