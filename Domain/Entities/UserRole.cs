using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("user_roles")]
public class UserRole
{
    [Key]
    [Column("user_role_id")]
    public long UserRoleId { get; set; }
    [Column("user_role_nm", TypeName = "VARCHAR (10)")]
    public string UserRoleNm { get; set; } = null!;

    [InverseProperty("UserRole")]
    public virtual ICollection<User> Users { get; set; } = null!;
}