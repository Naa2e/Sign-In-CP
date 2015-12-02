using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Check_In.Models
{
    public class Teachers
    {
            [Key]
            public int TeacherId { get; set; }
            public string Name { get; set; }
            public ApplicationUser Charlene { get; set; }

       

        }
    }