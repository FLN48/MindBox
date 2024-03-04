
using MindBox;
using MindBox.Shape;


namespace MindBox_nUnitTests
{
    [TestFixture]
    public class MindBoxTests
    {
        string MessageFromLibrary = "";
        string ExceptionFromLibrary = "";
        [TestCase(4, 50.27)]
        public void CalcSquare_Circle_R4(double _in, double _out)
        {
            LoggerToAnyOC newLogger = new LoggerToAnyOC();
            newLogger.LoggerMessage += logMessage;
            newLogger.LoggerException += logException;

            ShapeCommon shape = new Circle(newLogger, "ќкружность", _in);
            double result = shape.calcSquare();
            Assert.AreEqual(_out, result);
        }
        private void logMessage(string msg)
        {
            MessageFromLibrary = msg;
            Console.WriteLine(MessageFromLibrary);
        }
        private void logException(string msg)
        {
            ExceptionFromLibrary = msg;
            Console.WriteLine(ExceptionFromLibrary);
        }
        [TestCase(3,4,5,6)]
        public void CalcSquare_Triangle_A3_B4_C5(double in_Side_A, double in_Side_B, double in_Side_C, double _out)
        {
            LoggerToAnyOC newLogger = new LoggerToAnyOC();
            newLogger.LoggerMessage += logMessage;
            newLogger.LoggerException += logException;

            ShapeCommon shape = new Triangle(newLogger,"“реугольник",3,4,5);
            double result = shape.calcSquare();
            Assert.AreEqual(6, result);
        }
    }
}