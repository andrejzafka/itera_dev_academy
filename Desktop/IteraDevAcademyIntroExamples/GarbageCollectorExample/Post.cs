using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageCollectorExample
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Perex { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {AuthorId} {CreatedAt}";
        }
    }
}
