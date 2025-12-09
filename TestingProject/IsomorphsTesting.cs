using CSC250;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    [TestClass]
    public class IsomorphsTesting
    {
        [TestMethod]
        public void LooseValueHappyPath()
        {
            string input = "dog";
            string expected = "111";
            string output = Isomorphs.GetLooseValue(input);
            Assert.IsTrue(output == expected);
        }

        [TestMethod]
        public void ExactValueHappyPath()
        {
            string input = "dog";
            string expected = "012";
            string output = Isomorphs.GetExactValue(input);
            Assert.IsTrue(output == expected);
        }

        [TestMethod]
        public void ExactValueHappyPath2()
        {
            string input = "dad";
            string expected = "010";
            string output = Isomorphs.GetExactValue(input);
            Assert.IsTrue(output == expected);
        }

        
    }

    
}
