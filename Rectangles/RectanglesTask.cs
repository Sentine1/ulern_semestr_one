using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
       
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
           
            if ((r1.Left > r2.Left + r2.Width) || (r1.Left + r1.Width < r2.Left) || (r1.Top > r2.Top + r2.Height) || (r1.Top + r1.Height < r2.Top))
                return false;
            else return true;
        }
		// Площадь пересечения прямоугольников
		public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (r1.Left <= r2.Left && (r1.Left + r1.Width) >= (r2.Left + r2.Width) && r1.Top <= r2.Top  && (r1.Top + r1.Height) >= (r2.Top + r2.Height))
               return Math.Abs(r2.Height * r2.Width);
            if (r2.Left <= r1.Left && ((r2.Left + r2.Width) >= (r1.Left + r1.Width) )&&( r2.Top <= r1.Top )&&((r2.Top + r2.Height) >= (r1.Top + r1.Height)))
                return Math.Abs(r1.Height * r1.Width);

            if (AreIntersected(r1, r2) && (r1.Left + r1.Height != r2.Left) && (r1.Top + r1.Height != r2.Top) && (r2.Top + r2.Height != r1.Top) && (r2.Left + r2.Width != r1.Left))
                    return Math.Abs(Math.Min(r1.Width+r1.Left,r2.Left+r2.Width)-Math.Max(r1.Left,r2.Left)) * Math.Abs(Math.Min(r2.Top+r2.Height,r1.Top+r1.Height)-Math.Max(r2.Top,r1.Top));
            else return 0;
		}


		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            if (r2.Left <= r1.Left && ((r2.Left + r2.Width) >= (r1.Left + r1.Width)) && (r2.Top <= r1.Top) && ((r2.Top + r2.Height) >= (r1.Top + r1.Height)))
                return 0;
            if (r1.Left <= r2.Left && (r1.Left + r1.Width) >= (r2.Left + r2.Width) && r1.Top <= r2.Top && (r1.Top + r1.Height) >= (r2.Top + r2.Height))
                return 1;
            return -1;
		}
	}
}