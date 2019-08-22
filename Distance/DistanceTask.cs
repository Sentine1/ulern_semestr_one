using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            //exp
            double xax = Math.Sqrt((ax-x)*(ax-x)+(ay-y)*(ay-y));
            double bax = Math.Sqrt((bx - x) * (bx - x) + (by - y) * (by - y));
            double ab = Math.Sqrt((ax-bx)*(ax-bx)+(ay-by)* (ay - by));
            //формула ещё из Expr6. Посчитать расстояние от точки до прямой, заданной двумя разными точками.
            double hieght = Math.Abs((by - ay) * x - (bx - ax) * y + (bx * ay - by * ax)) / Math.Sqrt((Math.Pow((by - ay), 2)) + (Math.Pow((bx - ax), 2)));
            if ((ax == x || bx == x) && (ay == y || by == y)) return 0;
             if ((x>Math.Min(ax,bx)&&x<Math.Max(ax,bx)&&x-hieght >= Math.Min(ax, bx) && x-hieght <= Math.Max(ax, bx) )|| (y>Math.Min(ay,by)&&y<Math.Max(ay,by)&& y-hieght >= Math.Min(ay, by) && y-hieght <= Math.Max(ay, by)))
             return hieght;
             else if (xax > bax) return bax;
            else return xax;
        }
    }
}