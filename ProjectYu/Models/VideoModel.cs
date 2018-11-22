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

        public int? DeletedByUserID { get; set; }

        public string CreatedDateTime { get; set; }

        public string DeletedDateTime { get; set; }

        public int LikesCount { get; set; }

        public int DislikesCount { get; set; }

        public double Rating { get; set; }

        public int CommentListID { get; set; }

        public string FileName { get; set; }
    }
}
