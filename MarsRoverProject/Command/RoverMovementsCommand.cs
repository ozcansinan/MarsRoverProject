using MarsRoverProject.Domain.Aggregates;
using MarsRoverProject.Domain.Enums;
using MarsRoverProject.Domain.Values;

namespace MarsRoverProject.Command
{
    public static class RoverMovementsCommand
    {
        public static Direction RoverMoveLeft(Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    direction = Direction.W;
                    break;

                case Direction.E:
                    direction = Direction.N;
                    break;

                case Direction.S:
                    direction = Direction.E;
                    break;

                case Direction.W:
                   direction =  Direction.S;
                    break;
                
            }

            return direction;
            
        }
        public static Direction RoverMoveRight(Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    direction = Direction.E;
                    break;

                case Direction.E:
                    direction = Direction.S;
                    break;

                case Direction.S:
                    direction = Direction.W;
                    break;

                case Direction.W:
                    direction = Direction.N;
                    break;
              
            }

            return direction;

        }


        public static Rover RoverMoveForward(Rover rover, Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    rover.YCoordinate += Constant.MotionCoefficent;
                    break;

                case Direction.E:
                    rover.XCoordinate += Constant.MotionCoefficent;
                    break;

                case Direction.S:
                    rover.YCoordinate -= Constant.MotionCoefficent;
                    break;

                case Direction.W:
                    rover.XCoordinate -= Constant.MotionCoefficent;
                    break;

            }

            return rover;

        }

    }
}
