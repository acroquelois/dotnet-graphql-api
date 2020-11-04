namespace Skeleton.Domain.Dtos.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Login { get; set; }
        public string MotDePasse { get; set; }
    }
}