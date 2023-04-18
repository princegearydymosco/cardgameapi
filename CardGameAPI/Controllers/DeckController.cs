using Microsoft.AspNetCore.Mvc;
using CardGameAPI.Models;

namespace CardGameAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private static List<Deck> _decks = new List<Deck>();

        [HttpPost("api/deck")]
        public IActionResult CreateNewDeck(bool shuffled = false, string? cards = null)
        {
            List<Card> newDeckCards = new List<Card>();
            string[] suits = new string[] { "SPADES", "DIAMONDS", "HEARTS", "CLUBS" };
            string[] values = new string[] { "ACE", "2", "3", "4", "5", "6", "7", "8", "9", "10", "JACK", "QUEEN", "KING" };

            foreach (string suit in suits)
            {
                foreach (string value in values)
                {
                    newDeckCards.Add(new Card { Value = value, Suit = suit, Code = $"{value[0]}{suit[0]}" });
                }
            }

            if (shuffled)
            {
                Random rng = new Random();
                int n = newDeckCards.Count;

                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    Card card = newDeckCards[k];
                    newDeckCards[k] = newDeckCards[n];
                    newDeckCards[n] = card;
                }
            }

            if (!string.IsNullOrEmpty(cards))
            {
                newDeckCards = newDeckCards.Where(c => cards.Contains(c.Code)).ToList();
            }

            string deckId = Guid.NewGuid().ToString();
            Deck newDeck = new Deck { DeckId = deckId, Remaining = newDeckCards.Count, Shuffled = shuffled, Cards = newDeckCards };
            _decks.Add(newDeck);

            return Ok(newDeck);
        }

        [HttpGet("api/deck/{deckId}")]
        public IActionResult OpenDeck(string deckId)
        {
            var deck = _decks.FirstOrDefault(d => d.DeckId == deckId);
            if (deck == null)
            {
                return NotFound();
            }

            return Ok(deck);
        }

        [HttpGet("api/deck/{deckId}/draw")]
        public ActionResult<List<Card>> DrawCard(string deckId, int count = 1)
        {
            var deck = _decks.FirstOrDefault(d => d.DeckId == deckId);
            if (deck == null)
            {
                return NotFound();
            }

            if (count < 1 || count > deck.Cards.Count)
            {
                return BadRequest("Invalid draw count");
            }

            var drawnCards = new List<Card>();

            for (int i = 0; i < count; i++)
            {
                if (deck.Cards.Count == 0)
                {
                    break;
                }

                var card = deck.Cards.Last();
                deck.Cards.RemoveAt(deck.Cards.Count - 1);
                drawnCards.Add(card);
            }

            deck.Remaining -= drawnCards.Count;

            return drawnCards;
        }
    }
}
