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
    public class PresenterTest
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
        }

        [TestCaseSource(typeof(TestData), "Presenter_CheckGame_Data")]
        public void CheckGameTest(ChessBoard chessboard, int row, int column, int expectedResult)
        {
            // Arrange
            systemUnderTest = new PlayWithPlayerPresenter(mockPlayerView.Object, mockDataSource.Object);

            // Act
            var testResult = systemUnderTest.CheckGame(chessboard, row, column);

            // Assert
            Assert.AreEqual(expectedResult, testResult);
        }
    }
}
