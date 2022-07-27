using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("users")]
public class User
{
    [Key]
    [Column("user_id")]
    public long UserId { get; set; }
    [Column("user_nm", TypeName = "VARCHAR (50)")]
    public string UserNm { get; set; } = null!;
    [Column("user_pwd", TypeName = "VARCHAR (50)")]
    public string UserPwd { get; set; } = null!;
    [Column("user_role_id")]
    public long UserRoleId { get; set; }

    [ForeignKey("UserRoleId")]
    [InverseProperty("Users")]
    public virtual UserRole UserRole { get; set; } = null!;
}