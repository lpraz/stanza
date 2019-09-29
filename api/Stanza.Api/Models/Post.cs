using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stanza.Api.Models
{
    public class Post
    {
        public long Id { get; set; }
        
        public string Content { get; set; }

        public long AuthorId { get; set; }

        public User Author { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EditedDate { get; set; }

        public long InReplyToId { get; set; }

        public Post InReplyTo { get; set; }

        public IEnumerable<Post> Replies { get; set; }
    }
}