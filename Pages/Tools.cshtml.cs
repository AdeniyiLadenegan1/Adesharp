using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adesharp.Models;
using Adesharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Adesharp.Pages
{

    public class ToolsModel : PageModel
    {
        public ToolService toolservice;
        public IEnumerable<Tool> Tools { get; private set; }
        private readonly ILogger<ToolsModel> _logger;

        public ToolsModel(ILogger<ToolsModel> logger, ToolService ts)
        {
            _logger = logger;
            toolservice = ts;
        }
        public string messages;
     

        public void OnGet()
        {
            Tools = toolservice.GetTools();
            //messages = "Message from CS";
        }
    }
}



