using MarsRoverProject.Domain.Aggregates;
using MarsRoverProject.Domain.Aggregates.IEntities;
using MarsRoverProject.Domain.Enums;
using System.Collections.Generic;

namespace MarsRoverProject.Test
{
    public static class ExpectedDataClass
    {
        public static ExpectedParameters CreatePlateuRunAndMovementRoverEcpectedData()
        {
            ExpectedParameters expectedParameters = new ExpectedParameters();
            expectedParameters.XCoordinate = 5;
            expectedParameters.YCoordinate = 5;
            expectedParameters.Rovers.Add(new Rover(1, 3, Direction.N, new Plateu(expectedParameters.XCoordinate, expectedParameters.YCoordinate)));
            expectedParameters.Rovers.Add(new Rover(5, 1, Direction.E, new Plateu(expectedParameters.XCoordinate, expectedParameters.YCoordinate)));

            return expectedParameters;
        }
        public class ExpectedParameters : IPlateu
        {
            public int XCoordinate { get; set; }
            public int YCoordinate { get; set; }
            public List<Rover> Rovers { get; set; }
            public ExpectedParameters()
            {
                this.Rovers = new List<Rover>();
            }
        }
    }

}
