using MarsRoverProject.Command;
using MarsRoverProject.Domain.Aggregates;
using MarsRoverProject.Domain.Enums;
using MarsRoverProject.Domain.Values;
using MarsRoverProject.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRoverProject.Test
{
    [TestClass]
    public class MarsRoverTest
    {
        #region exception validation tests
        [TestMethod]
        public void CoordinateParametersLenghtIsNotValid()
        {
            Action action = () => PlateuService.CreatePlateu("5");
            Assert.AreEqual(Messages.CoordinateParametersLenghtIsNotValid, Assert.ThrowsException<ArgumentException>(action).Message);

        }

        [TestMethod]
        public void CoordinateParametersValueTypeIsNotValid()
        {
            Action action = () => PlateuService.CreatePlateu("5 A");
            Assert.AreEqual(Messages.CoordinateParametersValueTypeIsNotValid, Assert.ThrowsException<ArgumentException>(action).Message);

        }

        [TestMethod]
        public void CoordinateParametersValueIsNotValid()
        {
            Action action = () => PlateuService.CreatePlateu("5 -9");
            Assert.AreEqual(Messages.CoordinateParametersValueIsNotValid, Assert.ThrowsException<ArgumentException>(action).Message);

        }

        [TestMethod]
        public void RoverLocationParametersLenghtIsNotValid()
        {
            Action action = () => RoverService.DeployRover(PlateuService.CreatePlateu("5 5"), "1 2 N W");
            Assert.AreEqual(Messages.RoverLocationParametersLenghtIsNotValid, Assert.ThrowsException<ArgumentException>(action).Message);

        }

        [TestMethod]
        public void RoverLocationCoordinateParametersValueTypeIsNotValid()
        {
            Action action = () => RoverService.DeployRover(PlateuService.CreatePlateu("5 5"), "1 N N");
            Assert.AreEqual(Messages.RoverLocationCoordinateParametersValueTypeIsNotValid, Assert.ThrowsException<ArgumentException>(action).Message);

        }


        [TestMethod]
        public void RoverDirectionParameterTypeIsNotValid()
        {
            Action action = () => RoverService.DeployRover(PlateuService.CreatePlateu("5 5"), "1 2 A");
            Assert.AreEqual(Messages.RoverDirectionParameterTypeIsNotValid, Assert.ThrowsException<ArgumentException>(action).Message);

        }

        [TestMethod]
        public void RoverMovementCommandIsNotValid()
        {
            Action action = () => RoverService.RunAndMovementRover(RoverService.DeployRover(PlateuService.CreatePlateu("5 5"), "1 2 N"), "LMLABCDEFLMM");
            Assert.AreEqual(Messages.RoverMovementCommandIsNotValid, Assert.ThrowsException<ArgumentException>(action).Message);

        }

        [TestMethod]
        public void RoverCoordinateParametersInPlateuIsNotValid()
        {
            Action action = () => RoverService.RunAndMovementRover(RoverService.DeployRover(PlateuService.CreatePlateu("5 5"), "1 2 N"), "LMLMLMLMMMMMMMMMMMMM");
            Assert.AreEqual(Messages.RoverCoordinateParametersInPlateuIsNotValid, Assert.ThrowsException<ArgumentException>(action).Message);

        }
        #endregion

        #region command logic tests

        [TestMethod]
        public void CreatePlateu_Command()
        {
            var plateu_ = new Plateu(50, 5);
            var plateu = CreatePlateuCommand.CreatePlateu(plateu_);
            Assert.AreEqual(plateu_.XCoordinate, plateu.XCoordinate);
            Assert.AreEqual(plateu_.YCoordinate, plateu.YCoordinate);
        }

        [TestMethod]
        public void DeployRover_Command()
        {
            var rover_ = new Rover(1, 3, Direction.N, new Plateu(5, 5));
            var rover = DeployRoverCommand.DeployRover(rover_);
            Assert.AreEqual(rover_.XCoordinate, rover.XCoordinate);
            Assert.AreEqual(rover_.YCoordinate, rover.YCoordinate);
            Assert.AreEqual(rover_.Direction, rover.Direction);
        }

        [DataTestMethod]
        [DataRow(Direction.N, Direction.W)]
        [DataRow(Direction.E, Direction.N)]
        [DataRow(Direction.S, Direction.E)]
        [DataRow(Direction.W, Direction.S)]
        public void RoverMovements_Command_RoverMoveLeft(Direction direction, Direction expectedDirection)
        {
            Assert.AreEqual(expectedDirection, RoverMovementsCommand.RoverMoveLeft(direction));

        }

        [DataTestMethod]
        [DataRow(Direction.N, Direction.E)]
        [DataRow(Direction.E, Direction.S)]
        [DataRow(Direction.S, Direction.W)]
        [DataRow(Direction.W, Direction.N)]
        public void RoverMovements_Command_RoverMoveRight(Direction direction, Direction expectedDirection)
        {
            Assert.AreEqual(expectedDirection, RoverMovementsCommand.RoverMoveRight(direction));
        }

        [TestMethod]
        public void RoverMovements_Command_RoverMoveForward_Direction_North()
        {
            Assert.AreEqual(
              JsonConvert.SerializeObject(new Rover(2, 3, Direction.N, new Plateu(5, 5))),
              JsonConvert.SerializeObject(RoverMovementsCommand.RoverMoveForward(new Rover(2, 2, Direction.N, new Plateu(5, 5)), Direction.N)));

        }

        [TestMethod]
        public void RoverMovements_Command_RoverMoveForward_Direction_East()
        {

            Assert.AreEqual(
                JsonConvert.SerializeObject(new Rover(3, 2, Direction.E, new Plateu(5, 5))),
                JsonConvert.SerializeObject(RoverMovementsCommand.RoverMoveForward(new Rover(2, 2, Direction.E, new Plateu(5, 5)), Direction.E)));

        }
        [TestMethod]
        public void RoverMovements_Command_RoverMoveForward_Direction_South()
        {
            Assert.AreEqual(
                JsonConvert.SerializeObject(new Rover(2, 1, Direction.S, new Plateu(5, 5))),
                JsonConvert.SerializeObject(RoverMovementsCommand.RoverMoveForward(new Rover(2, 2, Direction.S, new Plateu(5, 5)), Direction.S)));

        }
        [TestMethod]
        public void RoverMovements_Command_RoverMoveForward_West()
        {
            Assert.AreEqual(
                JsonConvert.SerializeObject(new Rover(1, 2, Direction.W, new Plateu(5, 5))),
                JsonConvert.SerializeObject(RoverMovementsCommand.RoverMoveForward(new Rover(2, 2, Direction.W, new Plateu(5, 5)), Direction.W)));
        }


        [TestMethod]
        public void RoverOperate_Command()
        {
            Assert.AreEqual(
                JsonConvert.SerializeObject(new Rover(1, 4, Direction.N, new Plateu(5, 5))),
                JsonConvert.SerializeObject(RoverOperateCommand.RunAndMovementRover(new Rover(2, 2, Direction.N, new Plateu(5, 5)), new List<Movement>() { Movement.L, Movement.M, Movement.R, Movement.M, Movement.M })));
        }

        #endregion

        #region service logic tests

        [TestMethod]
        public void PlateuService_CreatePlateu()
        {
            var plateu = PlateuService.CreatePlateu("10 5");
            Assert.AreEqual(10, plateu.XCoordinate);
            Assert.AreEqual(5, plateu.YCoordinate);
        }

        [TestMethod]
        public void RoverService_DeployRover()
        {
            var rover = RoverService.DeployRover(PlateuService.CreatePlateu("5 5"), "1 2 N");
            Assert.AreEqual(1, rover.XCoordinate);
            Assert.AreEqual(2, rover.YCoordinate);
            Assert.AreEqual(Direction.N, rover.Direction);
        }

        [TestMethod]
        public void RoverService_RunAndMovementRover()
        {
            var rover = RoverService.RunAndMovementRover(RoverService.DeployRover(PlateuService.CreatePlateu("5 5"), "1 2 N"), "LMLMLMLMM");
            Assert.AreEqual(1, rover.XCoordinate);
            Assert.AreEqual(3, rover.YCoordinate);
            Assert.AreEqual(Direction.N, rover.Direction);
        }

        #endregion

        #region business logic tests

        [TestMethod]
        public void CreatePlateuRunAndMovementRover()
        {
            var expectedData = ExpectedDataClass.CreatePlateuRunAndMovementRoverEcpectedData();

            var plateu = PlateuService.CreatePlateu("5 5");
            plateu.Rovers.Add(RoverService.RunAndMovementRover(RoverService.DeployRover(plateu, "1 2 N"), "LMLMLMLMM"));
            plateu.Rovers.Add(RoverService.RunAndMovementRover(RoverService.DeployRover(plateu, "3 3 E"), "MMRMMRMRRM"));


            Assert.AreEqual(expectedData.XCoordinate, plateu.XCoordinate);
            Assert.AreEqual(expectedData.YCoordinate, plateu.YCoordinate);
            Assert.AreEqual(expectedData.Rovers.Count, plateu.Rovers.Count);

            foreach (var rover in plateu.Rovers.Select((value, i) => new { i, value }))
            {
                Assert.AreEqual(expectedData.Rovers[rover.i].Plateu.XCoordinate, plateu.Rovers[rover.i].Plateu.XCoordinate);
                Assert.AreEqual(expectedData.Rovers[rover.i].Plateu.YCoordinate, plateu.Rovers[rover.i].Plateu.YCoordinate);
                Assert.AreEqual(expectedData.Rovers[rover.i].XCoordinate, plateu.Rovers[rover.i].XCoordinate);
                Assert.AreEqual(expectedData.Rovers[rover.i].YCoordinate, plateu.Rovers[rover.i].YCoordinate);
                Assert.AreEqual(expectedData.Rovers[rover.i].Direction, plateu.Rovers[rover.i].Direction);
            }

        }

        #endregion
    }
}
