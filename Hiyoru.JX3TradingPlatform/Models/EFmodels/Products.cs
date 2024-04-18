namespace Hiyoru.JX3TradingPlatform.Models.EFmodels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Products
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string SkinName { get; set; }

        public int Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime AddDate { get; set; }

        [StringLength(20)]
        public string BuyerID { get; set; }

        [StringLength(20)]
        public string SellerID { get; set; }

        public int Status { get; set; }

        [Required]
        [StringLength(4)]
        public string Type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TransDate { get; set; }

        [StringLength(10)]
        public string TransAccount { get; set; }

        [StringLength(20)]
        public string Recipient { get; set; }
    }
}
