using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEntityFramework.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [Column(TypeName = "NUMBER(1)")]
        public bool IsActive { get; set; }

        public List<Role> Role { get; set; }

    }
}
