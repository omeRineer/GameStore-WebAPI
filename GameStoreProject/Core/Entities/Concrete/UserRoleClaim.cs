using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class UserRoleClaim:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleClaimId { get; set; }

        public User User { get; set; }
        public RoleClaim RoleClaim { get; set; }
    }
}