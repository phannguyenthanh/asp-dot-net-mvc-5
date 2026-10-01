namespace project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public partial class Slider
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Đường dẫn ảnh")]
        [Required(ErrorMessage = " Bạn chưa nhập tên !")]

        [StringLength(50)]
        public string Name { get; set; }
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = " Bạn chưa nhập tiêu đề !")]
        [StringLength(100)]
        public string Title { get; set; }
        [Display(Name = "Hiển thị")]
        public bool Status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? Createtime { get; set; }
    }
}
