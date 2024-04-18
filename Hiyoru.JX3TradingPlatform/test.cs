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

namespace Hiyoru.JX3TradingPlatform
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();

            //string imagePath = Path.Combine(Application.StartupPath, @"\Picture\123.jpg");
            string imagePath = Application.StartupPath + @"\..\..\..\Picture\123.jpg";
            if (File.Exists(imagePath)) { this.pictureBox2.Image = Image.FromFile(imagePath); }

            //this.pictureBox2.Image = Image.FromFile(@"C:\Users\ispan\Desktop\專題資料表\Hiyoru.JX3TradingPlatform\Hiyoru.JX3TradingPlatform\Picture\123.jpg");

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string imagePath1 = Application.StartupPath;
            
            MessageBox.Show(imagePath1);
        }
    }
}
