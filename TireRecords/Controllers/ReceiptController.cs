﻿using Core.Entities;
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
        [Authorize]
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

                bool result = _receiptService.InsertReceipt(clientDto, vehicledDto, receiptDto, tires);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static List<TireDto> GetTires(FormCollection collection)
        {

            var tires = new List<TireDto>();

            var tireTL = new TireDto();
            var tireTR = new TireDto();
            var tireBL = new TireDto();
            var tireBR = new TireDto();

            tireTL.Position = PositionEnum.PL;
            tireTL.Brand = Convert.ToString(collection["tireBrandPL"]);
            tireTL.Model = Convert.ToString(collection["tireModelPL"]);
            tireTL.Dimension = Convert.ToString(collection["dimensionPL"]);
            tireTL.Index = Convert.ToString(collection["indexPL"]);
            tireTL.DOT = Convert.ToInt32(collection["dotPL"]);
            tireTL.Depth = Convert.ToDouble(collection["depthPL"]);

            tires.Add(tireTL);

            tireTR.Position = PositionEnum.PD;
            tireTR.Brand = Convert.ToString(collection["tireBrandPD"]);
            tireTR.Model = Convert.ToString(collection["tireModelPD"]);
            tireTR.Dimension = Convert.ToString(collection["dimensionPD"]);
            tireTR.Index = Convert.ToString(collection["indexPD"]);
            tireTR.DOT = Convert.ToInt32(collection["dotPD"]);
            tireTR.Depth = Convert.ToDouble(collection["depthPD"]);

            tires.Add(tireTR);

            tireBL.Position = PositionEnum.ZL;
            tireBL.Brand = Convert.ToString(collection["tireBrandZL"]);
            tireBL.Model = Convert.ToString(collection["tireModelZL"]);
            tireBL.Dimension = Convert.ToString(collection["dimensionZL"]);
            tireBL.Index = Convert.ToString(collection["indexZL"]);
            tireBL.DOT = Convert.ToInt32(collection["dotZL"]);
            tireBL.Depth = Convert.ToDouble(collection["depthZL"]);

            tires.Add(tireBL);

            tireBR.Position = PositionEnum.ZD;
            tireBR.Brand = Convert.ToString(collection["tireBrandZD"]);
            tireBR.Model = Convert.ToString(collection["tireModelZD"]);
            tireBR.Dimension = Convert.ToString(collection["dimensionZD"]);
            tireBR.Index = Convert.ToString(collection["indexZD"]);
            tireBR.DOT = Convert.ToInt32(collection["dotZD"]);
            tireBR.Depth = Convert.ToDouble(collection["depthZD"]);

            tires.Add(tireBR);

            return tires;
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