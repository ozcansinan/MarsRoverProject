using MarsRoverProject.Command;
using MarsRoverProject.Domain.Aggregates;
using MarsRoverProject.Domain.Enums;
using MarsRoverProject.Domain.Values;
using MarsRoverProject.Validation;
using System;
using System.Linq;

namespace MarsRoverProject.Services
{
    public static class RoverService
    {
        public static Rover DeployRover(Plateu plateu,string commandString) 
        {
            string[] commadList = commandString.Split(" ");

            ValidationHelper.RoverLocationParameterIsValid(commadList);

            return DeployRoverCommand.DeployRover(
                new Rover(
                    Convert.ToInt32(commadList[Constant.RoverCommandXCoordinateIndex]), 
                    Convert.ToInt32(commadList[Constant.RoverCommandYCoordinateIndex]), 
                    Enum.Parse<Direction>(commadList[Constant.RoverCommandDirectionIndex]), 
                    plateu)
                );
        }

        public static Rover RunAndMovementRover(Rover rover, string commandString)
        {
            char[] commandArray = commandString.ToCharArray();

            ValidationHelper.RoverMovementParameterIsValid(commandArray);

            Rover rover_ = RoverOperateCommand.RunAndMovementRover(
                rover, 
                commandArray.Select(c => (Movement)Enum.Parse(typeof(Movement), c.ToString())).ToList()
                );

            ValidationHelper.RoverCoordinateIsValidInPlateu(rover_);

            return rover_;
        }
    }
}
