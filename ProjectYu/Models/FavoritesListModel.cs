using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYu.Models
{
    public class FavoritesListModel
    {
        public int FavoritesListID { get; set; }

        public List<VideoModel> listOfMVideoModels { get; set; }
    }
}
