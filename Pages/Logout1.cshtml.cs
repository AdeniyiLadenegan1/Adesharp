using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adesharp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adesharp.Pages
{
    public class Logout1Model : PageModel
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




            [BindProperty]

            public User user { get; set; }

            public string outMessage { get; set; } = "You logged out successfully!";
            public IActionResult OnGet()
            {

                HttpContext.Session.SetString(SessionEmail, "");
                HttpContext.Session.SetString(SessionFname, "");
                HttpContext.Session.SetString(SessionLname, "");
                // always delete session variables
                return RedirectToPage("/Signup", new { outMessage });


            }
        }
    }







