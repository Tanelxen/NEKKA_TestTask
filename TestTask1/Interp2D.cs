using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpolation
{
    public class Point2D
    {
        public float x;
        public float y;

        public Point2D()
        {
            x = 0.0f;
            y = 0.0f;
        }
        public Point2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public static Point2D operator + (Point2D obj1, Point2D obj2)
        {
            Point2D result = new Point2D();
            result.x = obj1.x + obj2.x;
            result.y = obj1.y + obj2.y;
            return result;
        }
        public static Point2D operator - (Point2D obj1, Point2D obj2)
        {
            Point2D result = new Point2D();
            result.x = obj1.x - obj2.x;
            result.y = obj1.y - obj2.y;
            return result;
        }
        public static Point2D operator * (Point2D obj, float mul)
        {
            Point2D result = new Point2D();
            result.x = obj.x * mul;
            result.y = obj.y * mul;
            return result;
        }
        public static Point2D operator * (float mul, Point2D obj)
        {
            Point2D result = new Point2D();
            result.x = obj.x * mul;
            result.y = obj.y * mul;
            return result;
        }
        public static Point2D operator / (Point2D obj, float div)
        {
            Point2D result = new Point2D();
            result.x = obj.x / div;
            result.y = obj.y / div;
            return result;
        }
        public string ToString(String delimeter = " ")
        {
            return x + delimeter + y;
        }
    }
    
    public class KeyFrame
    {
        public KeyFrame()
        {
            this.t = 0;
        }
        public KeyFrame(float t, float x, float y)
        {
            this.t = t;
            point = new Point2D(x, y);
        }
        public KeyFrame(float t, Point2D point)
        {
            this.t = t;
            this.point = point;
        }
        public string ToString(String delimeter = " ")
        {
            return t + delimeter + point.x + delimeter + point.y;
        }
        
        public float t;
        public Point2D point = new Point2D();
    }

    public class Interpolator2D
    {
        public virtual KeyFrame Calculate(float timestamp, List<KeyFrame> source)
        {
            KeyFrame result = new KeyFrame();
            return result;
        }
        protected int FindNearKeyFrame(float t, List<KeyFrame> source)
        {
            int count = source.Count;

            if (count == 0) return -1;
            if (count == 1) return 0;

            if (t < source[0].t) return -1;
            if (t > source[count - 1].t) return -1;

            if (t == source[count - 1].t) return count - 1;

            int index = -1;

            for (int i = 0; i < count - 1; i++)
            {
                if (t >= source[i].t && t < source[i + 1].t)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    };

    public class LinearInterpolator2D : Interpolator2D
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

    public class QuadraticInterpolator2D : Interpolator2D
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
    };

    public class CubicInterpolator2D : Interpolator2D
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
    };
}
