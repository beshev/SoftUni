namespace Theatre.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public sbyte RowNumber { get; set; }

        public int PlayId { get; set; }
        public Play Play { get; set; }

        public int TheatreId { get; set; }
        public Theatre Theatre { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	Price – decimal in the range [1.00….100.00] (required)
//•	RowNumber – sbyte in range[1….10](required)
//•	PlayId – integer, foreign key(required)
//•	TheatreId – integer, foreign key(required)

