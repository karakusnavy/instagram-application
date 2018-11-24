using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstagramDenemesi
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
        private void button1_Click(object sender, EventArgs e)
        {
            WebRequest SiteyeBaglantiTalebi = HttpWebRequest.Create("https://www.instagram.com/"+textBox1.Text);
            WebResponse GelenCevap = SiteyeBaglantiTalebi.GetResponse();
            StreamReader CevapOku = new StreamReader(GelenCevap.GetResponseStream());
            string KaynakKodlar = CevapOku.ReadToEnd();
            int IcerikBaslangicIndex = KaynakKodlar.IndexOf("og:descriptio") + 25;
            int IcerikBitisIndex = KaynakKodlar.Substring(IcerikBaslangicIndex).IndexOf("Followers") - 1;
            string a = KaynakKodlar.Substring(IcerikBaslangicIndex, IcerikBitisIndex);
            label8.Text = a;
            //------------------------------------
            label6.Text = textBox1.Text;
            //------------------------------------
            int IcerikBaslangicIndex2 = KaynakKodlar.IndexOf("Followers,") + 11;
            int IcerikBitisIndex2 = KaynakKodlar.Substring(IcerikBaslangicIndex2).IndexOf("Following,") - 1;
            string b = KaynakKodlar.Substring(IcerikBaslangicIndex2, IcerikBitisIndex2);
            label9.Text = b;
            //------------------------------------
            int IcerikBaslangicIndex3 = KaynakKodlar.IndexOf("Following,") + 11;
            int IcerikBitisIndex3 = KaynakKodlar.Substring(IcerikBaslangicIndex3).IndexOf("Posts") - 1;
            string c = KaynakKodlar.Substring(IcerikBaslangicIndex3, IcerikBitisIndex3);
            label7.Text = c;            
        }
    }
}
