namespace project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    [Table("Letter")]
    public partial class Letter
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID tài khoản")]
        public int? IdUser { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập tên !")]
        [StringLength(30)]
        [Display(Name = "Tên")]
        public string First_name { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập họ !")]
        [StringLength(30)]
        [Display(Name = "Họ")]
        public string Last_name { get; set; }
        [Display(Name = "Email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập họ !")]
        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Display(Name = "Số điện thoại")]
        [StringLength(20)]
        public string Phone { get; set; }
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Bạn chưa nhập họ !")]
        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string Textcontent { get; set; }
        [Display(Name = "Tiêu đề")]
        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Bạn chưa nhập họ !")]
        public string Title { get; set; }
        [Display(Name = "Hiển thị")]
        public bool Status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? Createtime { get; set; }
    }
}
