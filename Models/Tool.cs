using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Adesharp.Models
{
    public class Tool
    {

    public string equipment { get; set; }

    public string sizes { get; set; }

    public string model { get; set; }
    public string price { get; set; }

    public string country { get; set; }

  
    public string year { get; set; }

    public string guarantee { get; set; }


    public string description { get; set; }

    public string website { get; set; }

    public override string ToString()
        => JsonSerializer.Serialize<Tool>(this);


}
}
    
