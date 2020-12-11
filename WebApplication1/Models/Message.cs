using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string time { get; set; }
        public string user { get; set; }
        public string message { get; set; }
    }
}
