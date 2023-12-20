using Moq;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mock<ICalculator> calculatorMock = new Mock<ICalculator>();

            calculatorMock.Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(42);

            calculatorMock.Setup(c => c.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int a, int b) =>
                {
                    return a + b;
                });

            //  calculatorMock.Setup(c => c.Add(1, 5)).Returns(6);

            ICalculator calculator = calculatorMock.Object;

            Console.WriteLine(calculator.Add(10, 5));
        }
    }
}