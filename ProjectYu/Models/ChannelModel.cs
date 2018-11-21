using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYu.Models
{
    public class ChannelModel
    {
        public int ChannelID { get; set; }

        public string ChannelName { get; set; }

        public int VideoID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string IsActive { get; set; }

        public DateTime EndDate { get; set; }


    }
}
