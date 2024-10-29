using CandidateManagement_BussinesObject;
using CandidateManagement_Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CandidateManagement_MaiVanQuocTinh.Pages
{
    public class LoginModel : PageModel
    {
        private IHRAccountService _hraccountService;

        public LoginModel(IHRAccountService hraccountService)
        {
            _hraccountService = hraccountService;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            String email = Request.Form["txtEmail"];
            String password = Request.Form["txtPassword"];
            Hraccount? hraccount = _hraccountService.GetHraccountByEmail(email);
            if (hraccount != null && hraccount.Password == password)
            {
                HttpContext.Session.SetString("RoleID", hraccount.MemberRole.ToString());
                Response.Redirect("/CandidateProfilePage");
            }
            else
            {
                Response.Redirect("/Error");
            }
        }
    }
}
