using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskLibrary
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
        public static Point2D operator +(Point2D obj1, Point2D obj2)
        {
            Point2D result = new Point2D();
            result.x = obj1.x + obj2.x;
            result.y = obj1.y + obj2.y;
            return result;
        }
        public static Point2D operator -(Point2D obj1, Point2D obj2)
        {
            Point2D result = new Point2D();
            result.x = obj1.x - obj2.x;
            result.y = obj1.y - obj2.y;
            return result;
        }
        public static Point2D operator *(Point2D obj, float mul)
        {
            Point2D result = new Point2D();
            result.x = obj.x * mul;
            result.y = obj.y * mul;
            return result;
        }
        public static Point2D operator *(float mul, Point2D obj)
        {
            Point2D result = new Point2D();
            result.x = obj.x * mul;
            result.y = obj.y * mul;
            return result;
        }
        public static Point2D operator /(Point2D obj, float div)
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
}
