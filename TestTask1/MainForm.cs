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
        List<KeyFrame> keyframes = new List<KeyFrame>();
        List<float> timeline = new List<float>();

        List<KeyFrame> trajectory = new List<KeyFrame>();

        int current_interp_index = -1;
        
        public AppForm()
        {
            InitializeComponent();

            AddInterpolator( new LinearInterpolator2D() );
            AddInterpolator( new QuadraticInterpolator2D() );
            AddInterpolator( new CubicInterpolator2D() );

            SaveButton.Enabled = false;
        }

        private void Calculate()
        {
            if (keyframes.Count == 0 || timeline.Count == 0) return;

            current_interp_index = InterpolatorsComboBox.SelectedIndex;

            Interpolator2D interpolator = (Interpolator2D)InterpolatorsComboBox.SelectedItem;

            trajectory.Clear();

            SaveButton.Enabled = false;


            foreach( float timestamp in timeline )
            {
                trajectory.Add(interpolator.Calculate(timestamp, keyframes));
            }

            if( trajectory.Count > 0 )
            {
                Log.AppendText("Calculated\n");
                SaveButton.Enabled = true;
            }
        }

        private void AddInterpolator(Interpolator2D interpolator)
        {
            InterpolatorsComboBox.Items.Add( interpolator );
            InterpolatorsComboBox.SelectedIndex = 0;
        }

        private void data_file_name_Click(object sender, EventArgs e)
        {
            if (OpenDataDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string data_path = OpenDataDialog.FileName;
            data_file_name.Text = System.IO.Path.GetFileName(data_path);

            Log.AppendText(data_path + "\n");

            List<string> lines = File.ReadAllLines(data_path).ToList();

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
                        Log.AppendText("ERROR: can't parse at line " + i + ", \"" + lines[i] + "\"" + "\n");
                    }
                }
                else
                {
                    Log.AppendText("ERROR: can't parse at line " + i + ", expected three values\n");
                }
            }
        }

        private void args_file_name_Click(object sender, EventArgs e)
        {
            if (OpenDataDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string args_path = OpenDataDialog.FileName;
            args_file_name.Text = System.IO.Path.GetFileName(args_path);

            Log.AppendText(args_path + "\n");

            List<string> lines = File.ReadAllLines(args_path).ToList();

            timeline.Clear();

            for (int i = 0; i < lines.Count; i++)
            {
                float t;

                if (float.TryParse(lines[i], out t))
                {
                    timeline.Add(t);
                }
                else
                {
                    Log.AppendText("ERROR: can't parse at line " + i + ", \"" + lines[i] + "\"" + "\n");
                }
            }

            if( keyframes.Count > 0 || timeline.Count > 0 )
            {
                Calculate();
            }
        }

        private void InterpolatorsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( current_interp_index != InterpolatorsComboBox.SelectedIndex )
            {
                Calculate();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaveDataDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string path = SaveDataDialog.FileName;

            Log.AppendText(path + "\n");

            
            String lines = ""; // = trajectory.Count + "\n";

            for (int i = 0; i < trajectory.Count; i++)
            {
                lines += trajectory[i].ToString(" ") + "\n";
            }

            File.WriteAllText(path, lines);
        }

    }


}
