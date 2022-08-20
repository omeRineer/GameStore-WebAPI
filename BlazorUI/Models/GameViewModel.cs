using System;

namespace BlazorUI.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string DeveloperName { get; set; }
        public string DistributorName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
