using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft;
using System.IO;
using ProjectYu.Models;
using System.Data;

namespace ProjectYu.Controllers
{
    public class VideoUploadController : Controller 
    {
        public IActionResult Index()
        {
            //DataLayer dl = new DataLayer();
            LoginedUserModel UserModLoginedUserModel = new LoginedUserModel();
            UserModel userModel = new UserModel();
            UserModLoginedUserModel.UserModel = userModel;
            //UserModLoginedUserModel.UserModel.UserId = 1;
            UserModLoginedUserModel.UserModel.UserName = "Elsy";
            UserModel acceptedUserModel = getAllUserData(UserModLoginedUserModel.UserModel.UserName);
            UserModLoginedUserModel.UserModel = acceptedUserModel;
            NewVideosModel newVideosModel = NewVideos();
            UserModLoginedUserModel.NewVideosModel = new NewVideosModel();
            UserModLoginedUserModel.NewVideosModel = newVideosModel;
            FavoritesListModel favList = new FavoritesListModel();
            UserModLoginedUserModel.UserModel.listOfFavorites = favList;
            List<VideoModel> videoModel = new List<VideoModel>();
            UserModLoginedUserModel.UserModel.listOfFavorites.listOfMVideoModels = videoModel;
            UserModLoginedUserModel.loggedIn = true;
            return View("Index", UserModLoginedUserModel);
        }

        public NewVideosModel NewVideos()
        {
            NewVideosModel listOfVideoModels = new NewVideosModel();
            listOfVideoModels.listofVideos = new List<VideoModel>();
            DataLayer dl = new DataLayer();
            DataTable dt = dl.GetVideosByUserID();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VideoModel videoModel = new VideoModel();
                videoModel.VideoID = int.Parse(dt.Rows[i]["VideoID"].ToString());
                videoModel.VideoName = dt.Rows[i]["VideoName"].ToString();
                videoModel.CreatedbyUserID = int.Parse(dt.Rows[i]["CreatedByUserID"].ToString());
                videoModel.DeletedByUserID = null;
                videoModel.CreatedDateTime = dt.Rows[i]["CreatedDateTime"].ToString();
                videoModel.DeletedDateTime = null;
                videoModel.LikesCount = int.Parse(dt.Rows[i]["Likes"].ToString());
                videoModel.DislikesCount = int.Parse(dt.Rows[i]["Dislikes"].ToString());
                videoModel.Rating = double.Parse(dt.Rows[i]["Rating"].ToString());
                videoModel.FileName = dt.Rows[i]["FileName"].ToString();
                listOfVideoModels.listofVideos.Add(videoModel);
            }


            return listOfVideoModels;
        }

        [HttpPost]
        public void SaveNewFile(string file, int userId)
        {
          
            DirectoryInfo directorInfo = new DirectoryInfo(file);
            var fileName = directorInfo.Name;
            var fileExt = directorInfo.Extension;
            var fileFullName = directorInfo.FullName;


            DataLayer dl = new DataLayer();
            dl.addNewVideo(fileName, fileExt, userId);
            RedirectToAction("Index", "Home");
    
        }

        private UserModel getAllUserData(string userName)
        {
            DataLayer dl = new DataLayer();
            UserModel userModel = new UserModel();
            DataTable dt = dl.getAllUserData(userName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                userModel.UserId = int.Parse(dt.Rows[i]["userId"].ToString());
                userModel.UserName = dt.Rows[i]["userName"].ToString();
                userModel.IsActive = dt.Rows[i]["IsActive"].ToString();
                userModel.FavoriteListID = int.Parse(dt.Rows[i]["FavoritesListID"].ToString());
                //userModel.contentAccess = dt.Rows[i]["contentAcces"].ToString().Trim();
                //userModel.subcriptionStartDate = dt.Rows[i]["subscriptionStartDate"].ToString();
                //userModel.subscriptionEndDate = dt.Rows[i]["subscriptionEndDate"].ToString();
                // dl.getFriends(userModel.UserId);

                //userModel.listOfFriends.listOfMovies.Add(movieModel);
                //listOfFriends.Add(userModel);

            }
            //userModel.listOfFriends = getFriendsList(userModel);
            //userModel.listOfFavorites = getAllFavorites();
            return userModel;
        }


    }
}