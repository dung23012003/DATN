using System.ComponentModel.DataAnnotations;

namespace DongY.Models
{
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<AccountModel> Accounts { get; set; }
    }

}
