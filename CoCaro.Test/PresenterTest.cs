using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoCaro.Presenter.PlayWithPlayer;
using CoCaro.View.PlayWithPlayer;
using CoCaro.Model;

namespace CoCaro.Test
{
    [TestFixture]
    public class PlayWithPlayerPresenterTest
    {
        Mock<IDataSource> mockDataSource;
        Mock<IPlayWithPlayerPresenter> mockPlayWithPlayerPresenter;
        Mock<IPlayWithPlayerView> mockPlayerView;

        PlayWithPlayerPresenter systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            mockDataSource = new Mock<IDataSource>();
            mockPlayWithPlayerPresenter = new Mock<IPlayWithPlayerPresenter>();
            mockPlayerView = new Mock<IPlayWithPlayerView>();

            systemUnderTest = new PlayWithPlayerPresenter(mockPlayerView.Object, mockDataSource.Object);
        }

        [TestCaseSource(typeof(TestData), "Presenter_CheckGame_Data")]
        public void CheckGameTest(ChessBoard chessboard, int row, int column, int expectedResult)
        {
            // Arrange

            // Act
            var testResult = systemUnderTest.CheckGame(chessboard, row, column);

            // Assert
            Assert.AreEqual(expectedResult, testResult);
        }

        //[TestCaseSource(typeof(TestData), "PlayWithPlayerPresenter_CheckVertical_Data")]
        //public void CheckVertical_Always_ReturnExpectedResult(ChessBoard chessboard, bool expectedResult)
        //{
        //    // Arrange

        //    // Act
        //    var testResult = systemUnderTest.CheckVertical(chessboard);

        //    // Assert
        //    Assert.AreEqual(expectedResult, testResult);
        //}

        [Test]
        public void CreateNewGame_Always_CallsCreateNewGameMethodFromDataSource()
        {
            // Arrange
            mockDataSource.Setup(mock => mock.CreateNewGame(false, -1));

            // Act
            systemUnderTest.CreateNewGame();

            // Assert
            mockDataSource.Verify(mock => mock.CreateNewGame(false, -1), Times.Once);
        }

        [Test]
        public void EndGame_Always_CallsEndGameMethodFromDataSource()
        {
            // Arrange
            mockDataSource.Setup(mock => mock.EndGame(1, 1, 12));

            // Act
            systemUnderTest.EndGame(1, 1, 12);

            // Assert
            mockDataSource.Verify(mock => mock.EndGame(1, 1, 12), Times.Once);
        }

        [Test]
        public void StoreMove_Always_CallsStoreMoveMethodFromDataSource()
        {
            // Arrange
            mockDataSource.Setup(mock => mock.StoreMove(1, "M5"));

            // Act
            systemUnderTest.StoreMove(1, 5, 13);

            // Assert
            mockDataSource.Verify(mock => mock.StoreMove(1, "M5"), Times.Once);
        }

    }
}
