using System;
using System.Collections.Generic;

namespace JustOne.Models
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public Deck CurrentGameDeck { get; set; }

        public Game(List<Player> players)
        {
            Players = players;
            CurrentGameDeck = new Deck();
            CurrentGameDeck.Shuffle();
            var splitDecksForInitialWords = SplitDeck(CurrentGameDeck, Players.Count);

            Players.ForEach(player => {
                var i = 0;
                player.InitialCards = splitDecksForInitialWords[i];
                i++;
            });
        }

        public void DealCards()
        {

        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public List<dynamic> SplitDeck(Deck shuffledDeck, int numPlayers)
        {
            var numberOfSections = Math.Floor((double)shuffledDeck.FullCardsList.Count / numPlayers);
            var splits = new List<dynamic>();
            for (var i = 0; i < shuffledDeck.FullCardsList.Count; i++)
            {
                var currentSplitIndex = 0;
                if (i % numberOfSections == 0)
                {
                    var range = shuffledDeck.FullCardsList.GetRange(i, i + 1);
                    if (!splits[currentSplitIndex])
                    {
                        splits[currentSplitIndex] = new List<Card>() {};
                    }
                    splits[currentSplitIndex].AddRange(range);
                    currentSplitIndex++;
                }
            }

            return splits;
            
        }
    }
}