using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectYu.Models;
using System.Data;

namespace ProjectYu.Controllers
{
    public class HomeController : Controller
    {
        DataLayer dl = new DataLayer();

        public IActionResult Index()
        {
            
            NewVideosModel listOfVideos = NewVideos();
            return View("Index",listOfVideos);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
