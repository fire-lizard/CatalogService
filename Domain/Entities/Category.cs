using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("categories")]
    public class Category
    {
        public Category()
        {
            Items = new HashSet<Item>();
        }

        [Key]
        [Column("category_id")]
        public long CategoryId { get; set; }
        [Column("category_nm", TypeName = "VARCHAR (50)")]
        public string CategoryNm { get; set; } = null!;
        [Column("category_img", TypeName = "VARCHAR (100)")]
        public string? CategoryImg { get; set; }
        [Column("parent_category_id")]
        public long? ParentCategoryId { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Item> Items { get; set; }
    }
}
