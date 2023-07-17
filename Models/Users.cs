namespace SignalRChat.Models
{
    public class Users
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
