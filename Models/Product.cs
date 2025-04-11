using System.ComponentModel.DataAnnotations.Schema;

namespace StockCartApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // เพิ่ม property นี้เข้าไป
        [NotMapped] // ใช้ attribute นี้ถ้าไม่ต้องการให้มันเก็บในฐานข้อมูล
        public int Quantity { get; set; }
    }
}
