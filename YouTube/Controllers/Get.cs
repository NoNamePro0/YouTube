using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using NYoutubeDL;

namespace YouTube.Controllers
{
    public class Get : Controller
    {
        string format = "data/{0}.mp4";


        // GET: Get
        public ActionResult Index(string yt)
        {
            Download(yt);

            FileStream file = System.IO.File.Open(String.Format(format, yt), FileMode.Open);
            Byte[] fileBytes = new Byte[file.Length];
            file.Close();

            return File(fileBytes, "video/mp4");
        }

        private void Download(string yt)
        {
            YoutubeDL youtubeDL = new YoutubeDL();

            youtubeDL.Options.FilesystemOptions.Output = String.Format(format, yt);
            youtubeDL.VideoUrl = "https://youtu.be/" + yt;

            youtubeDL.Download();
        }
    }
}
