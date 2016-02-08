using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TestTaskLibrary
{
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
        public static void LoadPlugins()
        {
            Logger.Write("Start load plugins...");
            
            string[] files = System.IO.Directory.GetFiles("plugins", "*.dll");

            foreach (string name in files)
            {
                Assembly asm = Assembly.LoadFrom(name);

                foreach (Type t in asm.GetExportedTypes())
                {
                    if (typeof(Interpolator2D).IsAssignableFrom(t))
                    {
                        Interpolator2D interp = (Interpolator2D)asm.CreateInstance(t.FullName);
                        interpolators.Add(interp);

                        Logger.Write("----> : [" + interp.ToString() + "] is loaded");
                    }
                }
            }
        }
        public static Interpolator2D GetByName(String name)
        {
            Interpolator2D interp = interpolators.Find(p => p.ToString() == name);

            if (interp == null && interpolators.Count > 0)
            {
                interp = interpolators[0];
            }

            return interp;
        }

        public static List<Interpolator2D> interpolators = new List<Interpolator2D>();
    };
}
