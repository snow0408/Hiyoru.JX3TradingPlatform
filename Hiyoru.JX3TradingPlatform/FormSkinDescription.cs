using Hiyoru.JX3TradingPlatform.Models.Dto;
using Hiyoru.JX3TradingPlatform.Models.Interfaces;
using Hiyoru.JX3TradingPlatform.Models.Repostories;
using Hiyoru.JX3TradingPlatform.Models.Service;
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
using static System.Net.WebRequestMethods;
using System.Security.Principal;
using Hiyoru.JX3TradingPlatform.Models.Dtos;
using System.Diagnostics;

namespace Hiyoru.JX3TradingPlatform
{
    public partial class FormSkinDescription : Form, IDataContainer, IUpdateOrDeleteContainer
    {
        private readonly int _pk;
        private readonly string _account;
        public FormSkinDescription(string account, int pk)
        {
            _pk = pk;
            _account = account;

            InitializeComponent();

            this.Load += FormSkinDescription_Load;
            this.dataGridViewSell.CellClick += DataGridViewSell_CellClick;
            this.dataGridViewbuy.CellClick += DataGridViewbuy_CellClick;

            this.dataGridViewSell.AutoGenerateColumns = false;
            this.dataGridViewbuy.AutoGenerateColumns = false;

            this.Text = "外觀資訊";
        }



        private void FormSkinDescription_Load(object sender, EventArgs e)
        {
            BindData();
            Display();
        }

        private ISkinRepostory GetRepo()
        {
            return new SkinEFRepostory();
        }
        //顯示商品資訊
        private void BindData()
        {
            SkinDto skinModel = new SkinService(GetRepo()).Get(_pk);

            this.lableSkinName.Text = skinModel.Name;
            this.labelSkinEName.Text = skinModel.EName;
            this.labelLaunchDate.Text = skinModel.LaunchDate.ToString("yyyy/MM/dd");

            string ImagePath = Application.StartupPath + @"\..\..\..\Picture\" + skinModel.PicturePath;
            if (System.IO.File.Exists(ImagePath)) { pictureBox1.BackgroundImage = Image.FromFile(ImagePath); }
        }


        //顯示交易資訊
        private IProductRepostory GetProductRepo()
        {
            return new ProductEFRepostory();
        }
        public void Display()
        {
            DisplayWantProduct();
            DisplayMyProduct();

            var productService = new ProductService(GetProductRepo());
            var maxPri = productService.GetMaxPricePro(this.lableSkinName.Text, 4);//取得最高價
            if (maxPri != null && maxPri != 0) { this.labelMaxPrice.Text = maxPri.ToString(); }

            var latestPri = productService.GetLatestPriPro(this.lableSkinName.Text, 4);
            if (latestPri != 0) { this.labelNewPrice.Text = latestPri.ToString(); }
        }
        private void AddSellInDataGridView(List<ProductDto> products)//販售中商品
        {
            foreach (var product in products)
            {
                dataGridViewSell.Rows.Add(product.ID, product.Price, product.AddDate, product.SellerID);
            }
        }
        public void DisplayMyProduct()
        {
            //寫法1 (AddSellInDataGridView + DisplayWantProduct)
            dataGridViewSell.Rows.Clear();

            var mySellService = new ProductService(GetProductRepo());

            var products = mySellService.Search(this.lableSkinName.Text, 0, "販售");

            AddSellInDataGridView(products);

            //寫法2
            //var sellProductService = new ProductService(GetProductRepo());
            //var productsSell = sellProductService.Search(this.lableSkinName.Text, 0, "販售");
            //dataGridViewSell.DataSource = productsSell;
        }
        private void AddBuyInDataGridView(List<ProductDto> products)//收購中商品
        {
            foreach (var product in products)
            {
                dataGridViewbuy.Rows.Add(product.ID, product.Price, product.AddDate, product.BuyerID);
            }
        }
        public void DisplayWantProduct()
        {
            dataGridViewbuy.Rows.Clear();

            var service = new ProductService(GetProductRepo());

            var products = service.Search(this.lableSkinName.Text, 0, "購買");

            AddBuyInDataGridView(products);
        }



        //新增交易
        private void buttonAddSell_Click(object sender, EventArgs e)
        {
            var form = new FormAdd(_account, this.lableSkinName.Text, "販售");
            form.Owner = this;
            form.ShowDialog();
        }
        private void buttonAddBuy_Click(object sender, EventArgs e)
        {
            var form = new FormAdd(_account, this.lableSkinName.Text, "購買");
            form.Owner = this;
            form.ShowDialog();
        }

        //顯示上架中
        private void DataGridViewSell_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            List<ProductDto> pro = dataGridViewSell.DataSource as List<ProductDto>;//三層式架構

            DataGridViewRow selectedRow = dataGridViewSell.Rows[e.RowIndex];
            int id = Convert.ToInt32(selectedRow.Cells["ColumnID"].Value);
            string sellerID= Convert.ToString(selectedRow.Cells["ColumnSeller"].Value);

            if (sellerID == _account)
            {
                var form = new FormUpdateOrDelete(_account, id, "販售");
                form.Owner = this;
                form.ShowDialog();
            }
            else
            {
                var form = new FormCheckTrade(_account, id, "販售");
                form.Owner = this;
                form.ShowDialog();
            }

        }
        private void DataGridViewbuy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;//e.RowIndex < 0, 點選表頭

            List<ProductDto> pro = dataGridViewbuy.DataSource as List<ProductDto>;//三層式架構

            //int id = pro[e.RowIndex].ID;//找出哪一筆
            DataGridViewRow selectedRow = dataGridViewbuy.Rows[e.RowIndex];
            int id = Convert.ToInt32(selectedRow.Cells["ColumnID2"].Value);
            string buyerID = Convert.ToString(selectedRow.Cells["ColumnBuyer"].Value);


            if (buyerID == _account)
            {
                var form = new FormUpdateOrDelete(_account, id, "購買");
                form.Owner = this;
                form.ShowDialog();
            }
            else
            {
                var form = new FormCheckTrade(_account, id, "購買");
                form.Owner = this;
                form.ShowDialog();
            }

        }

        private void FormSkinDescription_FormClosed(object sender, FormClosedEventArgs e)
        {
            //解決記憶體不足問題
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
