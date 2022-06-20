using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BanGame.Models;

namespace BanGame.Models
{
    public class Giohang
    {
        MydataDataContext data = new MydataDataContext();
        public int mamay { get; set; }

        [Display(Name = "Tên Máy")]
        public string tenmay { get; set; }
        [Display(Name = "Ảnh bìa")]
        public string hinh { get; set; }
        [Display(Name = "Giá bán")]
        public double giaban { get; set; }
        [Display(Name = "Số lượng")]
        public int iSoluong { get; set; }

        [Display(Name = "Thành tiền")]
        public double dThanhtien
        {
            get { return iSoluong * giaban; }
        }
        public Giohang(int id)
        {
            mamay = id;
            MayGame mayGame = data.MayGames.Single(n => n.mamay == mamay);
            tenmay = mayGame.tenmay;
            hinh = mayGame.hinh;
            giaban = double.Parse(mayGame.giaban.ToString());
            iSoluong = 1;
        }

    }
}