using Simulator.Entities;

namespace Simulator.Interfaces;

public interface IElevatorManagerService
{
    (Building, int) ConfigureSettings();
    void DisplaySettings(Building building);
    void RequestElevator(Building building, int lastFloor);
}
