using Core.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TireRecords.Models;
using TireRecords.Services;

namespace TireRecords.Controllers
{
    public class ReceiptController : Controller
    {
        private ReceiptService _receiptService;
        public ReceiptController()
        {
            _receiptService = new ReceiptService(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        // GET: Receipt
        public ActionResult Index()
        {
            return View();
        }

        // GET: Receipt/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Receipt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receipt/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // Client
                var client = new ClientViewModel();

                client.FirstName = Convert.ToString(collection["firstName"]);
                client.LastName = Convert.ToString(collection["lastName"]);
                client.MobilePhone = Convert.ToString(collection["mobilePhone"]);
                client.Email = Convert.ToString(collection["email"]);

                var clientDto = ClientViewModel.MapFrom(client);
                int clientId = _receiptService.InsertClient(clientDto);

                // Vehicle
                var vehicle = new VehicleViewModel();

                vehicle.Brand = Convert.ToString(collection["vehicleBrand"]);
                vehicle.RegistrationNumber = Convert.ToString(collection["registrationNumber"]);
                vehicle.ClientId = clientId;

                var vehicledDto = VehicleViewModel.MapFrom(vehicle);
                int vehicleId = _receiptService.InsertVehicle(vehicledDto);

                // Receipt
                var receipt = new ReceiptViewModel();
                //int rows = _receiptService.CountReceiptRows();
                int rows = new Random().Next(1, 100);

                receipt.Number = rows;
                receipt.Message = Convert.ToString(collection["message"]);
                receipt.UserName = User.Identity.Name;
                receipt.CreatedAt = DateTime.Now;
                receipt.ClientId = clientId;
                receipt.VehicleId = vehicleId;

                var receiptDto = ReceiptViewModel.MapFrom(receipt);
                int receiptId = _receiptService.InsertReceipt(receiptDto);

                // Tires
                var tireTL = new TireViewModel();
                var tireTR = new TireViewModel();
                var tireBL = new TireViewModel();
                var tireBR = new TireViewModel();

                tireTL.Position = PositionEnum.PL;
                tireTL.Brand = Convert.ToString(collection["tireBrandPL"]);
                tireTL.Model = Convert.ToString(collection["tireModelPL"]);
                tireTL.Dimension = Convert.ToString(collection["dimensionPL"]);
                tireTL.Index = Convert.ToString(collection["indexPL"]);
                tireTL.DOT = Convert.ToInt32(collection["dotPL"]);
                tireTL.Depth = Convert.ToDouble(collection["depthPL"]);
                tireTL.ReceiptId = receiptId;
                tireTL.VehicleId = vehicleId;

                tireTR.Position = PositionEnum.PD;
                tireTR.Brand = Convert.ToString(collection["tireBrandPD"]);
                tireTR.Model = Convert.ToString(collection["tireModelPD"]);
                tireTR.Dimension = Convert.ToString(collection["dimensionPD"]);
                tireTR.Index = Convert.ToString(collection["indexPD"]);
                tireTR.DOT = Convert.ToInt32(collection["dotPD"]);
                tireTR.Depth = Convert.ToDouble(collection["depthPD"]);
                tireTR.ReceiptId = receiptId;
                tireTR.VehicleId = vehicleId;

                tireBL.Position = PositionEnum.ZL;
                tireBL.Brand = Convert.ToString(collection["tireBrandZL"]);
                tireBL.Model = Convert.ToString(collection["tireModelZL"]);
                tireBL.Dimension = Convert.ToString(collection["dimensionZL"]);
                tireBL.Index = Convert.ToString(collection["indexZL"]);
                tireBL.DOT = Convert.ToInt32(collection["dotZL"]);
                tireBL.Depth = Convert.ToDouble(collection["depthZL"]);
                tireBL.ReceiptId = receiptId;
                tireBL.VehicleId = vehicleId;

                tireBR.Position = PositionEnum.ZD;
                tireBR.Brand = Convert.ToString(collection["tireBrandZD"]);
                tireBR.Model = Convert.ToString(collection["tireModelZD"]);
                tireBR.Dimension = Convert.ToString(collection["dimensionZD"]);
                tireBR.Index = Convert.ToString(collection["indexZD"]);
                tireBR.DOT = Convert.ToInt32(collection["dotZD"]);
                tireBR.Depth = Convert.ToDouble(collection["depthZD"]);
                tireBR.ReceiptId = receiptId;
                tireBR.VehicleId = vehicleId;

                var tireTLDto = TireViewModel.MapFrom(tireTL);
                var tireTRDto = TireViewModel.MapFrom(tireTR);
                var tireBLDto = TireViewModel.MapFrom(tireBL);
                var tireBRDto = TireViewModel.MapFrom(tireBR);

                var tires = new List<TireDto>();
                
                tires.Add(tireTLDto);
                tires.Add(tireTRDto);
                tires.Add(tireBLDto);
                tires.Add(tireBRDto);

                bool result = _receiptService.InsertTires(tires);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Receipt/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Receipt/Edit/5
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

        // GET: Receipt/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Receipt/Delete/5
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
