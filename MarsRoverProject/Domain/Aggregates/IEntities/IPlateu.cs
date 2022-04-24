using System.Collections.Generic;

namespace MarsRoverProject.Domain.Aggregates.IEntities
{
    public interface IPlateu
    {
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        List<Rover> Rovers { get; set; }
    }
}
