using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.DTOs
{
	public class CommandReadDTO
	{    
        public int id { get; set; }
        
        public string HowTo { get; set; }
       
        public string Line { get; set; }      
    }
}
