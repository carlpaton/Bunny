using System;

namespace Bunny.Repository.Schema
{
    public class ScoreModel
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int UserId { get; set; }
        public DateTime InsertDate { get; set; }
        public int Taste { get; set; }
        public int Temperature { get; set; }
        public int Tomorrow { get; set; }
    }
}
