namespace TextCatalog.DAL.Model
{
    using System;

    public class Rating
    {
        public int UserId { get; set; }
        public int TextId { get; set; }
        public bool Positive { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
