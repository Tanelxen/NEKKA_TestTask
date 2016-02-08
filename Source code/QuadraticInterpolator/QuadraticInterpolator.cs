using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskLibrary
{
    public class QuadraticInterpolator : Interpolator2D
    {
        public override string ToString()
        {
            return "quadratic";
        }
        public override KeyFrame Calculate(float timestamp, List<KeyFrame> source)
        {
            if (source.Count == 0 || source.Count < 3) return new KeyFrame();

            KeyFrame result = source[0];

            int neighbor = FindNearKeyFrame(timestamp, source);

            if (neighbor >= 0 && neighbor < (source.Count - 1))
            {
                KeyFrame first = new KeyFrame();
                KeyFrame second = new KeyFrame();
                KeyFrame third = new KeyFrame();

                if (neighbor == 0)
                {
                    first = source[0];
                    second = source[1];
                    third = source[2];
                }
                else if (neighbor == source.Count - 1)
                {
                    first = source[source.Count - 3];
                    second = source[source.Count - 2];
                    third = source[source.Count - 1];
                }
                else if (neighbor > 0)
                {
                    first = source[neighbor - 1];
                    second = source[neighbor];
                    third = source[neighbor + 1];
                }

                Point2D interp_point = Quadratic(timestamp, first, second, third);

                result = new KeyFrame(timestamp, interp_point);
            }

            return result;
        }

        Point2D Quadratic(float t, KeyFrame first, KeyFrame second, KeyFrame third)
        {
            float dt0 = (first.t - second.t) * (first.t - third.t);
            float dt1 = (second.t - first.t) * (second.t - third.t);
            float dt2 = (third.t - first.t) * (third.t - second.t);

            Point2D p0 = first.point * ((t - second.t) * (t - third.t)) / dt0;
            Point2D p1 = second.point * ((t - first.t) * (t - third.t)) / dt1;
            Point2D p2 = third.point * ((t - first.t) * (t - second.t)) / dt2;

            return p0 + p1 + p2;
        }
    }
}
