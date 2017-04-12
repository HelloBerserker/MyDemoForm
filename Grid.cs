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
        public Color fontcolor = Color.Red;
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
        string ColorToHex(int value)
        {

            return null;

        }
       private void ChangeColor()
       {
            if (rdbFontColor.Checked)
            {
                Bitmap bp = new Bitmap(picbox.Width, picbox.Height);
                Graphics graph= Graphics.FromImage(bp);
                fontcolor= Color.FromArgb(intA.Value, intR.Value, intG.Value, intB.Value);
                graph.DrawString("R:" + intR.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(fontcolor), 10, 5);
                graph.DrawString("G:" + intG.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(fontcolor), 10, 23);
                graph.DrawString("B:" + intB.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(fontcolor), 10, 41);
                graph.DrawString("A:" + intA.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(fontcolor), 10, 60);
                graph.DrawString("HEX:" + ColorTranslator.ToHtml(fontcolor), new Font(new FontFamily("Consolas"), 12), new SolidBrush(fontcolor), 10, 78);
                picbox.Image = bp;
                txtshow.ForeColor = fontcolor;
                return;
            }
            txtshow.Clear();
           Bitmap bt = new Bitmap(picbox.Width, picbox.Height);
           Graphics g = Graphics.FromImage(bt);
            Color PickColor = Color.FromArgb(intA.Value, intR.Value, intG.Value, intB.Value);
            picbox.BackColor = PickColor;
           g.FillRectangle(new SolidBrush(PickColor), 0, 0, picbox.Width, picbox.Height);
           g.DrawString("R:"+intR.Value,new Font(new FontFamily("Consolas"),12),new SolidBrush(fontcolor),10,5);
           g.DrawString("G:" + intG.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(fontcolor), 10, 23);
            g.DrawString("B:" + intB.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(fontcolor), 10, 41);
            g.DrawString("A:" + intA.Value, new Font(new FontFamily("Consolas"), 12), new SolidBrush(fontcolor), 10, 60);            
            g.DrawString("HEX:" + ColorTranslator.ToHtml(PickColor), new Font(new FontFamily("Consolas"), 12), new SolidBrush(fontcolor), 10, 78);
            txtshow.AppendText("R:" + intR.Value+ Environment.NewLine);
            txtshow.AppendText("G:" + intG.Value+Environment.NewLine);
            txtshow.AppendText("B:" + intB.Value+ Environment.NewLine);
            txtshow.AppendText("A:" + intA.Value + Environment.NewLine);
            txtshow.AppendText("HEX:" + ColorTranslator.ToHtml(PickColor));
            txtshow.BackColor = ColorTranslator.FromHtml(ColorTranslator.ToHtml(PickColor));
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

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            fontcolor = cd.Color;
            ChangeColor();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string binary = "";
            int value=0;
            try
            {
                value = Convert.ToInt32(txtInput.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                for (int x = 0; x > -1; x++)
                {
                    if (value == 0)
                        break;
                    binary =value% 2+binary;
                    value = value / 2;
                }
                MessageBox.Show(binary);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            MessageBox.Show((5/2).ToString());
        }

        private void rdbFontColor_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
