using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskLibrary
{
    public class LinearInterpolator : Interpolator2D
    {
        public override string ToString()
        {
            return "linear";
        }
        public override KeyFrame Calculate(float timestamp, List<KeyFrame> source)
        {
            if (source.Count == 0 || source.Count < 2) return new KeyFrame();

            KeyFrame result = source[0];

            int neighbor = FindNearKeyFrame(timestamp, source);

            if (neighbor >= 0)
            {
                KeyFrame first = (neighbor == source.Count - 1) ? source[neighbor - 1] : source[neighbor];
                KeyFrame second = (neighbor == source.Count - 1) ? source[neighbor] : source[neighbor + 1];

                Point2D interp_point = Lerp(timestamp, first, second);

                result = new KeyFrame(timestamp, interp_point);
            }

            return result;
        }

        Point2D Lerp(float t, KeyFrame first, KeyFrame second)
        {
            float alpha = (t - first.t) / (second.t - first.t);

            return first.point + (second.point - first.point) * alpha;
        }
    };
}
