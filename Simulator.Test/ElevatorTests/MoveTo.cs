using Simulator.Entities;

namespace Simulator.Test.ElevatorTests;

public class MoveTo
{
    Elevator _elevator;

    public MoveTo()
    {
        _elevator = new Elevator(1);
    }

    [Fact]
    public void ShouldThrowArgumentOutOfRangeExceptionWhenGivenInvalidFloor()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _elevator.MoveTo(10, 7));
    }

    [Fact]
    public void ShouldSetCurrentFloorToTheDestinationFloorSupplied()
    {
        _elevator.MoveTo(6, 10);

        Assert.Equal(6, _elevator.CurrentFloor);
    }

    [Fact]
    public void ShouldSetCurrentDirectionToDownWhenTheDestinationFloorIsTheLastFloor()
    {
        _elevator.MoveTo(10, 10);

        Assert.Equal(Elevator.Direction.Down, _elevator.CurrentDirection);
    }

    public void ShouldSetCurrentDirectionToDownWhenTheDestinationFloorIsTheGroundFloor()
    {
        _elevator.MoveTo(0, 10);

        Assert.Equal(Elevator.Direction.Up, _elevator.CurrentDirection);
    }
}
