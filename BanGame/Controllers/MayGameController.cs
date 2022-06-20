using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanGame.Models;
namespace BanGame.Controllers
{
    public class MayGameController : Controller
    {
        MydataDataContext data = new MydataDataContext();
        // GET: MayGame

        public ActionResult ListMayGame()
        {
            var all_maygame = from mg in data.MayGames select mg;
            return View(all_maygame);
        }
        public ActionResult Detail(int id)
        {
            var d_mg = data.MayGames.Where(m => m.mamay == id).First();
            return View(d_mg);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, MayGame s)
        {
            var E_tenmay = collection["tenmay"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhap = Convert.ToDateTime(collection["ngaycapnhap"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            if (string.IsNullOrEmpty(E_tenmay))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                s.tenmay = E_tenmay.ToString();
                s.hinh = E_hinh.ToString();
                s.giaban = E_giaban;
                s.ngaycapnhap = E_ngaycapnhap;
                s.soluongton = E_soluongton;
                data.MayGames.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("ListMayGame");
            }
            return this.Create();
        }
        public ActionResult Edit(int id)
        {
            var E_MayGame = data.MayGames.First(m => m.mamay == id);
            return View(E_MayGame);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_maygame = data.MayGames.First(m => m.mamay == id);
            var E_tenmay = collection["tenmay"];
            var E_hinh = collection["hinh"];
            var E_giaban = Convert.ToDecimal(collection["giaban"]);
            var E_ngaycapnhap = Convert.ToDateTime(collection["ngaycapnhap"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            E_maygame.mamay = id;
            if (string.IsNullOrEmpty(E_tenmay))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_maygame.tenmay = E_tenmay;
                E_maygame.hinh = E_hinh;
                E_maygame.giaban = E_giaban;
                E_maygame.ngaycapnhap = E_ngaycapnhap;
                E_maygame.soluongton = E_soluongton;
                UpdateModel(E_maygame);
                data.SubmitChanges();
                return RedirectToAction("ListMayGame");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(int id)
        {
            var E_maygame = data.MayGames.First(m => m.mamay == id);
            return View(E_maygame);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var E_maygame = data.MayGames.Where(m => m.mamay == id).First();
            data.MayGames.DeleteOnSubmit(E_maygame);
            data.SubmitChanges();
            return RedirectToAction("ListMayGame");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}