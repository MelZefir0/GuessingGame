using GuessingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessingGame.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            Session["answer"] = new Random().Next(1, 10);

            return View();
        }

        private bool GuessWasCorrect(int guess) =>
            // c# Doing a cast in C# is telling the compiler to do an explicit conversion to convert 
            //the type of an object from one to another, and by explicit it means that you are aware 
            //that data may be truncated during the operation. (int)
            guess == (int)Session["answer"];

        //Learn more about httppost
        [HttpPost]
        public ActionResult Index(GameModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Win = GuessWasCorrect(model.Guess);
            }

            return View(model);
        }
    }
}