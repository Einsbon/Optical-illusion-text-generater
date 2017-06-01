using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optical_illusion_text
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Bitmap DrawIllusionText(string writetext, Font asdfasdf, int heiPercent, int widPercent, int pixel, int sizeX, int sizeY)
        {
            Bitmap mybitmap = new Bitmap(sizeX, sizeY, PixelFormat.Format32bppRgb);
            Graphics backColor = Graphics.FromImage(mybitmap);
            backColor.FillRectangle(Brushes.Khaki, 0, 0, sizeX, sizeY);
            backColor.Dispose();

            writetext = writetext + "-";
            int txtLength = writetext.Length;

            //그래픽 생성 
            Graphics graphics = Graphics.FromImage(mybitmap);

            Font font = asdfasdf;
            Font testFont = new Font(asdfasdf.Name, asdfasdf.Size);

            //폰트 사이즈 재기 measuring font size
            SizeF stringSize = graphics.MeasureString("A", font);

            
            int wid = (int)stringSize.Width;
            int hei = (int)stringSize.Height;

            int heiDistance = hei * heiPercent / 100;
            int widDistance = wid * widPercent / 100;

            int widLetter = sizeX / widDistance;
            int heightLetter = sizeY / heiDistance;

            int letterNumber;

            //검은색 글씨 쓰기 write black letters
            for (int b = 0; b < heightLetter; b++)
            {
                for (int a = 0; a < widLetter; a++)
                {
                    if ((b % 2) == 0)
                    {
                        letterNumber = a % txtLength;
                    }
                    else
                    {
                        letterNumber = (a + txtLength - 1) % txtLength;
                    }
                    switch ((8 + a % 8 - b % 8) % 8)
                    {
                        case 0:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.Black, a * widDistance - widDistance / 10 - pixel, b * heiDistance + heiDistance / 10 + pixel);
                            break;
                        case 1:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.Black, a * widDistance, b * heiDistance + heiDistance / 10 + pixel);
                            break;
                        case 2:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.Black, a * widDistance + widDistance / 10 + pixel, b * heiDistance + heiDistance / 10 + pixel);
                            break;
                        case 3:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.Black, a * widDistance + widDistance / 10 + pixel, b * heiDistance);
                            break;
                        case 4:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.Black, a * widDistance + widDistance / 10 + pixel, b * heiDistance - heiDistance / 10 - pixel);
                            break;
                        case 5:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.Black, a * widDistance, b * heiDistance - heiDistance / 10- pixel);
                            break;
                        case 6:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.Black, a * widDistance - widDistance / 10 - pixel, b * heiDistance - heiDistance / 10 - pixel);
                            break;
                        case 7:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.Black, a * widDistance - widDistance / 10 - pixel, b * heiDistance);
                            break;
                    }
                }
            }

            //하얀색 글씨 쓰기 write white letters
            for (int b = 0; b < heightLetter; b++)
            {
                for (int a = 0; a < widLetter; a++)
                {
                    if ((b % 2) == 0)
                    {
                        letterNumber = a % txtLength;
                    }
                    else
                    {
                        letterNumber = (a + txtLength - 1) % txtLength;
                    }
                    switch ((8 + a % 8 - b % 8) % 8)
                    {
                        case 4:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.White, a * widDistance - widDistance / 10 - pixel, b * heiDistance + heiDistance / 10 + pixel);
                            break;
                        case 5:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.White, a * widDistance, b * heiDistance + heiDistance / 10 + pixel);
                            break;
                        case 6:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.White, a * widDistance + widDistance / 10 + pixel, b * heiDistance + heiDistance / 10 + pixel);
                            break;
                        case 7:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.White, a * widDistance + widDistance / 10 + pixel, b * heiDistance);
                            break;
                        case 0:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.White, a * widDistance + widDistance / 10 + pixel, b * heiDistance - heiDistance / 10 - pixel);
                            break;
                        case 1:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.White, a * widDistance, b * heiDistance - heiDistance / 10 - pixel);
                            break;
                        case 2:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.White, a * widDistance - widDistance / 10 - pixel, b * heiDistance - heiDistance / 10 - pixel);
                            break;
                        case 3:
                            graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.White, a * widDistance - widDistance / 10 - pixel, b * heiDistance);
                            break;
                    }
                }
            }

            //보라색 글씨 쓰기 Write purple letters
            for (int b = 0; b < heightLetter; b++)
            {
                for (int a = 0; a < widLetter; a++)
                {
                    if ((b%2) == 0)
                    {
                        letterNumber = a % txtLength;
                    }
                    else
                    {
                        letterNumber = (a + txtLength - 1) % txtLength;
                    }
                    graphics.DrawString(Convert.ToString(writetext[letterNumber]), font, Brushes.MediumSlateBlue, a * widDistance, b * heiDistance);
                }
            }


            graphics.Dispose();
            return mybitmap;     //return Bitmap Image 
        }

        //이미지 생성 버튼
        //Generate image button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Width = int.Parse(txtWidth.Text);
                pictureBox1.Height = int.Parse(txtHeight.Text);
                if (int.Parse(txtWidth.Text) > 900)
                {
                    this.Width = int.Parse(txtWidth.Text) + 40;
                }
                if (int.Parse(txtHeight.Text) > 900)
                {
                    this.Height = int.Parse(txtHeight.Text) + 223;
                }

                pictureBox1.Image = DrawIllusionText(txtLetter.Text, myfont, Convert.ToInt16(txtHeiPercent.Text), Convert.ToInt16(txtWidPercent.Text), Convert.ToInt16(txtPixel.Text), pictureBox1.Size.Width, pictureBox1.Size.Height);
            }
            catch
            {
                MessageBox.Show("Error");
                return;
            }
        }

        //Save 버튼
        //Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save an Image File";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Filter = "JPEG File(*.jpg)|*.jpg |Bitmap File(*.bmp)|*.bmp |PNG File(*.png)|*.png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                pictureBox1.Image.Save(fileName);
            }
        }

        Font myfont;


        //폰트 선택 버튼 select font button
        private void btnFont_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                myfont = fontDialog1.Font;/*
                myFontName = myfont.Name;
                myFontSize = myfont.Size;*/
                lblFont.Text = "Font: " + myfont.Name;
                lblSize.Text = "Font size: " + Convert.ToString(myfont.Size);
                button1.Enabled = true;
            }
        }
        
        //패널 링크 바로가기
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.LinkData = "http://blog.naver.com/einsbon";
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            e.Link.LinkData = "einsbon@naver.com";
        }

        private void btnMan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("put the letters on the textbox and choose font, and fill another textboxes. And click the create button.");
        }
    }
}
