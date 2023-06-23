using Simulator.Entities;

namespace Simulator.Test.ElevatorTests;

public class Offload
{
    Elevator _elevator;
    public Offload()
    {
        _elevator = new Elevator(1);
    }

    [Fact]
    public void ShouldSetPeopleCountToZero()
    {
        _elevator.Load(5);

        Assert.Equal(5, _elevator.PeopleCount);
        _elevator.Offload();

        Assert.Equal(0, _elevator.PeopleCount);
    }
}
