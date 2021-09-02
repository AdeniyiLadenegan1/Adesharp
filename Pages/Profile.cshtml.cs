using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adesharp.Pages
{
    public class ProfileModel : PageModel
    {

        public const string SessionEmail = "_Email";
        public const string SessionFname = "_Fname";
        public const string SessionLname = "_Lname";

        const string SessionKeyTime = "_Time";

        public string SessionInfo_Email { get; private set; }

        public string SessionInfo_Fname { get; private set; }

        public string SessionInfo_Lname { get; private set; }
        public string SessionInfo_CurrentTime { get; private set; }


        public string SessionInfo_SessionTime { get; private set; }

        public string SessionInfo_MiddlewareValue { get; private set; }


        [BindProperty(SupportsGet = true)]
        public string fname { get; set; }

        [BindProperty(SupportsGet = true)]
        public string lname { get; set; }

        [BindProperty(SupportsGet = true)]
        public string email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string error { get; set; }


        public string profileError { get; set; } = "You need to log in";

        public string outMessage { get; set; }

        public IActionResult OnGet()
        {


            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionEmail)))

            {
                error = "Signin in or signup first";
                return RedirectToPage("/Signup", new { error });
            }
            else
            {
                email = HttpContext.Session.GetString(SessionEmail);
                fname = HttpContext.Session.GetString(SessionFname);
                lname = HttpContext.Session.GetString(SessionLname);

                return Page();
            }
        }
    }

}

