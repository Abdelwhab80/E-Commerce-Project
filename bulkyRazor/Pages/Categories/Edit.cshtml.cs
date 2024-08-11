using bulkyRazor.Data;
using bulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bulkyRazor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            category = _db.Categories.Find(id);
        }
        public IActionResult OnPost()
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["Success"] = "Category Updated Successfully";

            return RedirectToPage("Index");

        }
    }
}
