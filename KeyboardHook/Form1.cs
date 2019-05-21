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

namespace KeyboardHook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        GlobalKeyboardHook gHook;
        //string loc = @"C:\Users\mille\Desktop\KeyboardHook\file.txt";
        //StreamWriter writer = new StreamWriter(@"C:\Users\mille\Desktop\KeyboardHook\file.txt", true);
        private void Form1_Load(object sender, EventArgs e)
        {
            /*gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);*/


        }
        bool mouse = false;
        bool toggle = true;

       /* private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            label2.Text = " Test";
            if (e.Control && (e.KeyCode).ToString() == "S")
            {
                if (toggle)
                {
                    label2.Text = "Press the A, S and D key to save and exit";
                    using (StreamWriter writer = File.AppendText(@"C:\Users\mille\Desktop\316KeyboardHook\file.txt"))
                    {
                        writer.WriteLine(txt);
                    }
                    toggle = false;
                }
                else
                {
                    label2.Text = "Not writing to file";
                    toggle = true;
                }
            }

         }*/
        string txt;
        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            if (!mouse)
            {
                textBox1.Text += ((char)e.KeyValue).ToString();
                txt = ((char)e.KeyValue).ToString();


                
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
           
           
            }
            //string txt = textBox1.Text;


            //writer.WriteLine(txt );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
            gHook.hook();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gHook.unhook();

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            gHook.unhook();
        }




        [DllImport("user32.dll", EntryPoint = "SetCursorPos")] private static extern bool SetCursorPos(int x, int y);

        [DllImport("user32.dll"),] static extern bool GetCursorPos(out POINT lpPoint);

        private void button3_Click(object sender, EventArgs e)
        {
            if(mouse)
            {
                mouse = false;
                label1.Visible = false;
            }
            else
            {
                mouse = true;
                label1.Visible = true;
            }
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            label2.Text = " Test";
            //e.ToString() == "¢" && (e).ToString() == "S"
            if (e.Control.ToString() == "¢" && (e.KeyCode).ToString() == "S")
            {
                if (toggle)
                {
                    label2.Text = "Press the A, S and D key to save and exit";
                    using (StreamWriter writer = File.AppendText(@"C:\Users\mille\Desktop\316KeyboardHook\file.txt"))
                    {
                        writer.WriteLine(txt);
                    }
                    toggle = false;
                }
                else
                {
                    label2.Text = "Not writing to file";
                    toggle = true;
                }
            }
        }

       /* private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label2.Text = " Test";
            if (e.ToString() == "¢" && (e).ToString() == "S")
            {
                if (toggle)
                {
                    label2.Text = "Press the A, S and D key to save and exit";
                    using (StreamWriter writer = File.AppendText(@"C:\Users\mille\Desktop\316KeyboardHook\file.txt"))
                    {
                        writer.WriteLine(txt);
                    }
                    toggle = false;
                }
                else
                {
                    label2.Text = "Not writing to file";
                    toggle = true;
                }
            }
        }*/
    }
}

