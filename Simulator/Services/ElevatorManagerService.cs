using Simulator.Entities;
using Simulator.Interfaces;
using System.Text;

namespace Simulator.Services;

public class ElevatorManagerService: IElevatorManagerService
{
    private (int, int) GetConfigSettings()
    {
        int floors = 0;
        int elevators = 0;
        bool ok = false;

        do
        {
            try
            {
                Console.WriteLine("Enter the number of floors");
                floors = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the number of elevators");
                elevators = int.Parse(Console.ReadLine());

                ok = true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Please enter enter a number: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Please enter a value: {ex.Message}");
            }
        }
        while (!ok);

        return (floors, elevators);
    }

    public (Building, int) ConfigureSettings()
    {
        Building building = null;
        int floors = 0;
        int elevators = 0;
        bool ok = false;

        do
        {
            try
            {
                (floors, elevators) = GetConfigSettings();
                building = new Building(floors, elevators);

                ok = true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        while (!ok);

        return (building, floors);
    }

    public void DisplaySettings(Building building)
    {
        Console.WriteLine("------------------");
        Console.WriteLine($"Floors: [0 to {building.Floors - 1}]");
        
        StringBuilder sb = new StringBuilder();
        sb.Append("Elevators: [");

        foreach(var e in building.Elevators)
        {
            sb.Append(e.Number);
            sb.Append(" ");
        }
 
        sb.Append("]");

        Console.WriteLine(sb.ToString());
        Console.WriteLine("------------------");
    }

    private int GetNumberOfPeople()
    {
        int noOfPeople = 0;
        bool ok = false;

        do
        {
            try
            {
                Console.WriteLine("Enter the number of people");
                noOfPeople = int.Parse(Console.ReadLine());

                ok = true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Please enter enter a number: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Please enter a value: {ex.Message}");
            }

        }
        while (!ok);

        return noOfPeople;
    }

    private int GetDestinationFloor(Building building, string message)
    {
        int destinationFloor = 0;
        bool ok = false;
        bool hasFloor = false;

        do
        {
            try
            {
                do
                {
                    Console.WriteLine(message);
                    destinationFloor = int.Parse(Console.ReadLine());

                    hasFloor = building.HasFloor(destinationFloor);
                    if (!hasFloor)
                        Console.WriteLine($"Invalid Floor. Enter a floor in the range of [0 - {building.Floors - 1}]");
                } while (!hasFloor);

                ok = true;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Please enter enter a number: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Please enter a value: {ex.Message}");
            }
        }
        while (!ok);

        return destinationFloor;
    }

    private void Load(Elevator elevator)
    {
        bool ok = false;
        do
        {
            try
            {
                var people = GetNumberOfPeople();
                elevator.Load(people);

                ok = true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        } while (!ok);
    }

    public void RequestElevator(Building building, int lastFloor)
    {
        var callingFloor = GetDestinationFloor(building, "Call an elevator by entering the floor number you are currently in");
        var elevator = building.FindElevator(callingFloor);

        elevator!.MoveTo(callingFloor, lastFloor);
        elevator!.Open();
        elevator.Offload();
        Load(elevator);
        elevator.Close();

        var destinationFloor = GetDestinationFloor(building, "Enter your destination floor");
        
        elevator!.MoveTo(destinationFloor, lastFloor);

        elevator.Open();
        elevator.Offload();
        elevator.Close();

        elevator.IsAvailable = true;
    }
}
