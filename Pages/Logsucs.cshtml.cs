using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adesharp.Pages
{
    public class LogsucsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string fname { get; set; }

        [BindProperty(SupportsGet = true)]
        public string lname { get; set; }

        [BindProperty(SupportsGet = true)]

        public string phone { get; set; }

        [BindProperty(SupportsGet = true)]
        public string email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string subject { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string message { get; set; }



        public IActionResult OnGet()
        {
            if (string.IsNullOrWhiteSpace(fname))
            {
                fname = "User";
            }
            if (string.IsNullOrWhiteSpace(lname))
            {
                lname = "User";
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                email = "Email is Required";
            }
            if (string.IsNullOrWhiteSpace(subject))
            {
                subject = "User";
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                phone = "phone is Required";
            }

            if (string.IsNullOrWhiteSpace(message))
            {
                message = "Send a message";
            }
            return Page();
        }
    }
}
