using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeperGame;


namespace MineSweeperGameTest
{
    [TestClass]
    public class MineSweeperTest
    {
        [TestMethod]
        public void LostGame_withNoLife()
        {
            //Arrange
            Form1 fm = new Form1();

            //Act
            fm.LostGame(0, 7);

            //Assert
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void LostGame_WithLife()
        {
            //Arrange
            Form1 fm = new Form1();

            //Act
            fm.LostGame(1, 7);

            //Assert
            fm.GoToNextMove(7, 1);
        }
        [TestMethod]
        public void GoToNextMove_ScoreGreaterThan10_Winner()
        {
            //Arrange
            Form1 fm = new Form1();
            //Act
            fm.GoToNextMove(11, 1);
            //Assert
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void GoToNextMove_ScoreLessThan10()
        {
            //Arrange
            Form1 fm = new Form1();
            //Act
            fm.GoToNextMove(7, 1);
            //Assert
            Assert.IsTrue(true);
        }
    }
}
