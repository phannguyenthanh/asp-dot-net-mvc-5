namespace project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public enum status
    {
        Có = 0, Khong = 1
    }
    public enum sexxx
    {
        Nam, Nữ, Nam_và_Nữ
    }
    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Tên loại sản phẩm")]
        [StringLength(50)]
        [Required(ErrorMessage = "Bạn chưa nhập tên !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bạn chưa chọn hiển thị!")]
        [Display(Name = "Hiển thị")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập đối tượng!")]
        [Display(Name = "Phân loại")]
        public sexxx Sex { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? Createtime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
