using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRChat.Models
{
    public class Users
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int id { get; set; }
        public required string name { get; set; }
        public required string password { get; set; }
        [ForeignKey("id")]
        public Groups Groups { get; set; }
    }
}
