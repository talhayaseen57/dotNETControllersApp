using Microsoft.AspNetCore.Mvc;

namespace dotNETControllersApp.Models
{
    public class Book
    {
        [FromQuery]
        public int? BookId { get; set; }
        public string? Author { get; set; }
        public override string ToString()
        {
            return $"Book - {BookId} from {Author}";
        }
    }
}
