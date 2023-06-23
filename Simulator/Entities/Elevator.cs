namespace Simulator.Entities;

public class Elevator
{
    public int Number { get; set; }

    public const int WEIGHTLIMIT = 8;
    public bool IsMoving { get; set; } = false;
    public bool IsOpen { get; set; } = false;
    public bool IsAvailable { get; set; } = true;
    public Status CurrentStatus { get; set; } = Status.Closed;
    public Direction CurrentDirection { get; set; } = Direction.Up;
    public int CurrentFloor { get; set; } = 0;
    public int PeopleCount { get; set; } = 0;

    public Elevator(int number)
    {
        Number = number;
    }

    public void Open()
    {
        Console.WriteLine($"Elevator {Number} is opening");
        CurrentStatus = Status.Opening;

        Thread.Sleep(1000);

        IsOpen = true;
    }

    public void Close()
    {
        Console.WriteLine($"Elevator {Number} is closing");
        CurrentStatus = Status.Closing;

        Thread.Sleep(1000);

        IsOpen= false;
    }

    public void Load(int people)
    {
        if (people < 0 || people > WEIGHTLIMIT)
            throw new ArgumentOutOfRangeException("Enter a number in the range of [0 - 8]");

        Console.WriteLine($"Elevator {Number} is loading");
        CurrentStatus = Status.Loading;

        Thread.Sleep(1000);

        PeopleCount = people;
    }

    public void Offload()
    {
        if (PeopleCount == 0)
            return;

        Console.WriteLine($"Elevator {Number} is offloading");
        CurrentStatus = Status.Offloading;

        Thread.Sleep(1000);

        PeopleCount = 0;
    }

    public void MoveTo(int destinationFloor, int lastFloor)
    {
        if (destinationFloor > lastFloor || destinationFloor < 0)
            throw new ArgumentOutOfRangeException($"Invalid floor. Floor number should be in the range of [{0} - {lastFloor}]");

        if (CurrentFloor == destinationFloor)
        {
            Thread.Sleep(1000);
        }
        else if (CurrentFloor < destinationFloor)
        {
            Console.WriteLine($"Elevator {Number} is {Status.Moving} {Direction.Up} to floor number {destinationFloor}");

            CurrentStatus = Status.Moving;
            CurrentDirection = Direction.Up;

            for (int f = CurrentFloor; f <= destinationFloor; f++)
            {
                Console.WriteLine($"Now at floor: {f}");

                Thread.Sleep(1000);
            }
        }
        else
        {
            Console.WriteLine($"Elevator {Number} is {Status.Moving} {Direction.Down} to floor {destinationFloor}");

            CurrentStatus = Status.Moving;
            CurrentDirection = Direction.Down;

            for (int f = CurrentFloor; destinationFloor <= f; f--)
            {
                Console.WriteLine($"Now at floor: {f}");

                Thread.Sleep(1000);
            }
        }
        
        CurrentFloor = destinationFloor;

        if (CurrentFloor == lastFloor)
            CurrentDirection = Direction.Down;

        if (CurrentFloor == 0)
            CurrentDirection = Direction.Up;
    }

    public enum Direction
    {
        Up = 1,
        Down
    }

    public enum Status
    {
        Opening,
        Open,
        Loading,
        Offloading,
        Moving,
        Closing,
        Closed
    }
}
