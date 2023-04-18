namespace CardGameAPI.Models
{
    public class Deck
    {
        public string DeckId { get; set; }
        public bool Shuffled { get; set; }
        public int Remaining { get; set; }
        public List<Card> Cards { get; set; }
    }
}
