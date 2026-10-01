namespace project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;

    public enum colors
    {
        Đỏ, Trắng, Đen, Xanh, Nâu
    }
    public enum sex
    {
        Nam, Nữ, Nam_Nữ
    }
    public enum size
    {
        cỡ_39, cỡ_40, cỡ_41, cỡ_42, cỡ_43
    }
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Images = new HashSet<Image>();
            Orders = new HashSet<Order>();
        }

        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "ID loai sản phẩm")]
        public int? IdCategory { get; set; }
        [Display(Name = "ID nhãn hiệu")]
        public int? IdBrand { get; set; }
        [Display(Name = "Tên sp")]
        [Required(ErrorMessage = " Bạn chưa nhập tên sản phảm ! ")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = " Bạn chưa nhập giá sản phẩm ! ")]
        [Display(Name = "Giá sp ")]
        public int? Price { get; set; }
        [Display(Name = "Giảm giá")]
        [Required(ErrorMessage = " Bạn chưa nhập khuyến mãi ! ")]
        public int? Sale { get; set; }
        [Display(Name = "Màu sp")]

        public colors Color { get; set; }
        [Display(Name = "Cỡ sp")]

        public size Size { get; set; }
        [Required(ErrorMessage = " Bạn chưa nhập số lượng !")]
        [Display(Name = "Số lượng sp")]
        public int? Quantity { get; set; }
        [Display(Name = "Ảnh sp")]
        [StringLength(300)]
        [Required(ErrorMessage = " Bạn chưa chọn ảnh! ")]
        public string Image { get ; set; }
        [Display(Name = "Đối tượng")]
        public sex Sex { get; set; }
        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Chưa nhập tiêu đề")]
        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string Title { get; set; }
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Chưa nhập nội dung")]
        [Column(TypeName = "ntext")]
        [AllowHtml]
        public string Tcontent { get; set; }
        [Display(Name = "Lượt xem")]
        public int? _View { get; set; }
        [Display(Name = "Hiển thị")]
        public bool Status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? Createtime { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image> Images { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
