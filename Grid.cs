using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDemoForm
{
    public partial class Grid : Form
    {
        public Grid()
        {
            InitializeComponent();
        }
       private void SetRichtxt(string message, Color fontcolor)
        {
            int firstlength = rtxt.TextLength;
            rtxt.AppendText(message);
            rtxt.Select(firstlength, message.Length);
            rtxt.SelectionColor = fontcolor;
            rtxt.AppendText("\r");
            rtxt.ScrollToCaret();
        }

       private void button2_Click(object sender, EventArgs e)
       {
           SetRichtxt(dateTimePicker1.Value.ToString("hh:mm:ss"), Color.SaddleBrown);
       }

       private void button3_Click(object sender, EventArgs e)
       {
           SetRichtxt(dateTimePicker2.Value.ToString(), Color.Brown);
       }

       private void colorpick_Click(object sender, EventArgs e)
       {
           ColorDialog cd = new ColorDialog();
           cd.ShowDialog();
           lblcolor.BackColor = cd.Color;
       }
       private void ChangeColor()
       {
           Bitmap bt = new Bitmap(picbox.Width, picbox.Height);
           Graphics g = Graphics.FromImage(bt);
           g.FillRectangle(new SolidBrush(Color.FromArgb(intA.Value, intR.Value, intG.Value, intB.Value)), 0, 0, picbox.Width, picbox.Height);
           g.DrawString("R:"+intR.Value,new Font(new FontFamily("Consolas"),12),new SolidBrush(Color.Red),10,5);
           g.DrawString("G:" + intG.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(Color.Red), 10, 23);
           g.DrawString("B:" + intB.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(Color.Red), 10, 41);
           g.DrawString("A:" + intA.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(Color.Red), 10, 60);
           picbox.Image = bt;
       }

       private void intR_Scroll(object sender, EventArgs e)
       {
           ChangeColor();
       }

       private void intG_Scroll(object sender, EventArgs e)
       {
           ChangeColor();
       }

       private void intB_Scroll(object sender, EventArgs e)
       {
           ChangeColor();
       }

       private void inta_Scroll(object sender, EventArgs e)
       {
           ChangeColor();
       }

       private void btCopy_Click(object sender, EventArgs e)
       {
           Clipboard.SetDataObject("Color.FromArgb("+intA.Value+","+intR.Value+","+intG.Value+","+intB.Value+")");
       }

       private void Grid_Load(object sender, EventArgs e)
       {
           intA.Value = 125;
       }
    }

}
