namespace project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public enum access
    {
        Admin, Thường
    }
    public enum sexx
    {
        Nam, Nữ
    }

    [Table("User")]
    public partial class User
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Tên")]
        [Required(ErrorMessage = " Bạn chưa nhập tên !")]
        [StringLength(20)]
        public string First_name { get; set; }
        [Display(Name = "Tên đệm")]
        [Required(ErrorMessage = " Bạn chưa nhập họ !")]
        [StringLength(20)]
        public string Last_name { get; set; }

        
        [Display(Name = "Email")]
        [Remote("CheckEmail", "Login", AdditionalFields = "Id", ErrorMessage = "Email đã tồn tại !")]
        [DataType(DataType.EmailAddress,ErrorMessage = "email không đúng định dạng")]
        //[Index("IX_EmailUnique", 1, IsUnique = true)]
        [Required(ErrorMessage = " Bạn chưa nhập email !")]
        [StringLength(50)]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Zaz]{2,4}", ErrorMessage = "Email phải đúng định dạng")]
        public string Email { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = " Bạn chưa nhập họ !")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Độ dài ít nhất 6 kí tự !")]
        public string Passwold { get; set; }
        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = " Bạn chưa xác nhận lại mật khẩu !")]
        [System.ComponentModel.DataAnnotations.Compare("Passwold", ErrorMessage = " Xác nhận mật khẩu không đúng!")]
        public string Passwold2 { get; set; }
        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = " Bạn chưa chọn giới tính!")]
        public sexx Sex { get; set; }
        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = " Bạn chưa nhập ngày sinh !")]
        public DateTime? Birthday { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = " Bạn chưa nhập số điện thoại !")]
        [StringLength(20)]
        public string Phone { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = " Bạn chưa nhập địa chỉ !")]
        [StringLength(200)]
        public string Address { get; set; }
        [Required(ErrorMessage = " Bạn chưa nhập ảnh đại diện !")]
        [StringLength(300)]
        [Display(Name = "Link ảnh")]
        public string Avatar { get; set; }
        [Display(Name = "Quyền")]
        [Required(ErrorMessage = " Bạn chưa nhập phân quyền !")]
        public access? Access { get; set; }
        [Display(Name = "Hiển thị")]
        public bool Status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? Createtime { get; set; }

    }
}
