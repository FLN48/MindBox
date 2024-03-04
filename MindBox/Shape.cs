namespace MindBox.Shape
{
    public abstract class ShapeCommon
    {
        private string Name { get; }
        public ShapeCommon(string _name)
        {
            Name = _name;
        }
        public abstract double calcSquare();
    }
    public class Circle : ShapeCommon
    {
        private double Radius { get; }
        ILogger logger { get; set; }
        public Circle(ILogger _logger, string _Name, double _Radius) : base(_Name)
        {
            if (_logger == null)
                throw new ArgumentException($"Ошибка: Не реализован интерфейс логгирования\r\nПроверьте входные значения");
            ILogger logger = _logger;
            try
            {
                if (_Radius < 0)
                    throw new ArgumentException($"Ошибка: Радиус не может быть меньше 0\r\nПроверьте входное значение радиуса");
                Radius = _Radius;
            }
            catch (Exception ex)
            {
                logger.LogException(ex.Message);
            }
        }

        public override double calcSquare()
        {
            return Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
        }
    }

    public class Triangle : ShapeCommon
    {
        private double Side_A { get; }
        private double Side_B { get; }
        private double Side_C { get; }
        ILogger logger { get; set; }
        public Triangle(ILogger _logger, string _Name, double _Side_A, double _Side_B, double _Side_C) : base(_Name)
        {
            if (_logger == null)
                throw new ArgumentException($"Ошибка: Не реализован интерфейс логгирования\r\nПроверьте входные значения");
            ILogger logger = _logger;
            try
            {
                if (_Side_A < 0 || _Side_B < 0 || _Side_C < 0)
                    throw new ArgumentException($"Ошибка: Сторона не может быть меньше 0\r\nПроверьте входные значения сторон");
                if (_Side_A > (_Side_B + _Side_C) || _Side_B > (_Side_A + _Side_C) || _Side_C > (_Side_B + _Side_A))
                    throw new ArgumentException($"Ошибка: Сумма длинн двух сторон не может быть меньше третьей\r\nПроверьте входные значения сторон");

                Side_A = _Side_A;
                Side_B = _Side_B;
                Side_C = _Side_C;

            }
            catch (Exception ex)
            {
                logger.LogException(ex.Message);
            }
        }

        public override double calcSquare()
        {
            double p = (Side_A + Side_B + Side_C) / 2;
            double result = Math.Round(Math.Sqrt(p * (p - Side_A) * (p - Side_B) * (p - Side_C)), 1);
            return result;
        }

        public bool IsRectangular()
        {
            bool result = (Side_A == Math.Sqrt(Math.Pow(Side_B, 2) + Math.Pow(Side_C, 2))
                         || Side_B == Math.Sqrt(Math.Pow(Side_A, 2) + Math.Pow(Side_C, 2))
                         || Side_C == Math.Sqrt(Math.Pow(Side_A, 2) + Math.Pow(Side_B, 2)));
            return result;
        }
    }
}