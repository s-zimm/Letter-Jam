using System;
using System.Collections.Generic;

namespace JustOne.Models
{
    public class Deck
    {
        public static List<string> AllLettersList = new List<string>()
        {
            "A", "B", "C"
        };
        public List<Card> FullCardsList;
        
        public List<Card> ExistingCardsList { get; set; }
        private static Random rng = new Random();  


        public Deck()
        {
            var allCards = new List<Card>();
            AllLettersList.ForEach(letter => allCards.Add(new Card(letter)));

            FullCardsList = allCards;
        }

        public List<Card> GetCards()
        {
            return FullCardsList;
        }

        public void Shuffle()  
        {
            int n = FullCardsList.Count;  
            while (n > 1) {  
                n--;  
                int k = rng.Next(n + 1);  
                Card value = FullCardsList[k];  
                FullCardsList[k] = FullCardsList[n];  
                FullCardsList[n] = value;  
            }  
        }
    }
}