using Core.Entities;
using NLog;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TireRecords.Models;
using TireRecords.Services;

namespace TireRecords.Controllers
{
    public class ReceiptController : Controller
    {
        private ReceiptService _receiptService;

        private static Logger _logger = LogManager.GetCurrentClassLogger();
        public ReceiptController()
        {
            _receiptService = new ReceiptService(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var filter = new FilterDto();

            _logger.Info("{user} visited ReceiptController.Index", User.Identity.Name);

            filter.FirstName = "";
            filter.LastName = "";
            filter.RegistrationNumber = "";
            filter.DateFrom = DateTime.Now.AddDays(-30);
            filter.DateTo = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            var clientReceiptDtos = await _receiptService.SearchReceipts(filter);
            var clientReceiptViewModels = ClientReceiptViewModel.MapTo(clientReceiptDtos);

            return View(clientReceiptViewModels);
        }

        [Authorize]
        public async Task<ActionResult> Search(FormCollection collection)
        {
            var filter = new FilterDto();

            filter.FirstName = Convert.ToString(collection["firstName"]).Trim();
            filter.LastName = Convert.ToString(collection["lastName"]).Trim();
            filter.RegistrationNumber = Convert.ToString(collection["registrationNumber"]).Trim();
            filter.DateFrom = Convert.ToDateTime(collection["dateFrom"]);
            filter.DateTo = Convert.ToDateTime(collection["dateTo"]);

            var clientReceiptDtos = await _receiptService.SearchReceipts(filter);
            var clientReceiptViewModels = ClientReceiptViewModel.MapTo(clientReceiptDtos);

            return View("Index", clientReceiptViewModels);
        }

        [Authorize]
        public async Task<ActionResult> Details(int id)
        {
            var receiptDetailsDto = await _receiptService.GetReceiptDetails(id);
            var receiptDetailsViewModel = ReceiptDetailsViewModel.MapTo(receiptDetailsDto);

            TempData["Receipt"] = receiptDetailsViewModel;


            return View(receiptDetailsViewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var clientDto = ClientViewModel.MapFrom(collection);
                var vehicledDto = VehicleViewModel.MapFrom(collection);
                var receiptDto = ReceiptViewModel.MapFrom(collection, User.Identity.Name);
                var tires = GetTires(collection);

                int receiptId = _receiptService.InsertReceipt(clientDto, vehicledDto, receiptDto, tires);
                TempData["ReceiptId"] = receiptId;


                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ReceiptId"] = -1;
                return RedirectToAction("Index");
            }
        }

        private static List<TireDto> GetTires(FormCollection collection)
        {

            var tires = new List<TireDto>();

            var tireTL = new TireDto();
            var tireTR = new TireDto();
            var tireBL = new TireDto();
            var tireBR = new TireDto();

            tireTL.Position = (int)PositionEnum.PL;
            tireTL.Brand = Convert.ToString(collection["tireBrandPL"]);
            tireTL.Model = Convert.ToString(collection["tireModelPL"]);
            tireTL.Dimension = Convert.ToString(collection["dimensionPL"]);
            tireTL.Index = Convert.ToString(collection["indexPL"]);
            tireTL.DOT = Convert.ToInt32(collection["dotPL"]);
            tireTL.Depth = Convert.ToDouble(collection["depthPL"]);

            tires.Add(tireTL);

            tireTR.Position = (int)PositionEnum.PD;
            tireTR.Brand = Convert.ToString(collection["tireBrandPD"]);
            tireTR.Model = Convert.ToString(collection["tireModelPD"]);
            tireTR.Dimension = Convert.ToString(collection["dimensionPD"]);
            tireTR.Index = Convert.ToString(collection["indexPD"]);
            tireTR.DOT = Convert.ToInt32(collection["dotPD"]);
            tireTR.Depth = Convert.ToDouble(collection["depthPD"]);

            tires.Add(tireTR);

            tireBL.Position = (int)PositionEnum.ZL;
            tireBL.Brand = Convert.ToString(collection["tireBrandZL"]);
            tireBL.Model = Convert.ToString(collection["tireModelZL"]);
            tireBL.Dimension = Convert.ToString(collection["dimensionZL"]);
            tireBL.Index = Convert.ToString(collection["indexZL"]);
            tireBL.DOT = Convert.ToInt32(collection["dotZL"]);
            tireBL.Depth = Convert.ToDouble(collection["depthZL"]);

            tires.Add(tireBL);

            tireBR.Position = (int)PositionEnum.ZD;
            tireBR.Brand = Convert.ToString(collection["tireBrandZD"]);
            tireBR.Model = Convert.ToString(collection["tireModelZD"]);
            tireBR.Dimension = Convert.ToString(collection["dimensionZD"]);
            tireBR.Index = Convert.ToString(collection["indexZD"]);
            tireBR.DOT = Convert.ToInt32(collection["dotZD"]);
            tireBR.Depth = Convert.ToDouble(collection["depthZD"]);

            tires.Add(tireBR);

            return tires;
        }

        [Authorize]
        public async Task<ActionResult> ExportPdf(int id)
        {
            var pdf = new byte[0];
            var imagePaths = new List<string> { Server.MapPath("~/Content/images/pdf/vulco-logo.png"), Server.MapPath("~/Content/images/pdf/logo.png") };

            try
            {
                var tempReceipt = TempData["Receipt"] as ReceiptDetailsViewModel;

                if (tempReceipt != null)
                {
                    pdf = PdfService.CreatePdf(tempReceipt, imagePaths);
                    return File(pdf, "application/pdf");
                }
                else
                {
                    var receiptDetailsDto = await _receiptService.GetReceiptDetails(id);
                    var receiptDetailsViewModel = ReceiptDetailsViewModel.MapTo(receiptDetailsDto);

                    pdf = PdfService.CreatePdf(receiptDetailsViewModel, imagePaths);

                    return File(pdf, "application/pdf");
                }



            }
            catch (Exception ex)
            {
                string message = ex.Message;

                return new HttpStatusCodeResult(404);
            }
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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
    }
}
