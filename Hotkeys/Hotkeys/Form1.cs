using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace Hotkeys
{
    public partial class Form1 : Form
    {
        public static Form1 Current;

        public Form1()
        {
            InitializeComponent();
            //Current = this;
           
        }
        GlobalKeyboardHook gHook;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode.ToString() == "S")
            {
                label3.Text = "werk";
            }
            // Form1.Current.Focus();
        }

        bool mouse = false;
        bool toggle = true;


        string txt;
        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
           // Form1.Current.Focus();
            if (e.Control && e.Shift && e.KeyCode.ToString() == "S")
            {
                label3.Text = "fok";
            }
          // Form1.Current.Focus();
            if (!mouse)
            {
                textBox1.Text += ((char)e.KeyValue).ToString();
                txt = ((char)e.KeyValue).ToString();
                using (StreamWriter writer = File.AppendText(@"C:\Users\mille\source\repos\Hotkeys\file.txt"))
                {
                    writer.WriteLine(txt);
                }
                toggle = false;


            }
            else
            {
                POINT point;
                if (GetCursorPos(out point))
                {
                    if (e.KeyCode.ToString() == "W")
                    {

                        SetCursorPos(point.X, point.Y - 20);
                    }

                    if (e.KeyCode.ToString() == "A")
                    {

                        SetCursorPos(point.X - 20, point.Y);
                    }

                    if (e.KeyCode.ToString() == "S")
                    {
                        SetCursorPos(point.X, point.Y + 20);
                    }

                    if (e.KeyCode.ToString() == "D")
                    {

                        SetCursorPos(point.X + 20, point.Y);
                    }
                }

                //Form1.Current.Focus();
            }
            
        }
            //string txt = textBox1.Text;


            //writer.WriteLine(txt );
        


        [DllImport("user32.dll", EntryPoint = "SetCursorPos")] private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll"),] static extern bool GetCursorPos(out POINT lpPoint);


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            gHook.HookedKeys.Add(key);
            gHook.hook();
           // Form1.Current.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gHook.unhook();
            //Form1.Current.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (mouse)
            {
                mouse = false;
                label1.Visible = false;
            }
            else
            {
                mouse = true;
                label1.Visible = true;
            }
           // Form1.Current.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }
    }
    }

