using MarsRoverProject.Services;
using System;

namespace MarsRoverProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var plateu = PlateuService.CreatePlateu("5 5");

            plateu.Rovers.Add(RoverService.RunAndMovementRover(RoverService.DeployRover(plateu, "1 2 N"), "LMLMLMLMM"));
            plateu.Rovers.Add(RoverService.RunAndMovementRover(RoverService.DeployRover(plateu, "3 3 E"), "MMRMMRMRRM"));

            foreach (var item in plateu.Rovers)
            {
                Console.WriteLine(item.XCoordinate + " " + item.YCoordinate + " " + item.Direction);
            }


        }

    }
}
