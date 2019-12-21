﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Resim Dosyaları|" + "*.bmp;*.jpg;*.gif;*.wmf;*.tif;*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }            


        }

        Bitmap dondurme(Bitmap resim3)
        {

            resim3.RotateFlip(RotateFlipType.Rotate90FlipNone);
            
            return resim3;

        }

        
        Bitmap NegatifYap(Bitmap resim4)
        {
            Bitmap yeniresimNg = new Bitmap(resim4.Width, resim4.Height);

            for(int i=0;i<yeniresimNg.Width;i++)
            {
                for(int j=0;j<yeniresimNg.Height;j++)
                {

                    Color renkNg = resim4.GetPixel(i, j);
                    yeniresimNg.SetPixel(i,j,Color.FromArgb(255-renkNg.R,255-renkNg.G,255-renkNg.B));
                }

            }

            return yeniresimNg;

        }

        Bitmap aynalama1(Bitmap resim22)
        {
            Bitmap yeniresim2 = new Bitmap(resim22.Width, resim22.Height);

            for(int i=0;i<resim22.Width;i++)
            {

                for(int j=0;j<resim22.Height;j++)
                {

                    Color renk1 = resim22.GetPixel(i, j);
                    yeniresim2.SetPixel(yeniresim2.Width-i-1, j, Color.FromArgb(renk1.R, renk1.G, renk1.B));

                }

            }

            return yeniresim2;

        }


        private void PixelYaz(Bitmap resim33)
        {
            for (int i = 0; i < resim33.Width; i++)
            {

                for (int j = 0; j < resim33.Height; j++)
                {

                    Color renk1 = resim33.GetPixel(i, j);

                    MessageBox.Show(i + "," + j + "pixelinin renk degerleri:" + renk1.R + "," + renk1.G + "," + renk1.B+"\n");
                    

                    

                }

            }

        }


        Bitmap Histogram(Bitmap HResim)
        {

            Bitmap YeniHResim = new Bitmap(HResim.Width, HResim.Height);



            for (int i = 0; i < HResim.Width; i++)
            {
                for (int j = 0; j < HResim.Height; j++)
                {
                    Color HColor = HResim.GetPixel(i, j);
                    YeniHResim.SetPixel(i, j, Color.FromArgb(HColor.R, HColor.G, HColor.B));


                }

            }

            return YeniHResim;



        }


       

            Bitmap Donustur(Bitmap resim)
{
           Bitmap yeniResim = new Bitmap(resim.Width, resim.Height);
                for (int i = 0; i < resim.Width; i++)
                  {
                    for (int j = 0; j < resim.Height; j++)
                       {
               
                   Color renk = resim.GetPixel(i, j);
                   int yeniRenk = (renk.R + renk.G + renk.B) / 3;
                   yeniResim.SetPixel(i, j, Color.FromArgb(yeniRenk, yeniRenk, yeniRenk));
          }
     }
        return yeniResim;



        }




            private void button2_Click(object sender, EventArgs e)
            {
                if (pictureBox1.Image != null)
                    pictureBox2.Image = Donustur(new Bitmap(pictureBox1.Image));

                else
                    MessageBox.Show("Once Resim Acin!");
            }

            private void button3_Click(object sender, EventArgs e)
            {
                if (pictureBox1.Image != null)
                    pictureBox1.Image = dondurme(new Bitmap(pictureBox1.Image));
                 
                else
                    MessageBox.Show("Once Resim Acin");
            }

            private void button4_Click(object sender, EventArgs e)
            {
                if (pictureBox1.Image != null)
                    pictureBox3.Image = aynalama1(new Bitmap(pictureBox1.Image));

                else
                    MessageBox.Show("Once Resim Acin!");
            }

            private void button5_Click(object sender, EventArgs e)
            {
                if (pictureBox1.Image != null)
                    pictureBox4.Image = NegatifYap(new Bitmap(pictureBox1.Image));
                    

                else
                    MessageBox.Show("Once Resim Acin!");
            }

            private void button6_Click(object sender, EventArgs e)
            {
                if(pictureBox1.Image!=null)
                    pictureBox5.Image = aynalama1(new Bitmap(pictureBox1.Image));
                else
                    MessageBox.Show("Once Resim Acin!");
                    
                    
                
            
            }

            private void button7_Click(object sender, EventArgs e)
            {
                PixelYaz(new Bitmap(pictureBox1.Image));

            

            }

            private void button8_Click(object sender, EventArgs e)
            {
                if(pictureBox1.Image!=null)
                {

                    pictureBox6.Size = new System.Drawing.Size(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
                    pictureBox6.Image = pictureBox1.Image;

                    
                }

                else
                    MessageBox.Show("Once Resim Acin!");                

               



            }

            private void button9_Click(object sender, EventArgs e)
            {
                if(pictureBox1.Image!=null)
                {
                    SaveFileDialog Kayit = new SaveFileDialog();


                    Kayit.Filter = "jpeg dosyası(*.jpg)|*.jpg|Bitmap(*.bmp)|*.bmp";


                    if (Kayit.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image.Save(Kayit.FileName);
                    }


                }

                else
                    MessageBox.Show("Once Resim Acin!");





                
            }

            private void button10_Click(object sender, EventArgs e)
            {
                string resimyolu = textBox3.Text;
                pictureBox7.Image = Image.FromFile("D:\\" +resimyolu+ ".jpg");
                
            }
        
            private void button11_Click(object sender, EventArgs e)
            {

                if (pictureBox1.Image != null)
                {
                    Bitmap Hresmim = Histogram(new Bitmap(pictureBox1.Image));

                    int[] dizi = new int[Hresmim.Width * Hresmim.Height];
                    int[] dizi2 = new int[Hresmim.Width * Hresmim.Height];

                    int s = 0;



                    for (int i = 0; i < Hresmim.Width; i++)
                    {
                        for (int j = 0; j < Hresmim.Height; j++)
                        {
                            Color HColor = Hresmim.GetPixel(i, j);

                            dizi[s] = s;
                            dizi2[s] = (HColor.R + HColor.G + HColor.B);
                            s++;


                        }

                    }

                    chart1.Series["Series1"].Points.DataBindXY(dizi, dizi2);
                    chart1.ChartAreas["ChartArea1"].CursorX.Interval = 1;





                }

                else
                    MessageBox.Show("Once resim acin!");
       

            }

            private void button12_Click(object sender, EventArgs e)
            {

                if (pictureBox2.Image != null)
                {
                    Bitmap Hresmim = Histogram(new Bitmap(pictureBox2.Image));

                    int[] dizi = new int[Hresmim.Width * Hresmim.Height];
                    int[] dizi2 = new int[Hresmim.Width * Hresmim.Height];

                    int s = 0;



                    for (int i = 0; i < Hresmim.Width; i++)
                    {
                        for (int j = 0; j < Hresmim.Height; j++)
                        {
                            Color HColor = Hresmim.GetPixel(i, j);

                            dizi[s] = s;
                            dizi2[s] = ((HColor.R) / 3 + (HColor.G) / 3 + (HColor.B) / 3);
                            s++;


                        }

                    }

                    chart1.Series["Series1"].Points.DataBindXY(dizi, dizi2);
                    chart1.ChartAreas["ChartArea1"].CursorX.Interval = 1;

                }
                else
                    MessageBox.Show("Once resim acin!");


                }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
