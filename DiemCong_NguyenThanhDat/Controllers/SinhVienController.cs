using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiemCong_NguyenThanhDat.Models;

namespace DiemCong_NguyenThanhDat.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        Test01DataDataContext data = new Test01DataDataContext();
        public ActionResult ListSinhVien()
        {
            var allSV = from sv in data.SinhViens select sv;
            return View(allSV);
        }
        public ActionResult Detail(string id)
        {
            var detailSV = data.SinhViens.Where(s => s.MaSV == id).First();
            return View(detailSV);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var hoten = collection["hoten"];
            var gioitinh = collection["gioitinh"];
            var ngaysinh = string.Format("{0:MM/dd/yyyy}", (collection["ngaysinh"]));
            var hinh = collection["hinh"];
            var manganh = collection["manganh"];
            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sv.HoTen = hoten.ToString();
                sv.GioiTinh = gioitinh.ToString();
                sv.NgaySinh = DateTime.Parse(ngaysinh);
                sv.Hinh = hinh.ToString();
                sv.MaNganh = manganh.ToString();
                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var editSV = data.SinhViens.First(s => s.MaSV == id);
            return View(editSV);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var masv = data.SinhViens.First(s => s.MaSV == id);
            var hoten = collection["hoten"];
            var gioitinh = collection["gioitinh"];
            var ngaysinh = Convert.ToDateTime(collection["ngaysinh"]);
            var hinh = collection["hinh"];
            var manganh = collection["manganh"];
            masv.MaSV = id;
            if (string.IsNullOrEmpty(hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                masv.HoTen = hoten;
                masv.GioiTinh = gioitinh;
                masv.NgaySinh = ngaysinh;
                masv.Hinh = hinh;
                masv.MaNganh = manganh;
                UpdateModel(masv);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Edit(id);
        }
        //-----------------------------------------
        public ActionResult Delete(string id)
        {
            var deleteSV = data.SinhViens.First(s => s.MaSV == id);
            return View(deleteSV);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var deleteSV = data.SinhViens.Where(s => s.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(deleteSV);
            data.SubmitChanges();
            return RedirectToAction("ListSinhVien");
        }
        //-----------------------------------------
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
