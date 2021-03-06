﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;

namespace Rockola2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuscarLista(string keyword)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyAoyvJHMloSp9f7H5FE2GvFhehwyn9nT7U",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = keyword; // Replace with your search term.
            searchListRequest.MaxResults = 10;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = searchListRequest.Execute();

            return PartialView(searchListResponse.Items);
        }

        public void Declare()
        {
            List<string> PlayListIds = new List<string>();
            if (Session["Playlist"] == null)
            {
                Session["Playlist"] = PlayListIds;
            }
        }

        [HttpGet]
        public ActionResult AddToPlayList(string IdVideo)
        {
            Declare();
            List<string> ListVideosId = (List<string>)Session["Playlist"];
            ListVideosId.Add(IdVideo);
            Session["Playlist"] = ListVideosId;
            return PartialView("Playlist", ListVideosId);
        }
    }
}