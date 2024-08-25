using Sparky;

namespace Sparky
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            int result = calculator.AddNumbers(10, 30);

            //Assert
            Assert.AreEqual(40, result);
             
        }
    }
}