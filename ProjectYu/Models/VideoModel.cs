using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYu.Models
{
    public class VideoModel
    {
        public int VideoID { get; set; }

        public string VideoName { get; set; }

        public int CreatedbyUserID { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime DeletedDateTime { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public int Rating { get; set; }

        public int CommentListID { get; set; }
    }
}
