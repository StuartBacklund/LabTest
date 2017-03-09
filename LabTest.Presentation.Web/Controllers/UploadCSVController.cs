using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabTest.Presentation.Web.Helpers;
using LabTest.Presentation.Web.ViewModels;

namespace LabTest.Presentation.Web.Controllers
{
    public class UploadCSVController : Controller
    {
        // GET: UploadCSV
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        [ActionName("UploadFile")]
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase FileUpload)
        {
            var vmList = new List<UploadFileViewModel>();

            if (FileUpload.ContentLength > 0)
            {
                string path1 = $"{Server.MapPath("~/Content/Uploads")}/{Request.Files["FileUpload"].FileName}";

                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/Uploads"));
                }
                Request.Files["FileUpload"].SaveAs(path1);

                var uploadedContent = ApplicationHelpers.UploadCSVtoArray(FileUpload);
                int recNum = 1;

                foreach (var record in uploadedContent)
                {
                    if (record.Length > 1)
                    {
                        var list = ApplicationHelpers.ConvertStringToIntArray(record);
                        var mostCommon = list.MostCommon();
                        var occurringNumber = list.GetMaxOccurrence();
                        var calulatedResult = ApplicationHelpers.CalculateResult(list.Count(), occurringNumber);

                        var vm = new UploadFileViewModel()
                        {
                            Id = recNum,
                            Parameters = ApplicationHelpers.BuildString(list),
                            MaxOccurringNumber = mostCommon,
                            Occurrences = occurringNumber,
                            Result = calulatedResult,
                            Message = (calulatedResult == 1) ? "Success" : "Failure",
                        };
                        vmList.Add(vm);
                        recNum++;
                    }
                }
                return View(vmList);
            }

            return RedirectToAction("Index", new { error = "Please upload a file..." });
        }

        // GET: UploadCSV/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UploadCSV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UploadCSV/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UploadCSV/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UploadCSV/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UploadCSV/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UploadCSV/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}