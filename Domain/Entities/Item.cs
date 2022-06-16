using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("items")]
    public class Item
    {
        [Key]
        [Column("item_id")]
        public long ItemId { get; set; }
        [Column("item_nm", TypeName = "VARCHAR (50)")]
        public string ItemNm { get; set; } = null!;
        [Column("item_desc", TypeName = "VARCHAR (250)")]
        public string? ItemDesc { get; set; }
        [Column("item_img", TypeName = "VARCHAR (100)")]
        public string? ItemImg { get; set; }
        [Column("category_id")]
        public long CategoryId { get; set; }
        [Column("item_price", TypeName = "DECIMAL (10, 2)")]
        public byte[] ItemPrice { get; set; } = null!;
        [Column("item_amt")]
        public long ItemAmt { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Items")]
        public virtual Category Category { get; set; } = null!;
    }
}
