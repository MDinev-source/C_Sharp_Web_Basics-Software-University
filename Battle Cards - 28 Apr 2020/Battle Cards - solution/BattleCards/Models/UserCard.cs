namespace BattleCards.Models
{
    using System.ComponentModel.DataAnnotations;
    public class UserCard
    {
        [Key]
        public string UserId { get; set; }

        public User User { get; set; }

        [Key]
        public int CardId { get; set; }

        public Card Card { get; set; }
    }
}
