using System;

namespace Billiards
{
    public static class BilliardsTask
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directionRadians">Угол направелния движения шара</param>
        /// <param name="wallInclinationRadians">Угол</param>
        /// <returns></returns>
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            //TODO
            wallInclinationRadians =90+ (wallInclinationRadians * 180/Math.PI); //ToGradus
            directionRadians =180+ (directionRadians * 180 / Math.PI);          //ToGradus
            double angle = directionRadians+(2*(wallInclinationRadians - directionRadians)+360*5);
            angle %= 360;
            return (angle * Math.PI) / 180;
        }
    }
}