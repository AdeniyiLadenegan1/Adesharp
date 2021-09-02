using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Adesharp.Pages
{
    public class SuccessModel : PageModel
    {
       

        [BindProperty(SupportsGet = true)]
        public string fname { get; set; }

        [BindProperty(SupportsGet = true)]
        public string lname { get; set; }

        [BindProperty(SupportsGet = true)]
        public string email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string phone { get; set; }

        [BindProperty(SupportsGet = true)]
        public string gender { get; set; }

        [BindProperty(SupportsGet = true)]
        public string address { get; set; }


        [BindProperty(SupportsGet = true)]
        public string province { get; set; }


        [BindProperty(SupportsGet = true)]
        public string startMonth { get; set; }


        [BindProperty(SupportsGet = true)]
        public string motivation { get; set; }



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

            if (string.IsNullOrWhiteSpace(phone))
            {
                phone = "phone is Required";
            }

            if (string.IsNullOrWhiteSpace(gender))
            {
                gender = "Please state your gender";

            }
            if (string.IsNullOrWhiteSpace(startMonth))
            {
               startMonth = "Month of start is Required";

            }
            if (string.IsNullOrWhiteSpace(motivation))
            {
               motivation = "It is required you enter a reason for joining this training";
            }
                return Page();
            }
        }
    }

