namespace Ef6CoreForPosgreSQL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Group Group { get; set; }
        public int GroupId { get; set; }
    }
}