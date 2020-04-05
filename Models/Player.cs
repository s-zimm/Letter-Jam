using System.Collections.Generic;

namespace JustOne.Models
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public List<Card> InitialCards { get; set; }
        
        public Player(string name)
        {
            Name = name;
        }
    }
}