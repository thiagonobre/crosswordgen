using System;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using CrosswordGen.Model;
using CrosswordGen.Models;

namespace CrosswordGen.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["Width"] = 30;
            ViewData["Height"] = 15;
            return View();
        }

        [HttpGet]
        public ActionResult Generate()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Generate(string words, ushort width = 30, ushort height = 30)
        {
            if (String.IsNullOrEmpty(words))
            {
                return RedirectToAction("Index", "Home");
            }
            string[] input = words.Split('\n');

            for (ushort i = 0; i < input.Length; i++)
            {
                input[i] = Regex.Replace(input[i], "[^\\w\\d]", "");
            }

            Canvas canvas = new CrosswordFactory(input, width, height, true).createCanvas();

            canvas.Build();

            ICanvasWriter canvasWriter = new HtmlCanvasWriter();

            ViewData["Width"] = width;
            ViewData["Height"] = height;
            ViewData["Words"] = words;
            ViewData["Canvas"] = canvas;
            ViewData["CanvasWriter"] = canvasWriter;

            return View("Index");
        }

    }
}
