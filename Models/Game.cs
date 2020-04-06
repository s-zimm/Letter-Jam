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

            var i = 0;
            Players.ForEach(player => {
                player.InitialCards = splitDecksForInitialWords[i];
                i++;
            });
        }

        public void InitialWordsCreated(Dictionary<string, List<Card>> userCreatedWordMap)
        {
            var users = userCreatedWordMap.Keys;
            foreach(var user in users)
            {
                var highestIndex = Players.Count - 1;
                var foundPlayer = Players.Find(player => player.Name == user);
                var playerIndex = Players.IndexOf(foundPlayer);
                var targetIndex = 0;

                switch(playerIndex)
                {
                    case 0:
                        targetIndex = highestIndex;
                        break;

                    default:
                        targetIndex = playerIndex - 1;
                        break;
                }

                Players[targetIndex].Cards = userCreatedWordMap[user];
            }
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
            var cardsListCount = (double)shuffledDeck.FullCardsList.Count;
            Console.WriteLine("Cards Count: " + cardsListCount);
            var sectionSize = Math.Floor(cardsListCount / numPlayers);
            var splits = new List<dynamic>();
            Console.WriteLine("Cards per player: " + sectionSize);
            var currentSplitIndex = 0;
            var startIndexForSection = 0;
            for (var i = 0; i < numPlayers; i++)
            {
                var range = shuffledDeck.FullCardsList.GetRange(startIndexForSection, (int)sectionSize);
                splits.Add(new List<Card>() {});
                splits[currentSplitIndex].AddRange(range);
                currentSplitIndex++;
                startIndexForSection += (int)sectionSize;
            }

            return splits;
            
        }
    }
}