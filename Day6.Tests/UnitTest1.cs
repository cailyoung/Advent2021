using System.Collections.Immutable;
using Day6;
using FluentAssertions;
using Xunit;

namespace Day.Tests;

public class UnitTest1
{
    [Fact]
    public void FirstDayReturnsCorrectFishAges()
    {
        var initialState = new School(
            ImmutableList.Create(
                new LanternFish(3),
                new LanternFish(4),
                new LanternFish(3),
                new LanternFish(1),
                new LanternFish(2)
            ));
        
        var expectedAfterFirstDay = new School(
            ImmutableList.Create(
                new LanternFish(2),
                new LanternFish(3),
                new LanternFish(2),
                new LanternFish(0),
                new LanternFish(1)
            ));

        var actualAfterFirstDay = Operations.AddADay(initialState);

        actualAfterFirstDay.CurrentFish.Should().BeEquivalentTo(expectedAfterFirstDay.CurrentFish);
    }
}