using Simulator.Entities;

namespace Simulator.Test.BuildingTests;

public class FindElevator
{
    Building _building;
    public FindElevator()
    {
        _building = new Building(20, 3);
    }

    [Fact]
    public void ShouldFindTheClosestAvailableElevator()
    {
        var elevator1 = _building.Elevators.Where(e => e.Number == 1).First();
        elevator1.IsAvailable = true;

        var elevator2 = _building.Elevators.Where(e => e.Number == 2).First();
        elevator2.CurrentFloor = 15;
        elevator2.IsAvailable = true;

        var elevator3 = _building.Elevators.Where(e => e.Number == 3).First();
        elevator3.CurrentFloor = 6;
        elevator3.IsAvailable = true;

        var elevator = _building.FindElevator(12);

        Assert.Equal(2, elevator!.Number);
    }
}
