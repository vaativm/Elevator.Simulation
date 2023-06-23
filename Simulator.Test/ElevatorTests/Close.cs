using Simulator.Entities;

namespace Simulator.Test.ElevatorTests
{
    public class Close
    {
        private Elevator _elevator;
        public Close() 
        {
            _elevator = new Elevator(1);
        }

        [Fact]
        public void IsOpenShouldBeFalse() 
        {
            _elevator.Open();

            _elevator.Close();

            Assert.Equal(false,_elevator?.IsOpen);
        }
    }
}
