using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCaro.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void OnePlusOneEqualsTwo()
        {
            Assert.AreEqual(1 + 1, 2);
        }
    }
}
