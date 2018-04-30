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

        DataSource systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            mockCaroContext = new Mock<CaroContext>();
            mockDataSource = new Mock<IDataSource>();
            gameMockSet = new Mock<DbSet<Game>>();
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
            var expectedResult = data.ToList();

            // Act
            var historyData = systemUnderTest.GetHistory();

            // Assert
            mockDataSource.VerifyAll();

            Assert.That(historyData, !Is.Empty);
            Assert.AreEqual(games.Count, historyData.Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Id, historyData[i].Id);
                Assert.AreEqual(expectedResult[i].Winner, historyData[i].Winner);
                Assert.AreEqual(expectedResult[i].Duration, historyData[i].GameDuration);
                Assert.AreEqual(expectedResult[i].StartTime, historyData[i].StartTime);
                Assert.AreEqual(expectedResult[i].Moves.Count, historyData[i].NumberOfMove);
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
            SeedData seedData = new SeedData();
            var data = seedData.SeedGameData().AsQueryable();

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
            Assert.AreEqual(expectedResult.Id, gameRecord.Id);
            Assert.AreEqual(expectedResult.Winner, gameRecord.Winner);
            Assert.AreEqual(expectedResult.StartTime, gameRecord.StartTime);
            Assert.AreEqual(expectedResult.Duration, gameRecord.GameDuration);
            Assert.AreEqual(expectedResult.Moves.Count, gameRecord.NumberOfMove);
            for (int i = 0; i < expectedResult.Moves.Count; i++)
            {
                Assert.AreEqual(expectedResult.Moves[i].Point, gameRecord.Moves[i]);
            }
        }
    }
}
