using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public partial class AppForm : Form
    {
        List<Node> nodes = new List<Node>();
        
        public AppForm()
        {
            InitializeComponent();

            Logger.log = this.Log;

            AddInterpolator( new LinearInterpolator2D() );
            AddInterpolator( new QuadraticInterpolator2D() );
            AddInterpolator( new CubicInterpolator2D() );

            SaveButton.Enabled = false;
        }

        private void Calculate()
        {
        }

        private void AddInterpolator(Interpolator2D interpolator)
        {
            Interpolator2D.interpolators.Add(interpolator);
        }

        private void defs_file_name_Click(object sender, EventArgs e)
        {
            if (OpenDataDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string data_path = OpenDataDialog.FileName;
            defs_file_name.Text = System.IO.Path.GetFileName(data_path);

            String file_dir = System.IO.Path.GetDirectoryName(data_path);

            Logger.Write(data_path);

            List<string> lines = File.ReadAllLines(data_path).ToList();

            nodes.Clear();

            for (int i = 0; i < lines.Count; i++)
            {
                char[] delimeters = { ' ', ';', '\t' };
                
                String[] triplet = lines[i].Split(delimeters);

                if (triplet.Length == 3)
                {
                    Node node = new Node(triplet[0]);

                    String keyframe_file_path = file_dir + "\\" + triplet[1];

                    if (System.IO.File.Exists(keyframe_file_path))
                    {
                        node.vertex.frames = ParseKeyFrames(keyframe_file_path);
                    }
                    else
                    {
                        Logger.Write("ERROR: can't find path = " + keyframe_file_path);
                    }

                    if (node.vertex.frames.Count > 0)
                    {
                        node.vertex.current_keyframe = node.vertex.frames[0];
                        nodes.Add(node);
                    }
                }
                else
                {
                    Logger.Write("ERROR: can't parse at line " + i + ", expected three values");
                }
            }
        }

        private List<KeyFrame> ParseKeyFrames(String filename)
        {
            List<KeyFrame> keyframes = new List<KeyFrame>();

            Logger.Write(filename);

            List<string> lines = File.ReadAllLines(filename).ToList();

            keyframes.Clear();

            for (int i = 0; i < lines.Count; i++)
            {
                char[] delimeters = { ' ', ';', '\t' };

                String[] triplet = lines[i].Split(delimeters);

                if (triplet.Length == 3)
                {
                    float t, x, y;

                    if (float.TryParse(triplet[0], out t) && float.TryParse(triplet[1], out x) && float.TryParse(triplet[2], out y))
                    {
                        keyframes.Add(new KeyFrame(t, x, y));
                    }
                    else
                    {
                        Logger.Write("ERROR: can't parse at line " + i + ", \"" + lines[i] + "\"");
                    }
                }
                else
                {
                    Logger.Write("ERROR: can't parse at line " + i + ", expected three values");
                }
            }

            return keyframes;
        }

        private void hierarchy_file_name_Click(object sender, EventArgs e)
        {
            if (OpenDataDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string args_path = OpenDataDialog.FileName;
            hierarchy_file_name.Text = System.IO.Path.GetFileName(args_path);

            Logger.Write(args_path);

            List<string> lines = File.ReadAllLines(args_path).ToList();


            for (int i = 0; i < lines.Count; i++)
            {
                var rx = new System.Text.RegularExpressions.Regex(" -> ");

                String[] pair = rx.Split(lines[i]);

                if (pair.Length == 2)
                {
                    Node parent_node = nodes.Find(p => p.name == pair[0]);
                    Node child_node = nodes.Find(p => p.name == pair[1]);

                    if (parent_node != null && child_node != null)
                    {
                        child_node.parent = parent_node;
                    }
                }
                else
                {
                    Logger.Write("ERROR: can't parse at line " + i + ", expected two values");
                }
            }
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            float t = 0.0f;

            if( !float.TryParse(TextBox_CurrentTime.Text, out t) )
            {
                Logger.Write("ERROR: can't parse time = " + TextBox_CurrentTime.Text);
            }

            t = 2.0f;

            foreach (Node node in nodes)
            {
                node.CalculatePosition(t);
            }

            Logger.Write("Calculated");
            SaveButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveDataDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string path = SaveDataDialog.FileName;

            Logger.Write(path);


            String lines = "" + nodes.Count; 

            foreach (Node node in nodes)
            {
                lines += "\n" + node.GlobalToString(" ");
            }

            File.WriteAllText(path, lines);
        }

        private void TextBox_CurrentTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && TextBox_CurrentTime.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

    }


    public static class Logger
    {
        public static TextBox log;

        public static void Write( String line )
        {
            if(log != null)
            {
                log.AppendText(line + "\n");
            }
        }
    }

}
