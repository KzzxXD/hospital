using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hospital2.Models
{
    public class Skil
    {
        
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Text { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
       

    }
   
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string NameService { get; set; }
        public string TextService { get; set; }        
        public string FaFaIcon { get; set; }
    }
}