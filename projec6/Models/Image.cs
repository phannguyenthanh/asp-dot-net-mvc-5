namespace project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Sản phẩm")]
        public int? IdProduct { get; set; }
        [Display(Name = "Link ảnh")]
        [MaxLength(300)]
        public string Name { get; set; }
        [Display(Name = "Hiển thị")]
        public bool Status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? Createtime { get; set; }

        public virtual Product Product { get; set; }
    }
}
