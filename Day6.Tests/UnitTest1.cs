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

    [Fact]
    public void SecondDayReturnsCorrectSchool()
    {
        var initialState = new School(
            ImmutableList.Create(
                new LanternFish(2),
                new LanternFish(3),
                new LanternFish(2),
                new LanternFish(0),
                new LanternFish(1)
            ));
        
        var expectedAfterSecondDay = new School(
            ImmutableList.Create(
                new LanternFish(1),
                new LanternFish(2),
                new LanternFish(1),
                new LanternFish(6),
                new LanternFish(0),
                new LanternFish(8)
            ));
        
        var actualAfterSecondDay = Operations.AddADay(initialState);

        actualAfterSecondDay.CurrentFish.Should().BeEquivalentTo(expectedAfterSecondDay.CurrentFish);

    }

    [Fact]
    public void MultipleNewBirthsWork()
    {
        var initialState = new School(
            ImmutableList.Create(
                new LanternFish(0),
                new LanternFish(1),
                new LanternFish(0),
                new LanternFish(5),
                new LanternFish(6),
                new LanternFish(0),
                new LanternFish(1),
                new LanternFish(2),
                new LanternFish(2),
                new LanternFish(3),
                new LanternFish(7),
                new LanternFish(8)
            ));
        
        var expectedNextDaySchool = new School(
            ImmutableList.Create(
                new LanternFish(6),
                new LanternFish(0),
                new LanternFish(6),
                new LanternFish(4),
                new LanternFish(5),
                new LanternFish(6),
                new LanternFish(0),
                new LanternFish(1),
                new LanternFish(1),
                new LanternFish(2),
                new LanternFish(6),
                new LanternFish(7),
                new LanternFish(8),
                new LanternFish(8),
                new LanternFish(8)
            ));
        
        var actualAfterSecondDay = Operations.AddADay(initialState);

        actualAfterSecondDay.CurrentFish.Should().BeEquivalentTo(expectedNextDaySchool.CurrentFish);
    }
}