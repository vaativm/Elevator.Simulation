using Simulator.Entities;

namespace Simulator.Test.BuildingTests
{
    public class HasFloor
    {
        Building _building;

        public HasFloor()
        {
            _building = new Building(6, 2);
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        public void ShouldReturnTrueGivenAnExistingFloor(int floor)
        {
            var result = _building.HasFloor(floor);

            Assert.Equal(true, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(6)]
        public void ShouldReturnFalseGivenNonExistingFloor(int floor)
        {
            var result = _building.HasFloor(floor);

            Assert.Equal(false, result);
        }
    }
}
