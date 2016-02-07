using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskLibrary
{
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
}
