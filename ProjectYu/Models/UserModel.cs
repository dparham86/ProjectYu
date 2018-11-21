using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYu.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }

        public string IsActive { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Birthday { get; set; }

        public int ChannelID { get; set; }

        public int FavoriteListID {get;set;}

        public int WatchLaterListID { get; set; }

        public int SubscriberListID { get; set; }

        public int BlockedUserListID { get; set; }

        public int HistoryListID { get; set; }

        public int LikedVideoListID { get; set; }



        //public List<SelectListItem> PayMethodList { get; set; }

        //public MovieList listOfMovies { get; set; }

        //public FavoritesList listOfFavorites { get; set; }

        //public List<UserModel> listOfFriends { get; set; }
    }
}

