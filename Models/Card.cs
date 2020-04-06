namespace LetterJam.Models
{
    public class Card
    {
        public string Letter { get; set; }

        public Card(string letter)
        {
            Letter = letter;
        }
    }
}