using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYu.Models
{
    public class File
    {
        public string FileName { get; set; }

        public string VideoName { get; set; }

        public DateTime Created { get; set; }

        public int userId { get; set; } 

        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Rating { get; set; }
        public int CommentListId { get; set; }
    }
}
