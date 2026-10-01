namespace project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            Orders = new HashSet<Order>();
        }
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Tài khoản")]
        public int? IdUser { get; set; }
        
        [Display(Name = "Thanh toán")]
        public int? IdPay { get; set; }
        [Required(ErrorMessage = " Bạn chưa nhập tên !")]
        [Display(Name = "Tên")]
        [StringLength(50)]
        public string First_name { get; set; }
        [Required(ErrorMessage = " Bạn chưa nhập Họ !")]
        [Display(Name = "Họ")]
        [StringLength(50)]
        public string Last_name { get; set; }
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Zaz]{2,4}", ErrorMessage = "Email phải đúng định dạng")]
        
        [Display(Name = "Email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required(ErrorMessage = " Bạn chưa nhập địa chỉ !")]
        [Display(Name = "Địa chỉ")]
        [StringLength(300)]
        public string Address {get; set; }
        [Required(ErrorMessage = " Bạn chưa nhập số điện thoại !")]
        [Display(Name = "Số điện thoại")]
        [StringLength(20)]

       
        public string Phone { get; set; }
        
        [Display(Name = "Mã")]
        [StringLength(6)]
        public string Security { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? Createtime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Pay Pay { get; set; }
    }
}
