using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkRun.UtilizeApp.Models;
using System.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using MilkRun.UtilizeApp.ViewModel;
using X.PagedList;
namespace CromulentBisgetti.DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MilkRunDbContext _db;
        public AppDataUser AppDataUserState = null;
        public HomeController(MilkRunDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        private PackagingPartVM GetPackagingPart(int pageIndex)
        {
            PackagingPartVM model = new PackagingPartVM();
            model.PageIndex = pageIndex;
            model.PageSize = 10;
            model.RecordCount = _db.Tbl_Packaging_Part.Count();
            int startIndex = (pageIndex - 1) * model.PageSize;

            model.AppPackagingParts = (from n in _db.Tbl_Packaging_Part select n)
                        .Skip(startIndex)
                            .Take(model.PageSize).ToList();
            return model;
        }

        //[Route("PackagingPart:{}")]
        //[HttpGet("{id}")]
        public IActionResult PackagingPart(int? currentPageIndex)
        {
            var pageNumber = currentPageIndex ?? 1;
            ViewBag.lstPackagingPart = _db.Tbl_Packaging_Part.ToPagedList(currentPageIndex.HasValue ? currentPageIndex.Value : 1, 10);
            return View();
        }
        public IActionResult Login()
        {
            return View(new LoginModels());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return View("login", "home");
        }
        [HttpPost]
        public IActionResult SignIn(LoginModels loginDetails)
        {
            if (loginDetails != null && !string.IsNullOrEmpty(loginDetails.Email) && !string.IsNullOrEmpty(loginDetails.Password))
            {
                var userExists = _db.Data_User.FirstOrDefault(x => x.Username.ToLower() == loginDetails.Email.ToLower() && x.Password.ToLower() == loginDetails.Password.ToLower());
                if (userExists != null)
                {
                    AppDataUserState = userExists;
                    HttpContext.Session.SetString("UserId", userExists.UserId.ToString());
                    HttpContext.Session.SetString("Username", userExists.Username.ToString());
                    return Json("LoggedIn");
                }
                else
                {
                    AppDataUserState = null;
                    return Json("Invalid Credentials");

                }
            }
            return Json("LoggedIn");
        }

        public ActionResult Add()
        {
            //if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            //{

            return View(new AppPackagingPart());
            //}
            //else
            //{
            //    return View("login", "home");
            //}
        }
        [HttpPost]
        public ActionResult Add(AppPackagingPart mdata)
        {
            AppPackagingPart mdataMode = new AppPackagingPart();
            mdataMode.Part_No = mdata.Part_No;
            mdataMode.APROS_Part_No = mdata.APROS_Part_No;
            mdataMode.Part_Name = mdata.Part_Name;
            mdataMode.Supplier_Code = mdata.Supplier_Code;
            mdataMode.SUPPLIER_NAME = mdata.SUPPLIER_NAME;
            mdataMode.Packaging_Type = mdata.Packaging_Type;
            mdataMode.SNP = mdata.SNP;
            mdataMode.Packaging_WIDTH = mdata.Packaging_WIDTH;
            mdataMode.Packaging_LENGTH = mdata.Packaging_LENGTH;
            mdataMode.Packaging_HEIGHT = mdata.Packaging_HEIGHT;
            mdataMode.Packaging_WEIGHT = mdata.Packaging_WEIGHT;
            mdataMode.ITEM_WEIGHT = mdata.ITEM_WEIGHT;
            mdataMode.Packaging_Pallet_Type = mdata.Packaging_Pallet_Type;
            mdataMode.Status = mdata.Status;
            mdata.Create_Date = DateTime.Now;
            _db.Tbl_Packaging_Part.Add(mdataMode);
            _db.SaveChanges();
            return Json(mdataMode.Part_No);
        }
        [HttpGet]
        public ActionResult Edit(string Id)
        {
            //if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))){

            string PartNo = Convert.ToString(Id);
            AppPackagingPart model = new AppPackagingPart();
            model = _db.Tbl_Packaging_Part.Where(x => x.Part_No == PartNo).FirstOrDefault();
            return View(model);
            //}
            //else
            //{
            //    return View("login", "home");
            //}

        }
        [HttpPost]
        public ActionResult Edit(AppPackagingPart employeedetail)
        {
            try
            {

                var rowsAffected = _db.Database.ExecuteSqlCommand($"UPDATE [Tbl_Packaging_Part] SET [Part_No]='{employeedetail.Part_No}',[APROS_Part_No]='{employeedetail.APROS_Part_No}',Part_Name='{employeedetail.Part_Name}',Supplier_Code='{employeedetail.Supplier_Code}',SUPPLIER_NAME = '{employeedetail.SUPPLIER_NAME}',Packaging_Type='{employeedetail.Packaging_Type}',SNP={employeedetail.SNP},Packaging_WIDTH={employeedetail.Packaging_WIDTH},Packaging_LENGTH={employeedetail.Packaging_LENGTH},Packaging_HEIGHT={employeedetail.Packaging_HEIGHT},Packaging_WEIGHT={employeedetail.Packaging_WEIGHT},ITEM_WEIGHT={employeedetail.ITEM_WEIGHT},Packaging_Pallet_Type={employeedetail.Packaging_Pallet_Type},Status={employeedetail.Status} WHERE Part_No='{employeedetail.Part_No}'");
            }
            catch (Exception ex)
            {
                return Json(string.Empty);
            }
            return Json(employeedetail.Part_No);
        }

        [HttpGet]
        public ActionResult Delete(string Id)
        {

            //if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))){

            string PartNo = Convert.ToString(Id);

            try
            {
                _db.Database.ExecuteSqlCommand($"delete from [Tbl_Packaging_Part] where Part_No={Id}");
            }
            catch (Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View("login", "home");
            //}


        }
    }
}