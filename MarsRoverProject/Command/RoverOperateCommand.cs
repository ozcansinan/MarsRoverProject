using MarsRoverProject.Domain.Aggregates;
using MarsRoverProject.Domain.Enums;
using System.Collections.Generic;

namespace MarsRoverProject.Command
{
    public static class RoverOperateCommand
    {
        public static Rover RunAndMovementRover(Rover rover, List<Movement> movements)
        {
            foreach (var item in movements)
            {
                switch (item)
                {
                    case Movement.L:
                        rover.Direction = RoverMovementsCommand.RoverMoveLeft(rover.Direction);
                        break;

                    case Movement.R:
                        rover.Direction = RoverMovementsCommand.RoverMoveRight(rover.Direction);
                        break;

                    case Movement.M:
                        rover = RoverMovementsCommand.RoverMoveForward(rover, rover.Direction);
                        break;

                }
            }

            return rover;
        }
    }
}
