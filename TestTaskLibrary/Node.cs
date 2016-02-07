using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskLibrary
{
    public class Node
    {
        public Node(String name)
        {
            this.name = name;
        }
        public string LocalToString(String delimeter = " ")
        {
            return name + delimeter + vertex.local_pos.ToString(delimeter);
        }
        public string GlobalToString(String delimeter = " ")
        {
            return name + delimeter + vertex.global_pos.ToString(delimeter);
        }
        public void CalculatePosition(float timestamp)
        {
            Logger.Write(name + ".CalculatePosition(" + timestamp + ")");

            if (vertex.current_keyframe.t != timestamp)
            {
                Logger.Write("---->: result not cached, calculate");

                Interpolator2D interp = Interpolator2D.GetByName(interpolation);

                if (interp != null)
                {
                    vertex.current_keyframe = interp.Calculate(timestamp, vertex.frames);
                }
                else
                {
                    Logger.Write("---->: can't find Interpolator2D for type: " + interpolation);
                    return;
                }
            }

            vertex.local_pos = vertex.current_keyframe.point;

            if (parent == null)
            {
                Logger.Write("---->: is root node");
                vertex.global_pos = vertex.local_pos;
            }
            else
            {
                Logger.Write("---->: is child node");
                parent.CalculatePosition(timestamp);
                vertex.global_pos = vertex.local_pos + parent.vertex.global_pos;
            }
        }

        public String name;
        public String interpolation = "linear";

        public Vertex vertex = new Vertex();
        public Node parent;
    }

    public class Vertex
    {
        public List<KeyFrame> frames;

        public KeyFrame current_keyframe;

        public Point2D local_pos = new Point2D();
        public Point2D global_pos = new Point2D();
    }
}
