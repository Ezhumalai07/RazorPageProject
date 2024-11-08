using Hub.Model;
using Hub.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hub.Pages.Companies
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
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
            var onjFromDb = _unitOfWork.Company.Get(x => x.Id == Company.Id);
            if (onjFromDb != null)
            {
                _unitOfWork.Company.Remove(onjFromDb);
                _unitOfWork.save();
                return RedirectToPage("Index");
            }
            return Page();
        }


    }
}
