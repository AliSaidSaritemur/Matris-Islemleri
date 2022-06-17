/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2014-2015 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:2.Ödev 
**				ÖĞRENCİ ADI............:Ali Said Sarıtemur
**				ÖĞRENCİ NUMARASI.......:G201210044
**              DERSİN ALINDIĞI GRUP...:2B
****************************************************************************/

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

namespace Odovdenme3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string islem;
        string path = "kayit.txt";
        float[,] matris1 = new float[4, 4];
        float[,] matris2 = new float[4, 4];
        float[,] matrisonuc = new float[4, 4];
        //Matris 1 ve 2'deki değerler iki boyutlu dizilere aktarılıyor
        public void Tanımlama()
        {
            matris1[1, 1] = float.Parse(txtMatris1.Text);
            matris1[2, 1] = float.Parse(txtMatris2.Text);
            matris1[3, 1] = float.Parse(txtMatris3.Text);
            matris1[1, 2] = float.Parse(txtMatris4.Text);
            matris1[2, 2] = float.Parse(txtMatris5.Text);
            matris1[3, 2] = float.Parse(txtMatris6.Text);
            matris1[1, 3] = float.Parse(txtMatris7.Text);
            matris1[2, 3] = float.Parse(txtMatris8.Text);
            matris1[3, 3] = float.Parse(txtMatris9.Text);

            matris2[1, 1] = float.Parse(txtMatris_1.Text);
            matris2[2, 1] = float.Parse(txtMatris_2.Text);
            matris2[3, 1] = float.Parse(txtMatris_3.Text);
            matris2[1, 2] = float.Parse(txtMatris_4.Text);
            matris2[2, 2] = float.Parse(txtMatris_5.Text);
            matris2[3, 2] = float.Parse(txtMatris_6.Text);
            matris2[1, 3] = float.Parse(txtMatris_7.Text);
            matris2[2, 3] = float.Parse(txtMatris_8.Text);
            matris2[3, 3] = float.Parse(txtMatris_9.Text);
        }
        //Sonuc 2 boyutlu bir diziye aktarılıyor
        public void Sonuc()
        {
            lblMatris1.Text = matrisonuc[1, 1].ToString();
            lblMatris2.Text = matrisonuc[2, 1].ToString();
            lblMatris3.Text = matrisonuc[3, 1].ToString();
            lblMatris4.Text = matrisonuc[1, 2].ToString();
            lblMatris5.Text = matrisonuc[2, 2].ToString();
            lblMatris6.Text = matrisonuc[3, 2].ToString();
            lblMatris7.Text = matrisonuc[1, 3].ToString();
            lblMatris8.Text = matrisonuc[2, 3].ToString();
            lblMatris9.Text = matrisonuc[3, 3].ToString();
        }

        public void Toplama()
        {
            islem = "Toplama";
            //Matris1 ve Matris2 de aynı konumda bulunan değerler toplanıyor
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    matrisonuc[i, j] = matris1[i, j] + matris2[i, j];
                }
            }
        }
        public void Carpma()
        {
            islem = "Carpma";
            //Matrisin çarpma kuralı uygulanarak Sonuç Matrisinin değerleri belirleniyor
            for (int i = 0; i <= 3; i++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    matrisonuc[i, j] = matris1[1, j] * matris2[i, 1] + matris1[2, j] * matris2[i, 2] + matris1[3, j] * matris2[i, 3];
                }

            }
        }
        public void TersiniBulma()
        {
            islem = "Tersini Bulma";
            float determinant;
            //Determinant bulunuyor
            List<int> sayı = new List<int>();
            determinant = matris1[1, 1] * matris1[2, 2] * matris1[3, 3] + matris1[1, 2] * matris1[2, 3] * matris1[3, 1]
                + matris1[1, 3] * matris1[2, 1] * matris1[3, 2] - matris1[1, 3] * matris1[2, 2] * matris1[3, 1]
                - matris1[1, 1] * matris1[2, 3] * matris1[3, 2] - matris1[1, 2] * matris1[2, 1] * matris1[3, 3];
            //Determinant sıfırken Matrisin tersi alınamadığından kullanıcıya uyarı bildirimi gönderiliyor
            if (determinant == 0) MessageBox.Show("Matrisin determinantı sıfır, dolayısıyla matrisin tersi yoktur");
            //Matrisin tersi bulunuyor
            else
            {
                matrisonuc[1, 1] = (matris1[2, 2] * matris1[3, 3] - matris1[2, 3] * matris1[3, 2]) / determinant;
                matrisonuc[1, 2] = (matris1[1, 2] * matris1[3, 3] - matris1[2, 3] * matris1[3, 1]) / determinant * (-1);
                matrisonuc[1, 3] = (matris1[1, 2] * matris1[2, 3] - matris1[2, 2] * matris1[1, 3]) / determinant;
                matrisonuc[2, 1] = (matris1[2, 1] * matris1[3, 3] - matris1[3, 1] * matris1[2, 3]) / determinant * (-1);
                matrisonuc[2, 2] = (matris1[1, 1] * matris1[3, 3] - matris1[3, 1] * matris1[1, 3]) / determinant;
                matrisonuc[2, 3] = (matris1[1, 1] * matris1[2, 3] - matris1[2, 1] * matris1[1, 3]) / determinant * (-1);
                matrisonuc[3, 1] = (matris1[2, 1] * matris1[3, 2] - matris1[3, 1] * matris1[2, 2]) / determinant;
                matrisonuc[3, 2] = (matris1[1, 1] * matris1[3, 2] - matris1[3, 1] * matris1[1, 2]) / determinant * (-1);
                matrisonuc[3, 3] = (matris1[1, 1] * matris1[2, 2] - matris1[2, 1] * matris1[1, 2]) / determinant;
            }
        }
        public void TranspozeAlma()
        {
            islem = "Transpoze Alma";
            //Matris1 deki blokların yerlerideğiştirlierek Sonuç Matrisinin blokları bulunuyor
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    matrisonuc[i, j] = matris1[j, i];
                }

            }
        }
        public void IziBulma()
        {
            islem = "Izi Bulma";
            //Matrisin izi bulunuyor
            var lblSonuc = new Label();
            matrisonuc[2, 2] = matris1[1, 1] + matris1[2, 2] + matris1[3, 3];
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtMatris1.Text = 0.ToString();
            txtMatris2.Text = 0.ToString();
            txtMatris3.Text = 0.ToString();
            txtMatris4.Text = 0.ToString();
            txtMatris5.Text = 0.ToString();
            txtMatris6.Text = 0.ToString();
            txtMatris7.Text = 0.ToString();
            txtMatris8.Text = 0.ToString();
            txtMatris9.Text = 0.ToString();
        }

        private void btnTemizle2_Click(object sender, EventArgs e)
        {
            txtMatris_1.Text = 0.ToString();
            txtMatris_2.Text = 0.ToString();
            txtMatris_3.Text = 0.ToString();
            txtMatris_4.Text = 0.ToString();
            txtMatris_5.Text = 0.ToString();
            txtMatris_6.Text = 0.ToString();
            txtMatris_7.Text = 0.ToString();
            txtMatris_8.Text = 0.ToString();
            txtMatris_9.Text = 0.ToString();
        }

        public void SonucuTemizle()
        {
            //İşlemin sonuçları temizleniyor
            matrisonuc[1, 1] = 0;
            matrisonuc[2, 1] = 0;
            matrisonuc[3, 1] = 0;
            matrisonuc[1, 2] = 0;
            matrisonuc[2, 2] = 0;
            matrisonuc[3, 2] = 0;
            matrisonuc[1, 3] = 0;
            matrisonuc[2, 3] = 0;
            matrisonuc[3, 3] = 0;
        }

        public void DosyaYazma()
        {
            File.AppendAllText(path, Environment.NewLine);
            File.AppendAllText(path, "1.Matris   \t 2.Matris    \t Sonuç");
            //Text dosyasına aktarım yapılıyor
            for (int j = 1; j <= 3; j++)
            {
                File.AppendAllText(path, Environment.NewLine);
                File.AppendAllText(path, "|" + matris1[1, j].ToString() + "|  |" + matris1[2, j].ToString() + "| | " + matris1[3, j].ToString() + "| \t| " +
                         matris2[1, j].ToString() + "|  |" + matris2[2, j].ToString() + "|  |" + matris2[3, j].ToString() + "| \t |" +
                         matrisonuc[1, j].ToString() + "|  |" + matrisonuc[2, j].ToString() + "|  |" + matrisonuc[3, j].ToString() + "|");

            }
            File.AppendAllText(path, Environment.NewLine + "Yapılan islem:" + islem + Environment.NewLine);
            File.AppendAllText(path, "----------------------------------------------------------------------------------");
        }


        private void btnHesapla_Click(object sender, EventArgs e)
        {
            SonucuTemizle();
            Tanımlama();
            if (rdbToplama.Checked) Toplama();
            else if (rdbCarpma.Checked) Carpma();
            else if (rdbTersiniAlma.Checked) TersiniBulma();
            else if (rdbTranspozeAlma.Checked) TranspozeAlma();
            else if (rdbIziBulma.Checked) IziBulma();
            Sonuc();
            //İsteğe bağlı dosyalar kaydediliyor
            if (cbIslemKayit.Checked) DosyaYazma();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnKayitlar_Click(object sender, EventArgs e)
        {
            //Kayıtlar gösteriliyor
            string metin = File.ReadAllText(path);
            rtbKayitlar.Text = metin;
        }
    }
}
