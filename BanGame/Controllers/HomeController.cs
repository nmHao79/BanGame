using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanGame.Models;
using PagedList;

namespace BanGame.Controllers
{
    public class HomeController : Controller
    {
        MydataDataContext data = new MydataDataContext();
        public ActionResult Index(int? page)
        {
            if (page == null) page = 1;
            var all_maygame = (from s in data.MayGames select s).OrderBy(m => m.mamay);
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(all_maygame.ToPagedList(pageNum, pageSize));

        }
    }
}