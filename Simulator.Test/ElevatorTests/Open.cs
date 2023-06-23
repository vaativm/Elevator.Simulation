using Simulator.Entities;

namespace Simulator.Test.ElevatorTests;

public class Open
{
    private Elevator _elevator;
    public Open()
    {
        _elevator = new Elevator(1);
    }

    [Fact]
    public void IsOpenShouldBeTrue()
    {
        _elevator.Close();

        _elevator.Open();

        Assert.Equal(true, _elevator?.IsOpen);
    }
}
