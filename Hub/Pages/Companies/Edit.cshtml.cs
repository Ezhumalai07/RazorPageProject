using Hub.Model;
using Hub.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hub.Pages.Companies
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Company Company { get; set; }
        public void OnGet(int id)
        {
            Company = _unitOfWork.Company.Get(x => x.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Company.Update(Company);
                _unitOfWork.save();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
