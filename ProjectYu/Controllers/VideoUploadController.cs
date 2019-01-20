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
            DataLayer dl = new DataLayer();
            LoginedUserModel UserModLoginedUserModel = new LoginedUserModel();
            UserModel userModel = new UserModel();
            userModel.UserName = "admin";
            UserModLoginedUserModel.UserModel = userModel;
            //UserModLoginedUserModel.UserModel.UserId = 1;
            UserModel acceptedUserModel = getAllUserData(UserModLoginedUserModel.UserModel.UserName);
            UserModLoginedUserModel.UserModel = acceptedUserModel;
            return View("Index", UserModLoginedUserModel);
        }

        [HttpPost]
        public IActionResult SaveNewFile(string file, int userId)
        {
          
            DirectoryInfo directorInfo = new DirectoryInfo(file);
            var fileName = directorInfo.Name;
            var fileExt = directorInfo.Extension;
            var fileFullName = directorInfo.FullName;


            DataLayer dl = new DataLayer();
            dl.addNewVideo(fileName, fileExt, userId);
            //return RedirectToAction("Index", "Home");
            return View();
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