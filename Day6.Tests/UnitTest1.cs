using System.Collections.Generic;
using System.Collections.Immutable;
using FluentAssertions;
using Xunit;

namespace Day6.Tests;

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

        var expectedDictAfterFirstDay = new Dictionary<int, int>
        {
            { 0, 1 },
            { 1, 1 },
            { 2, 2 },
            { 3, 1 }
        }.ToImmutableDictionary();

        var actualAfterFirstDay = Operations.AddADay(initialState);

        actualAfterFirstDay.CurrentFishDict.Should().BeEquivalentTo(expectedDictAfterFirstDay);
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
        
        var expectedDictAfterSecondDay = new Dictionary<int, int>
        {
            { 0, 1 },
            { 1, 2 },
            { 2, 1 },
            { 6, 1 },
            { 8, 1 }
        }.ToImmutableDictionary();
        
        var actualAfterSecondDay = Operations.AddADay(initialState);

        actualAfterSecondDay.CurrentFishDict.Should().BeEquivalentTo(expectedDictAfterSecondDay);

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
        
        var expectedDictAfterNextDay = new Dictionary<int, int>
        {
            { 0, 2 },
            { 1, 2 },
            { 2, 1 },
            { 4, 1 },
            { 5, 1 },
            { 6, 4 },
            { 7, 1 },
            { 8, 3 }
        }.ToImmutableDictionary();
        
        var actualAfterSecondDay = Operations.AddADay(initialState);

        actualAfterSecondDay.CurrentFishDict.Should().BeEquivalentTo(expectedDictAfterNextDay);
    }

    [Fact]
    public void RunSimulationThreeDaysGivesCorrectOutput()
    {
        var initialState = new School(
            ImmutableList.Create(
                new LanternFish(3),
                new LanternFish(4),
                new LanternFish(3),
                new LanternFish(1),
                new LanternFish(2)
            ));

        var expectedFinalState = new School(
            ImmutableList.Create(
                new LanternFish(0),
                new LanternFish(1),
                new LanternFish(0),
                new LanternFish(5),
                new LanternFish(6),
                new LanternFish(7),
                new LanternFish(8)
            ));
        
        var expectedDictAfterSimulation = new Dictionary<int, int>
        {
            { 0, 2 },
            { 1, 1 },
            { 5, 1 },
            { 6, 1 },
            { 7, 1 },
            { 8, 1 }
        }.ToImmutableDictionary();
        
        var finalState = Operations.RunSimulation(initialState, 3);

        finalState.CurrentFishDict.Should().BeEquivalentTo(expectedDictAfterSimulation);
    }

    [Theory]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    [InlineData(160, 26984457539)]
    public void RunSimulationGivesCorrectSchoolSizes(int daysToRun, long expectedCount)
    {
        var initialState = new School(
            ImmutableList.Create(
                new LanternFish(3),
                new LanternFish(4),
                new LanternFish(3),
                new LanternFish(1),
                new LanternFish(2)
            ));
        
        var finalState = Operations.RunSimulation(initialState, daysToRun);

        Assert.Equal(expectedCount, finalState.SchoolSize);
    }

    [Fact]
    public void NumericConstructorIsSane()
    {
        var inputNumbers = new[]
        {
            3, 4, 3, 1, 2
        };
        
        var expectedSchool = new School(
            ImmutableList.Create(
                new LanternFish(3),
                new LanternFish(4),
                new LanternFish(3),
                new LanternFish(1),
                new LanternFish(2)
            ));

        var actualSchool = new School(inputNumbers);

        actualSchool.Should().BeEquivalentTo(expectedSchool);
    }
}