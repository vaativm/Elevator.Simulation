using Simulator.Entities;

namespace Simulator.Test.BuildingTests;

public class BuildingConstructor
{
    [Fact]
    public void BuildingConstructorShouldThrowArgumentOutOfRangeExceptionWhenFloorsAreLessThan2()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Building(1, 1));
    }

    [Fact]
    public void BuildingConstructorShouldThrowArgumentOutOfRangeExceptionWhenElevatorsAreLessThan1()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Building(5, 0));
    }

    [Fact]
    public void BuildingConstructorShouldCreateCorrectNumberOfElevators()
    {
        var building = new Building(5, 2);

        Assert.Equal(2, building.Elevators.Count);
    }
}
