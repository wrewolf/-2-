using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace h2b
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK)
            {
                System.IO.StreamReader file = new System.IO.StreamReader(openFileDialog1.FileName);
                String line = file.ReadLine();
                if (line != null)
                {
                    button1.Text = "Converting";
                    try
                    {
                        var b = StringToByteArray(line);
                        BinaryWriter writer = new BinaryWriter(File.Open(openFileDialog1.FileName + ".bin", FileMode.CreateNew));
                        try
                        {
                            writer.Write(b);
                            writer.Flush();
                        }
                        finally
                        {
                            writer.Close();
                        }
                    }
                    catch (Exception)
                    {
                        button1.Text = "File error";
                    }

                    button1.Text = "Converted";
                }
                else
                {
                    button1.Text = "File empty";
                }
            }
        }
        // http://stackoverflow.com/a/321404
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
