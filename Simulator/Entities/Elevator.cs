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
        Moving,
        Closing,
        Closed
    }
}
