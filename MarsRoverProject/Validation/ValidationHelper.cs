using MarsRoverProject.Domain.Aggregates;
using MarsRoverProject.Domain.Enums;
using MarsRoverProject.Domain.Values;
using System;
using System.Linq;

namespace MarsRoverProject.Validation
{
    public static class ValidationHelper
    {
        public static void CoordinateParameterIsValid(string[] coordinateParameter)
        {
            if (coordinateParameter.Length != Constant.CoordinateSizeParameter)
                throw new ArgumentException(Messages.CoordinateParametersLenghtIsNotValid);


            foreach (var item in coordinateParameter)
            {
                if (!int.TryParse(item, out int coordinatePlaneValue))
                    throw new ArgumentException(Messages.CoordinateParametersValueTypeIsNotValid);

                if (coordinatePlaneValue <= 0)
                    throw new ArgumentException(Messages.CoordinateParametersValueIsNotValid);
            }

        }

        public static void RoverLocationParameterIsValid(string[] coordinateParameter)
        {
            if (coordinateParameter.Length != Constant.CoordinateValueLenght)
                throw new ArgumentException(Messages.RoverLocationParametersLenghtIsNotValid);

            foreach (var item in coordinateParameter.Take(Constant.CoordinateSizeParameter))
            {
                if (!int.TryParse(item, out _))
                    throw new ArgumentException(Messages.RoverLocationCoordinateParametersValueTypeIsNotValid);
            }

            if (!Enum.TryParse(coordinateParameter[Constant.DirectionIndexValueInCoordinate], out Direction direction))
            {
                throw new ArgumentException(Messages.RoverDirectionParameterTypeIsNotValid);
            }

        }

        public static void RoverMovementParameterIsValid(char[] movementParameter)
        {

            foreach (var moveCommand in movementParameter)
            {
                if (!Enum.TryParse(moveCommand.ToString(), out Movement direction))
                {
                    throw new ArgumentException(Messages.RoverMovementCommandIsNotValid);
                }
            }

        }

        public static void RoverCoordinateIsValidInPlateu(Rover rover)
        {
            if (rover.XCoordinate > rover.Plateu.XCoordinate || rover.XCoordinate <= Constant.MinimumCoordinateValue || rover.YCoordinate > rover.Plateu.YCoordinate || rover.YCoordinate <= Constant.MinimumCoordinateValue)
                throw new ArgumentException(Messages.RoverCoordinateParametersInPlateuIsNotValid);

        }
    }

}
