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
