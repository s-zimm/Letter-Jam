using System;
using System.Collections.Generic;

namespace JustOne.Models
{
    public class Deck
    {
        public static Dictionary<string, int> NumberOfIndividualLettersMap = new Dictionary<string, int>()
        {
            {"A", 4},
            {"B", 2},
            {"C", 3},
            {"D", 3},
            {"E", 6},
            {"F", 2},
            {"G", 2},
            {"H", 3},
            {"I", 4},
            {"K", 2},
            {"L", 3},
            {"M", 2},
            {"N", 3},
            {"O", 4},
            {"P", 2},
            {"R", 4},
            {"S", 4},
            {"T", 4},
            {"U", 3},
            {"W", 2},
            {"Y", 2}
        };

        public List<Card> FullCardsList;
        
        public List<Card> ExistingCardsList { get; set; }
        private static Random rng = new Random();  


        public Deck()
        {
            var allCards = new List<Card>();
            var letters = NumberOfIndividualLettersMap.Keys;
            foreach(var letter in letters)
            {
                for (var i = 0; i < NumberOfIndividualLettersMap[letter]; i++)
                {
                    allCards.Add(new Card(letter));
                }
            }

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