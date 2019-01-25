using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectYu.Models;
using Newtonsoft.Json.Serialization;

namespace ProjectYu.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(string videoName)
        {
            DataLayer dl = new DataLayer();
            NewVideosModel listOfVideoModels = new NewVideosModel();
            listOfVideoModels.listofVideos = new List<VideoModel>();
            DataTable dt = dl.GetVideosByFileNameContains(videoName);

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
            return View("Index",listOfVideoModels);
        }

        [HttpGet]
        public JsonResult GetVideoNamesForAutoComplete()
        {
            DataLayer dl = new DataLayer();
            NewVideosModel listOfVideoModels = new NewVideosModel();
            listOfVideoModels.listofVideos = new List<VideoModel>();
            DataTable dt = dl.GetVideoNamesForAutoComplete();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VideoModel videoModel = new VideoModel();
                videoModel.VideoName = dt.Rows[i]["VideoName"].ToString();
                listOfVideoModels.listofVideos.Add(videoModel);
            }
            return Json(listOfVideoModels);
        }
    }
}