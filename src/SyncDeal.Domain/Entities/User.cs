
using SyncDeal.Domain.Enums;

namespace SyncDeal.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = Roles.EMPLOYEE;
        public Guid UserIdentifier { get; set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
