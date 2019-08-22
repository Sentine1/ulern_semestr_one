using System;

namespace AngryBirds
{
	public static class AngryBirdsTask
	{
        // Ниже — это XML документация, её использует ваша среда разработки, 
        // чтобы показывать подсказки по использованию методов. 
        // Но писать её естественно не обязательно.
        /// <param name="v">Начальная скорость</param>
        /// <param name="distance">Расстояние до цели</param>
        /// <returns>Угол прицеливания в радианах от 0 до Pi/2</returns>
        public static double FindSightAngle(double v, double distance)
        {
            double g = 9.8;
            double dt = 2* v/g;
            //Double c = (v * dt + (g * Math.Pow(dt, 2) / 2));
            //Double b = v * dt;
            //Double a = (g * Math.Pow(dt, 2) / 2);
            if (v * dt < distance)
                return Double.NaN;
            else
                return 0.5*Math.Asin(distance*g/ Math.Pow(v, 2));
                    // Math.Acos((Math.Sin((distance * g) / Math.Pow(v, 2)))/ (2 * Math.Sin(0.5 * ((distance * g) / Math.Pow(v, 2)))));
		}
	}
}