namespace TradingCardGameStateMachine
{
    public class Card
    {
        private int id;
        private string title;
        private int power;
        private CardType type;

        public Card(int id, string title, int power, CardType type)
        {
            this.id = id;
            this.title = title;
            this.power = power;
            this.type = type;
        }
    }

    public enum CardType
    {
        NULL = 0,
        Monster,
        Spell
    }
}
