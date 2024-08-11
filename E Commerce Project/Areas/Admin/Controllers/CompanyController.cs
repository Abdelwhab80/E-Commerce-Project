using bulky.Models.Models;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Utility;
using E_Commerce_Project.Data;
using E_Commerce_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace E_Commerce_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]


    public class CompanyController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> Companys = _unitOfWork.CompanyRepository.GetAll().ToList();
           
            return View(Companys);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CompanyList = _unitOfWork.CompanyRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }); CompanyList = CompanyList;
            return View(new Company());
        }


        [HttpPost]
        public IActionResult Create(Company obj)
        {
            

                _unitOfWork.CompanyRepository.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Company Created Successfully";
                return RedirectToAction("Index");
            


            return View(obj);
        }



        public IActionResult Edit(int id)
        {
            Company Company = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
            IEnumerable<SelectListItem> CompanyList = _unitOfWork.CompanyRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CompanyList = CompanyList;
            return View(Company);
        }

        [HttpPost]
        public IActionResult Edit(Company obj)
        {
            

               
                _unitOfWork.CompanyRepository.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Company Updated Successfully";

                return RedirectToAction("Index");
            

        }
        public IActionResult Delete(int id)
        {
            Company Company = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
            if (Company == null)
            {
                return NotFound();
            }
            return View(Company);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deletepost(int id)
        {
            Company Company = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
            if (Company == null)
            {
                return NotFound();
            }
            _unitOfWork.CompanyRepository.Remove(Company);
            _unitOfWork.Save();
            TempData["Success"] = "Company Deleted Successfully";

            return RedirectToAction("Index");

        }

    }
}
