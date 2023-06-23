using Simulator.Entities;

namespace Simulator.Test.ElevatorTests;

public class Load
{
    Elevator _elevator;
    public Load() 
    {
        _elevator = new Elevator(1);
    }

    [Fact]
    public void ShouldUpdatePeopleCountCorrectlyGivenCorrectInput()
    {
        _elevator.Load(5);

        Assert.Equal(5, _elevator.PeopleCount);
    }

    [Fact]
    public void ShouldThrowArgumentOutOfRangeExceptionWhenGivenWrongInput()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _elevator.Load(12));
    }
}
