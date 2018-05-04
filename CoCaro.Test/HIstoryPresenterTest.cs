using CoCaro.Model;
using CoCaro.Presenter.History;
using CoCaro.View.History;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Test
{
    [TestFixture]
    public class HIstoryPresenterTest
    {
        Mock<IDataSource> mockDataSource;
        Mock<IHistoryPresenter> mockHistoryPresenter;
        Mock<IHistoryView> mockHistoryView;

        HistoryPresenter systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            mockDataSource = new Mock<IDataSource>();
            mockHistoryPresenter = new Mock<IHistoryPresenter>();
            mockHistoryView = new Mock<IHistoryView>();

            systemUnderTest = new HistoryPresenter(mockHistoryView.Object, mockDataSource.Object);
        }

        [Test]
        public void GetHistory_Always_CallsShowRecordMethod()
        {
            // Arrange
            var chessboard = new List<ChessBoard>
            {
                new ChessBoard
                {
                    Id = 1,
                    StartTime = DateTime.Now,
                    Winner = 1
                }
            };
            mockHistoryView.Setup(mock => mock.ShowRecords(chessboard));
            mockDataSource.Setup(mock => mock.GetHistory()).Returns(chessboard);

            // Act
            systemUnderTest.GetHistory();

            // Assert
            mockHistoryView.Verify(m => m.ShowRecords(chessboard), Times.Once);
        }
    }
}
