using AnagramSolverWebsite.Controllers;
using BuisnessLogic;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace AnagramSolver.Website.Controllers
{
    [Route("{controller}/{action}/{filename}")]
    public class DownloadController : Controller
    {
        public FileResult DownloadFile(string filename)
        {
            //Build the File Path.
            string path = "C:\\Users\\rokas.cvirka\\Documents\\" + filename + ".txt";

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", filename + ".txt");
        }
    }
}
