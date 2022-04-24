using MarsRoverProject.Domain.Aggregates.IEntities;
using System.Collections.Generic;

namespace MarsRoverProject.Domain.Aggregates
{
    public class Plateu : IPlateu
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public List<Rover> Rovers { get; set; }
        public Plateu(int xCoordinate, int yCoordinate)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Rovers = new List<Rover>();
        }
    }
}
