using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adesharp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Adesharp.Pages
{
    public class SignupModel : PageModel
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


        [BindProperty(SupportsGet = true)]

        public string error { get; set; }


        [BindProperty(SupportsGet = true)]
        public string profileError { get; set; }

        [BindProperty(SupportsGet = true)]

        public string outMessage { get; set; }

        public bool signed { get; set; }

        public void OnGet()

        {
        }
        public IActionResult OnPost()
        {
            if (user.type == "login")
            {
                //login

                SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdesharpDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                string query = "SELECT * FROM [AdesharpDB].[dbo].[User] WHERE email = '" + user.email + "' AND password ='" + user.password + "' ";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    //signed = true;

                    user.fname = string.Format("{0}", reader[1]);
                    user.lname = string.Format("{0}", reader[2]);
                    HttpContext.Session.SetString(SessionEmail, user.email);
                    HttpContext.Session.SetString(SessionFname, user.fname);
                    HttpContext.Session.SetString(SessionLname, user.lname);

                    return RedirectToPage("/Profile", new { user.fname, user.lname, user.email });

                }
                else
                {
                    error = "User doesnt exit, please check details and try again";
                    return RedirectToPage("/Signup", new { error });
                }
            }
            else
            {

                if (ModelState.IsValid == false)
                {
                    return Page();
                }
                else
                {

                    SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdesharpDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                    string query = "SELECT * FROM [AdesharpDB].[dbo].[User] WHERE email = '" + user.email +  "'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())

                    {
                        error = "this email exists already";
                        return RedirectToPage("/Signup", new { error });
                    }
                    else
                    {

                        //signup
                        //DB Stuff
                        SqlConnection cond = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdesharpDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                        String sql = "INSERT INTO [AdesharpDB].[dbo].[User] ([firstName],[lastName],[email],[password]) VALUES ('" + user.fname + "' , '" + user.lname + "' , '" + user.email + "' , '" + user.password + "' )";
                        //executing the sql statement
                        SqlCommand cmd1 = new SqlCommand(sql, cond);
                        cond.Open();
                        cmd1.ExecuteNonQuery();
                        cond.Close();
                        HttpContext.Session.SetString(SessionEmail, user.email);
                        HttpContext.Session.SetString(SessionFname, user.fname);
                        HttpContext.Session.SetString(SessionLname, user.lname);
                        return RedirectToPage("/Profile", new { user.fname, user.lname, user.email });


                    }
                }
            }
        }

    }

}