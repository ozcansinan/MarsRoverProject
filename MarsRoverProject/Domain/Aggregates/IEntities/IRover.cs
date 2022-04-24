using MarsRoverProject.Domain.Enums;

namespace MarsRoverProject.Domain.Aggregates.IEntities
{
    public interface IRover
    {
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        Direction Direction { get; set; }
        Plateu Plateu { get; set; }
    }
}
