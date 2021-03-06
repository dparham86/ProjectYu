﻿using System;
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
        public IActionResult Index(string linkId, LoginedUserModel loginUserModel)
        {
            VideoModel videoModel = new VideoModel();
            DataLayer dl = new DataLayer();
            List<VideoModel> videoModel2 = new List<VideoModel>();
            loginUserModel.UserModel.listOfFavorites.listOfMVideoModels = videoModel2;
            DataTable dt = dl.GetVideoByFileName(loginUserModel.NewVideosModel.listofVideos[int.Parse(linkId)].FileName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                videoModel.CommentListID = int.Parse(dt.Rows[i]["CommentsListID"].ToString());
                videoModel.LikesCount = int.Parse(dt.Rows[i]["Likes"].ToString());
                videoModel.FileName = dt.Rows[i]["FileName"].ToString();
                videoModel.VideoName = dt.Rows[i]["VideoName"].ToString();
                videoModel.DislikesCount = int.Parse(dt.Rows[i]["Dislikes"].ToString());
                videoModel.DeletedByUserID = int.Parse(dt.Rows[i]["CreatedByUserID"].ToString());
                videoModel.isSelected = true;

            }
            for(int i = 0; i < loginUserModel.NewVideosModel.listofVideos.Count; i++)
            {
                if (i == int.Parse(linkId))
                {
                    loginUserModel.NewVideosModel.listofVideos[i] = videoModel;
                    break;
                }
            }
            return View(loginUserModel);
        } 
       
    } 
}