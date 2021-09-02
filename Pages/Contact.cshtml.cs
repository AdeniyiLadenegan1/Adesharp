using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adesharp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Adesharp.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact contact { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            } else
            {

                //Database
                SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdesharpDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                string sql = "INSERT INTO [AdesharpDB].[dbo].[Contact] ([firstName], [lastName], [email], [phone], [subject], [message]) VALUES ('" + contact.fname + "' , '" + contact.lname + "' , '" + contact.email + "' , '" + contact.phone + "' , '" + contact.subject + "' , '" + contact.message + "')";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToPage("/Logsucs", new { contact.fname, contact.lname, contact.email, 
                    contact.phone, contact.subject, contact.message });
            }
        }
    }
}
