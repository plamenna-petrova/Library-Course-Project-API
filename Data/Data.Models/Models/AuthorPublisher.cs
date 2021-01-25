using Data.Models.Abstraction;
using System.Text;

namespace Data.Models.Models
{
    public class AuthorPublisher 
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

    }
}