using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzukaczCeny.Testy
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    [TestFixture]
    public class TestZao
    {
        [TestCase(2.222, 2.22)]
        [TestCase(2.111, 2.11)]
        [TestCase(2.555, 2.56)]
        [TestCase(2.225, 2.23)]
        [TestCase(2.251, 2.25)]
        [TestCase(2.999, 3.00)]
        [TestCase(3.499, 3.50)]
        [TestCase(0.499, 0.50)]
        [TestCase(1.499, 1.50)]
        [TestCase(2.499, 2.50)]
        [TestCase(-2.499, -2.50)]        
        [TestCase(-1.499, -1.50)]
        [TestCase(-0.499, -0.50)]
        public void ZaoUp_true(double value, double expected)
        {
            var Z = new ZaoManager();

            double R = Z.Calculate(value);

            Assert.AreEqual(expected, R);
        }
    }
}