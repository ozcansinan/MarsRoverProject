using MarsRoverProject.Command;
using MarsRoverProject.Domain.Aggregates;
using MarsRoverProject.Domain.Values;
using MarsRoverProject.Validation;
using System;

namespace MarsRoverProject.Services
{
    public static class PlateuService
    {
        public static Plateu CreatePlateu(string commandString)
        {
            string[] commadList = commandString.Split(" ");

            ValidationHelper.CoordinateParameterIsValid(commadList);

            return CreatePlateuCommand.CreatePlateu(
                new Plateu(
                    Convert.ToInt32(commadList[Constant.PlateuCommandXCoordinateIndex]), 
                    Convert.ToInt32(commadList[Constant.PlateuCommandYCoordinateIndex]))
                );
        }
    }
}
