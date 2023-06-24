using Simulator.Services;

Console.WriteLine("Configure settings");
Console.WriteLine("------------------");

var elevatorManager = new ElevatorManagerService();

var (building, floors) = elevatorManager.ConfigureSettings();
elevatorManager.DisplayFloorNumbers(building);

var lastFloor = floors - 1;

while (true)
{
    elevatorManager.RequestElevator(building,lastFloor);
}
