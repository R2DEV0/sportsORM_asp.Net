using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context context;

        public HomeController(Context DBContext)
        {
            context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = context.Leagues
                .Where(l => l.Sport.Contains("Baseball"));
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = context.Leagues.Where(l => l.Name.ToLower().Contains("women") || l.Name.ToLower().Contains("womens"));

            ViewBag.hockeySports = context.Leagues.Where(l => l.Sport.ToLower().Contains("hockey"));

            ViewBag.notFootball = context.Leagues.Where(l => !l.Sport.ToLower().Contains("football"));

            ViewBag.conferences = context.Leagues.Where(l => l.Name.ToLower().Contains("conferences") || l.Name.ToLower().Contains("conference"));

            ViewBag.atlantic = context.Leagues.Where(l => l.Name.Contains("Atlantic"));

            ViewBag.Dallas = context.Teams.Where(t => t.Location.Contains("Dallas"));

            ViewBag.raptors = context.Teams.Where(t => t.TeamName.ToLower().Contains("raptors"));

            ViewBag.city = context.Teams.Where(t => t.Location.ToLower().Contains("city"));

            ViewBag.tName = context.Teams.Where(t => t.TeamName.ToLower().StartsWith('t'));

            ViewBag.locationOrder = context.Teams.OrderBy(t => t.Location);

            ViewBag.nameOrder = context.Teams.OrderByDescending(t => t.TeamName);

            ViewBag.Cooper = context.Players.Where(p => p.LastName.Contains("Cooper"));

            ViewBag.Joshua = context.Players.Where(p => p.FirstName.Contains("Joshua"));

            ViewBag.CooperNotJoshua = context.Players.Where(p => p.LastName.Contains("Cooper") && !p.FirstName.Contains("Joshua"));

            ViewBag.AlexanderOrWyatt = context.Players.Where(p => p.FirstName.Contains("Alexander") || p.FirstName.Contains("Wyatt"));

            return View();
        }




        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}