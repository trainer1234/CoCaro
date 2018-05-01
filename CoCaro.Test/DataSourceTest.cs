using CoCaro.DAL.Context;
using CoCaro.DAL.Models;
using CoCaro.Model;
using CoCaro.Test.Data;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Test
{
    [TestFixture]
    public class DataSourceTest
    {
        Mock<IDataSource> mockDataSource;
        Mock<CaroContext> mockCaroContext;
        Mock<DbSet<Game>> gameMockSet;
        Mock<DbSet<Move>> moveMockSet;

        DataSource systemUnderTest;

        List<Game> gameMockData;
        List<Move> moveMockData;

        [SetUp]
        public void SetUp()
        {
            mockCaroContext = new Mock<CaroContext>();
            mockDataSource = new Mock<IDataSource>();
            gameMockSet = new Mock<DbSet<Game>>();
            moveMockSet = new Mock<DbSet<Move>>();

            SeedData seedData = new SeedData();
            gameMockData = seedData.SeedGameData();
            moveMockData = seedData.SeedMoveData();
        }

        //[Test]
        [TestCaseSource(typeof(TestData), "GetEmptyMockHistoryData")]
        public void GetGameHistory_ReturnEmpty(List<Game> games)
        {
            var data = games.AsQueryable();

            // Arrange
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(data.Provider);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(data.Expression);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(data.ElementType);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            gameMockSet.Setup(m => m.Include("Moves")).Returns(gameMockSet.Object);

            mockCaroContext.Setup(c => c.Games).Returns(gameMockSet.Object);

            systemUnderTest = new DataSource(mockCaroContext.Object);

            //// Act
            var historyData = systemUnderTest.GetHistory();

            // Assert
            mockDataSource.VerifyAll();
            Assert.That(historyData, Is.Empty);
        }

        [TestCaseSource(typeof(TestData), "GetMockHistoryData")]
        public void GetGameHistory_Always_ReturnValues(List<Game> games)
        {
            var data = games.AsQueryable();
            
            // Arrange
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(data.Provider);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(data.Expression);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(data.ElementType);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            gameMockSet.Setup(m => m.Include("Moves")).Returns(gameMockSet.Object);
            mockCaroContext.Setup(c => c.Games).Returns(gameMockSet.Object);
            
            systemUnderTest = new DataSource(mockCaroContext.Object);
            var expectedResult = data.OrderByDescending(game => game.StartTime).ToList();

            // Act
            var historyData = systemUnderTest.GetHistory();

            // Assert
            mockDataSource.VerifyAll();

            Assert.That(historyData, !Is.Empty);
            Assert.AreEqual(games.Count, historyData.Count, "Wrong number of history data");
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Id, historyData[i].Id, "Wrong id " + i.ToString());
                Assert.AreEqual(expectedResult[i].Winner, historyData[i].Winner, "Wrong winner " + i.ToString());
                Assert.AreEqual(expectedResult[i].Duration, historyData[i].GameDuration, "Wrong game duration " + i.ToString());
                Assert.AreEqual(expectedResult[i].StartTime, historyData[i].StartTime, "Wrong start time " + i.ToString());
                Assert.AreEqual(expectedResult[i].Moves.Count, historyData[i].NumberOfMove, "Wrong number of move " + i.ToString());
                for (int j = 0; j < expectedResult[i].Moves.Count; j++)
                {
                    Assert.AreEqual(expectedResult[i].Moves[j].Point, historyData[i].Moves[j]);
                }
            }
        }

        [TestCaseSource(typeof(TestData), "GetEmptyGameRecordData")]
        public void GetGameRecord_Always_ReturnEmpty_WhenGamesAreEmpty(List<Game> games)
        {
            var data = games.AsQueryable();

            // Arrange
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(data.Provider);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(data.Expression);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(data.ElementType);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockCaroContext.Setup(c => c.Games).Returns(gameMockSet.Object);

            systemUnderTest = new DataSource(mockCaroContext.Object);

            // Act
            var gameRecord = systemUnderTest.GetGameRecord(0);

            // Assert
            mockDataSource.VerifyAll();
            Assert.That(gameRecord, Is.Null);
        }

        [TestCaseSource(typeof(TestData), "GetGameRecordData")]
        public void GetGameRecord_Always_ReturnValues(int id)
        {
            var data = gameMockData.AsQueryable();

            // Arrange
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(data.Provider);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(data.Expression);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(data.ElementType);
            gameMockSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            gameMockSet.Setup(m => m.Include("Moves")).Returns(gameMockSet.Object);

            mockCaroContext.Setup(c => c.Games).Returns(gameMockSet.Object);

            systemUnderTest = new DataSource(mockCaroContext.Object);

            var expectedResult = data.SingleOrDefault(game => game.Id == id);

            // Act
            var gameRecord = systemUnderTest.GetGameRecord(id);

            // Assert
            mockDataSource.VerifyAll();

            Assert.That(gameRecord, !Is.Null);
            Assert.AreEqual(expectedResult.Id, gameRecord.Id, "Wrong Id");
            Assert.AreEqual(expectedResult.Winner, gameRecord.Winner, "Wrong winner");
            Assert.AreEqual(expectedResult.StartTime, gameRecord.StartTime, "Wrong start time");
            Assert.AreEqual(expectedResult.Duration, gameRecord.GameDuration, "Wrong Duration");
            Assert.AreEqual(expectedResult.Moves.Count, gameRecord.NumberOfMove, "Wrong number of move");
            for (int i = 0; i < expectedResult.Moves.Count; i++)
            {
                Assert.AreEqual(expectedResult.Moves[i].Point, gameRecord.Moves[i]);
            }
        }

        [Test]
        public void CreateNewGame_Always_Works()
        {
            // Arrange
            mockCaroContext.Setup(m => m.Games).Returns(gameMockSet.Object);
            systemUnderTest = new DataSource(mockCaroContext.Object);

            // Act
            var newChessBoard = systemUnderTest.CreateNewGame();

            // Assert
            gameMockSet.Verify(m => m.Add(It.IsAny<Game>()), Times.Once());
            mockCaroContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.That(newChessBoard, !Is.Null);
        }
        
        [TestCaseSource(typeof(TestData), "StoreNormalMoveData")]
        public void StoreMove_Always_Works(int id, string move)
        {
            var data = moveMockData.AsQueryable();

            // Arrange
            moveMockSet.As<IQueryable<Move>>().Setup(m => m.Provider).Returns(data.Provider);
            moveMockSet.As<IQueryable<Move>>().Setup(m => m.Expression).Returns(data.Expression);
            moveMockSet.As<IQueryable<Move>>().Setup(m => m.ElementType).Returns(data.ElementType);
            moveMockSet.As<IQueryable<Move>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            //gameMockSet.Setup(m => m.Include("Moves")).Returns(gameMockSet.Object);

            mockCaroContext.Setup(m => m.Moves).Returns(moveMockSet.Object);
            systemUnderTest = new DataSource(mockCaroContext.Object);
            
            // Act
            systemUnderTest.StoreMove(id, move);

            // Assert
            moveMockSet.Verify(m => m.Add(It.IsAny<Move>()), Times.Once());
            mockCaroContext.Verify(m => m.SaveChanges(), Times.Once());
        }


    }
}
