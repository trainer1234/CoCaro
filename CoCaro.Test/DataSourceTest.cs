using CoCaro.DAL.Context;
using CoCaro.DAL.Models;
using CoCaro.Model;
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

        DataSource dataSource;

        [SetUp]
        public void SetUp()
        {
            mockCaroContext = new Mock<CaroContext>();
            mockDataSource = new Mock<IDataSource>();
        }

        //[Test]
        [TestCaseSource(typeof(TestData), "GetEmptyMockHistoryData")]
        public void GetGameHistory_ReturnEmpty(List<Game> games)
        {
            var data = games.AsQueryable();
            //var data = new List<Game>().AsQueryable();
            // Arrange
            var mockSet = new Mock<DbSet<Game>>();

            mockSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockCaroContext.Setup(c => c.Games).Returns(mockSet.Object);

            dataSource = new DataSource(mockCaroContext.Object);

            //// Act
            var historyData = dataSource.GetHistory();

            // Assert
            mockDataSource.VerifyAll();
            Assert.That(historyData, Is.Empty);
        }

        [TestCaseSource(typeof(TestData), "GetMockHistoryData")]
        public void GetGameHistory_Always_ReturnValues(List<Game> games)
        {
            var data = games.AsQueryable();
            
            // Arrange
            var mockSet = new Mock<DbSet<Game>>();

            mockSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(m => m.Include("Moves")).Returns(mockSet.Object);
            mockCaroContext.Setup(c => c.Games).Returns(mockSet.Object);
            
            dataSource = new DataSource(mockCaroContext.Object);
            var expectedResult = data.ToList();

            //// Act
            var historyData = dataSource.GetHistory();

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
                for (int j = 0; j < expectedResult[i].Moves.Count; j++)
                {
                    Assert.AreEqual(expectedResult[i].Moves[j].Point, historyData[i].Moves[j]);
                }
            }
        }

    }
}
