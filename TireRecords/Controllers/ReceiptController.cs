using Core.Entities;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
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
            string vehicleType = string.IsNullOrEmpty(Request.QueryString["vehicleType"]) ? "" : Request.QueryString["vehicleType"];
            TempData["vehicleType"] = vehicleType;

            var filter = new FilterDto();

            filter.FirstName = "";
            filter.LastName = "";
            filter.RegistrationNumber = "";
            filter.DateFrom = DateTime.Now.AddDays(-30);
            filter.DateTo = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            filter.VehicleType = string.IsNullOrEmpty(vehicleType) ? -1 : Convert.ToInt32(vehicleType);
            filter.RNumber = "";
            filter.Status = -1;

            var clientReceiptDtos = await _receiptService.SearchReceipts(filter);
            var clientReceiptViewModels = ClientReceiptViewModel.MapTo(clientReceiptDtos);


            return View(clientReceiptViewModels);
        }

        [Authorize]
        public async Task<ActionResult> Search(FormCollection collection)
        {
            var filter = new FilterDto();

            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("sr-RS");

            filter.FirstName = Convert.ToString(collection["firstName"]).Trim();
            filter.LastName = Convert.ToString(collection["lastName"]).Trim();
            filter.RegistrationNumber = Convert.ToString(collection["registrationNumber"]).Trim();
            filter.RNumber = Convert.ToString(collection["rnumber"]).Trim();
            filter.DateFrom = DateTime.Parse(collection["dateFrom"], cultureinfo);
            filter.DateTo = DateTime.Parse(collection["dateTo"], cultureinfo);
            filter.VehicleType = Convert.ToInt32(collection["vehicleType"]);
            filter.Status = Convert.ToInt32(collection["status"]);

            var clientReceiptDtos = await _receiptService.SearchReceipts(filter);
            var clientReceiptViewModels = ClientReceiptViewModel.MapTo(clientReceiptDtos);

            TempData["vehicleType"] = Convert.ToString(collection["vehicleType"]);

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
        public async Task<ActionResult> Create()
        {
            string vehicleId = Request.QueryString["id"];
            string vehicleType = Request.QueryString["type"];

            TempData["VehicleType"] = vehicleType;

            var clientAndVehicle = new ClientAndVehicleViewModel();

            if (string.IsNullOrEmpty(vehicleId))
            {
                clientAndVehicle.Client = new ClientViewModel();
                clientAndVehicle.Vehicle = new VehicleViewModel();

                return View(clientAndVehicle);
            }

            var clientAndVehicleDto = await _receiptService.GetClientAndVehicle(Convert.ToInt32(vehicleId));
            clientAndVehicle = ClientAndVehicleViewModel.MapTo(clientAndVehicleDto);

            return View(clientAndVehicle);
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

                string receiptNumber = _receiptService.GenerateReceiptNumber(receiptDto.CreatedAt);

                if (!string.IsNullOrEmpty(receiptNumber))
                {
                    receiptDto.RNumber = receiptNumber;

                    int receiptId = _receiptService.InsertReceipt(clientDto, vehicledDto, receiptDto, tires);
                    TempData["ReceiptId"] = receiptId;

                    return RedirectToAction("Index");
                }
                else
                {
                    throw new ArgumentException("Receipt create: Invalid receipt number!");
                }
            }
            catch (Exception ex)
            {
                TempData["ReceiptId"] = -1;
                _logger.Error(ex);
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
            var imagePaths = new List<string> { /*Server.MapPath("~/Content/images/pdf/vulco-logo.png"),*/ Server.MapPath("~/Content/images/pdf/logo.png") };

            int receiptType = Convert.ToInt32(Request.QueryString["type"]);

            try
            {
                var tempReceipt = TempData["Receipt"] as ReceiptDetailsViewModel;

                if (tempReceipt != null)
                {
                    pdf = PdfService.CreatePdf(tempReceipt, imagePaths, receiptType);
                    return File(pdf, "application/pdf");
                }
                else
                {
                    var receiptDetailsDto = await _receiptService.GetReceiptDetails(id);
                    var receiptDetailsViewModel = ReceiptDetailsViewModel.MapTo(receiptDetailsDto);

                    pdf = PdfService.CreatePdf(receiptDetailsViewModel, imagePaths, receiptType);

                    return File(pdf, "application/pdf");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                _logger.Error(ex);
                return new HttpStatusCodeResult(404);
            }
        }

        [Authorize]
        public ActionResult CloseReceipt(int id)
        {
            try
            {
                string closedBy = User.Identity.Name;
                bool result = _receiptService.CloseReceipt(id, closedBy);

                return Redirect("/Receipt/Details/" + id);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                _logger.Error(ex);
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
