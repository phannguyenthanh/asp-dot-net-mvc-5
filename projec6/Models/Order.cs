namespace project5.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Display(Name = "ID")]

        public int Id { get; set; }

        [Display(Name = "ID giao dịch")]
        public int? IdTransaction { get; set; }
        [Display(Name = "Sản phẩm")]
        public int? IdProduct { get; set; }
        [Display(Name = "Giá")]
        public double? Price { get; set; }
        [Display(Name = "Giảm giá")]
        public double? Sale { get; set; }
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }
        [Display(Name = "chua")]
        public bool? Receive { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime? Createtime { get; set; }

        public virtual Product Product { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
