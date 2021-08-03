namespace BattleCards.ViewModels.Cards
{
    public class CardInputModel
    {
        public CardInputModel()
        {

        }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public int Health { get; set; }
    }
}
