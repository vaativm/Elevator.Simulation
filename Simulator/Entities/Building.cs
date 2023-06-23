namespace Simulator.Entities;

public class Building
{
    public readonly int Floors;
    private readonly int _noOfElevators;
    public List<Elevator> Elevators { get; set; } = new List<Elevator>();

    public Building(int noOfFloors, int noOfElevators)
    {
        if (noOfFloors < 2)
            throw new ArgumentOutOfRangeException("Number of floors should be greater or  equal to 2");

        if (noOfElevators < 1)
            throw new ArgumentOutOfRangeException("Number of elevators should be atleast 1");

        Floors = noOfFloors;
        _noOfElevators = noOfElevators;

        CreateElevators();
    }

    private void CreateElevators()
    {
        for (int i = 1; i <= _noOfElevators; i++)
        {
            Elevators.Add(new Elevator(i));
        }
    }

    public Elevator? FindElevator(int callingFloor)
    {
        Elevator? elevator = null;

        while (elevator == null)
        {
            var positions = Elevators.Where(e => e.IsAvailable).Select(f => f.CurrentFloor).ToArray();

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = Math.Abs(positions[i] - callingFloor);
            }

            var closest = positions.Min();
            elevator = Elevators.Where(e => e.IsAvailable && Math.Abs(e.CurrentFloor - callingFloor) == closest).FirstOrDefault();
        }

        return elevator;
    }
}
