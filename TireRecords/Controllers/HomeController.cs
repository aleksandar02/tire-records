using Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TireRecords.Models;

namespace TireRecords.Controllers
{
    public class HomeController : Controller
    {
        private ReceiptDAL _receiptDAL;

        public HomeController()
        {
            _receiptDAL = new ReceiptDAL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        [Authorize]
        public async Task<ActionResult> Index()
        {
            var dataCount = new DataCountViewModel();
            var dataCountDto = await _receiptDAL.GetDataCount();

            dataCount = DataCountViewModel.MapTo(dataCountDto);

            return View(dataCount);
        }
    }
}