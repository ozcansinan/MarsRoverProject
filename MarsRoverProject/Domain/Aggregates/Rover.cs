using MarsRoverProject.Domain.Aggregates.IEntities;
using MarsRoverProject.Domain.Enums;

namespace MarsRoverProject.Domain.Aggregates
{
    public class Rover : IRover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Direction Direction { get; set; }
        public Plateu Plateu { get; set; }
        public Rover(int xCoordinate, int yCoordinate, Direction direction,Plateu plateu)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Direction = direction;
            Plateu = plateu;
        }

    }
}
