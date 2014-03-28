using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1.Tetris
{
    [TestClass]
    public class TestPattern
    {
        [TestMethod]
        public void Clone_Should_Clone_Rotations_And_Color_Them()
        {
            var pattern = new Pattern();
            pattern.Rotations = new ITetrisCup[]
            {
                A.Fake<ITetrisCup>(), A.Fake<ITetrisCup>(), 
                A.Fake<ITetrisCup>(), A.Fake<ITetrisCup>()
            };
            
        }
    }
}
