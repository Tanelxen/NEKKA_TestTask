using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TestTaskLibrary
{
    public static class Logger
    {
        public static TextBox log;

        public static void Write(String line)
        {
            if (log != null)
            {
                log.AppendText(line + "\n");
            }
        }
    }
}
