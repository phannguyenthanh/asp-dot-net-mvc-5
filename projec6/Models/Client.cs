namespace project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Client")]
    public partial class Client
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Thông tin")]
        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string Cnt { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? Createtime { get; set; }
    }
}
