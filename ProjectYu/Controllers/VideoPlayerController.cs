using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectYu.Models;

namespace ProjectYu.Controllers
{
    public class VideoPlayerController : Controller
    {
        public IActionResult Index(string fileName)
        {
            VideoModel videoModel = new VideoModel();
            DataLayer dl = new DataLayer();
            DataTable dt = dl.GetVideoByFileName(fileName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                videoModel.CommentListID = int.Parse(dt.Rows[i]["CommentsListID"].ToString());
                videoModel.LikesCount = int.Parse(dt.Rows[i]["Likes"].ToString());
                videoModel.FileName = dt.Rows[i]["FileName"].ToString();
                videoModel.VideoName = dt.Rows[i]["VideoName"].ToString();
                videoModel.DislikesCount = int.Parse(dt.Rows[i]["Dislikes"].ToString());
                videoModel.DeletedByUserID = int.Parse(dt.Rows[i]["CreatedByUserID"].ToString());


            }
            return View(videoModel);
        } 
       
    } 
}