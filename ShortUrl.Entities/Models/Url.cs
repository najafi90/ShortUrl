using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Entities.Models
{
    public class Url
    {
        public Url()
        {
            CreatedOn = DateTime.Now;
        }
        public int Id { get; set; }

        public string MainUrlAddress { get; set; }

        public string ShortAddress { get; set; }

        public int CounterViews { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
