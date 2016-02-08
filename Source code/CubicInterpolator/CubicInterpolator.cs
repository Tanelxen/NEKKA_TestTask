using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskLibrary
{
    public class CubicInterpolator : Interpolator2D
    {
        public override string ToString()
        {
            return "cubic";
        }
        public override KeyFrame Calculate(float timestamp, List<KeyFrame> source)
        {
            if (source.Count == 0 || source.Count < 4) return new KeyFrame();

            KeyFrame result = source[0];

            int neighbor = FindNearKeyFrame(timestamp, source);

            if (neighbor >= 0 && neighbor < (source.Count - 1))
            {
                Point2D P0 = (neighbor == 0) ? source[neighbor].point : source[neighbor - 1].point;
                Point2D P1 = source[neighbor].point;
                Point2D P2 = source[neighbor + 1].point;
                Point2D P3 = (neighbor + 2 > source.Count - 1) ? source[neighbor + 1].point : source[neighbor + 2].point;

                float dt = (timestamp - source[neighbor].t) / (source[neighbor + 1].t - source[neighbor].t);

                Point2D interp_point = HermiteInterpolate(dt, P0, P1, P2, P3);

                result = new KeyFrame(timestamp, interp_point);
            }

            return result;
        }
        Point2D HermiteInterpolate(float t, Point2D P0, Point2D P1, Point2D P2, Point2D P3)
        {
            Point2D m0 = (P1 - P0) * (1 + bias) * (1 - tension) * 0.5f + (P2 - P1) * (1 - bias) * (1 - tension) * 0.5f;
            Point2D m1 = (P2 - P1) * (1 + bias) * (1 - tension) * 0.5f + (P3 - P2) * (1 - bias) * (1 - tension) * 0.5f;

            float mu2 = t * t;
            float mu3 = mu2 * t;

            float a0 = 2 * mu3 - 3 * mu2 + 1;
            float a1 = mu3 - 2 * mu2 + t;
            float a2 = mu3 - mu2;
            float a3 = -2 * mu3 + 3 * mu2;

            return (a0 * P1 + a1 * m0 + a2 * m1 + a3 * P2);
        }

        public float tension = 0.5f;
        public float bias = 0.5f;
    }
}
