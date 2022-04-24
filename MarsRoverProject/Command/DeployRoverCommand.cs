using MarsRoverProject.Domain.Aggregates;

namespace MarsRoverProject.Command
{
    public static class DeployRoverCommand
    {
        public static Rover DeployRover(Rover rover)
        {
            return new Rover(rover.XCoordinate, rover.YCoordinate, rover.Direction,rover.Plateu);
           
        }
    }
}
