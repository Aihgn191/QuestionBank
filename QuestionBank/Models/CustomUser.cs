using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;

namespace QuestionBank.Models
{
    public class CustomUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public Guid? KhoaID { get; set; }
        public string? Img { get; set; }
        public virtual Khoa MaKHoaNavigation { get; set; } = null!;
    }
}
