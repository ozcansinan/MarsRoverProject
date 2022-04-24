using MarsRoverProject.Domain.Aggregates;

namespace MarsRoverProject.Command
{
    public static class CreatePlateuCommand
    {
        public static Plateu CreatePlateu(Plateu plateu)
        {
            return new Plateu(plateu.XCoordinate, plateu.YCoordinate);
        }
    }
}
