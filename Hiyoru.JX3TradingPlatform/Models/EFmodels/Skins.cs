namespace Hiyoru.JX3TradingPlatform.Models.EFmodels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Skins
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(50)]
        public string EName { get; set; }

        [Column(TypeName = "date")]
        public DateTime LaunchDate { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }

        [StringLength(50)]
        public string PicturePath { get; set; }
    }
}
