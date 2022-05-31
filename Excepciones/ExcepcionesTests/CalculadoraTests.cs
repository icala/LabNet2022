using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones.Tests
{
    [TestClass()]
    public class CalculadoraTests
    {
        [TestMethod()]
        public void dividirTest()
        {
            //Arrange
            Calculadora calc = new Calculadora();
            var esperado = 5;
            //Act
            var res = calc.dividir(10, 2);

            //Assert
            Assert.AreEqual(esperado, res);
        }

        [ExpectedException(typeof(DivideByZeroException))]
        [TestMethod()]
        public void dividirTestArrojaExcepcion()
        {
            //Arrange
            Calculadora calc = new Calculadora();
            //Act
            var res = calc.dividir(10, 0);

            //Assert
            
        }
    }
}