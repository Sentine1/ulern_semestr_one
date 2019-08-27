using System;

namespace DistanceTask
{
    public static class DistanceTask
    {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by) 
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
        {
            double ab = (x-ax)*(bx-ax)+(y-ay)*(by-ay);
            ab = (ab / ((bx - ax) * (bx - ax) + ((by - ay) * (by - ay))));
            if (ab < 0 || double.IsNaN(ab))
                ab = 0;
            if (ab > 1)
                ab = 1;
            double xaxbx = (ax - x + ((bx - ax) * ab));
            double yayby = (ay - y + ((by - ay) * ab));
            double hieght =Math.Sqrt((xaxbx * xaxbx) + (yayby * yayby));
            return hieght;
            
        }
    }
}
