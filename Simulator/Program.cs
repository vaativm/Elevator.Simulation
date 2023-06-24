using Simulator.Interfaces;
using Simulator.Services;

Console.WriteLine("Configure settings");
Console.WriteLine("------------------");

IElevatorManagerService _elevatorManager;
_elevatorManager = new ElevatorManagerService();

var (building, floors) = _elevatorManager.ConfigureSettings();
_elevatorManager.DisplaySettings(building);

var lastFloor = floors - 1;

while (true)
{
    _elevatorManager.RequestElevator(building,lastFloor);
}
