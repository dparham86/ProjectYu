using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectYu.Models;

namespace ProjectYu.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            //UserModel acceptedUserModel = getAllUserData(UserModel.UserName);
            //NewVideosModel newVideosModel = NewVideos();

            LoginedUserModel LoggedInUserModel = new LoginedUserModel{};
            UserModel UserModel = new UserModel();
            return View("Index", LoggedInUserModel);
        }

        [HttpPost]
        public IActionResult Login(LoginedUserModel UserModLoginedUserModel)
        {
            DataLayer dl = new DataLayer();
            UserModel acceptedUserModel = getAllUserData(UserModLoginedUserModel.UserModel.UserName);
            FavoritesListModel favoritesListModel = new FavoritesListModel();
            
            NewVideosModel newVideosModel = NewVideos();

            LoginedUserModel LoggedInUserModel = new LoginedUserModel { UserModel = acceptedUserModel, NewVideosModel = newVideosModel };
            //bool UserExists = false;
            if (dl.CheckForExistingUser(UserModLoginedUserModel.UserModel.UserName, UserModLoginedUserModel.UserModel.PassWord))
            {
                LoggedInUserModel.loggedIn = true;
                favoritesListModel = GetFavoritesList(LoggedInUserModel.UserModel.FavoriteListID);
                LoggedInUserModel.UserModel.listOfFavorites = favoritesListModel;
                RedirectToAction("Index", "Home", LoggedInUserModel);
                return View("LoginMainView", LoggedInUserModel);

            }
            else
            {
                UserModLoginedUserModel.UserModel.IsActive = "N";
                return View("Index", UserModLoginedUserModel);
            }

        }

        private FavoritesListModel GetFavoritesList(int FavortiesListID)
        {
            FavoritesListModel listOfVideoModels = new FavoritesListModel();
            listOfVideoModels.listOfMVideoModels = new List<VideoModel>();
            DataLayer dl = new DataLayer();
            DataTable dt = dl.getFavoritesList(FavortiesListID);
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
                listOfVideoModels.listOfMVideoModels.Add(videoModel);
            }


            return listOfVideoModels;
        }

        public NewVideosModel NewVideos()
        {
            NewVideosModel listOfVideoModels = new NewVideosModel();
            listOfVideoModels.listofVideos = new List<VideoModel>();
            DataLayer dl = new DataLayer();
            DataTable dt = dl.GetNewVideos();
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