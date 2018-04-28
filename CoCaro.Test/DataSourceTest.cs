using CoCaro.Model;
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
    public class DataSourceTest
    {
        Mock<IDataSource> mockDataSource;

        DataSource dataSource;

        [Test]
        public void GetGameRecordReturnNull(int id)
        {
            ChessBoard chessboard = null;
            mockDataSource.Setup(p => p.GetGameRecord(id)).Returns(chessboard);
            dataSource = new DataSource();
            dataSource.GetGameRecord(id);
            mockDataSource.VerifyAll();
            Assert.That(chessboard, Is.Null);
        }
    }
}
