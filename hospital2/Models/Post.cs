using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hospital2.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace hospital2.Models
{
    
    public class Post
    {      

        [DataType(DataType.MultilineText)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SmalText { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
    }
    public class PageInfo
    {
        public int PageNumber { get; set; } // номер текущей страницы
        public int PageSize { get; set; } // кол-во объектов на странице
        public int TotalItems { get; set; } // всего объектов
        public int TotalPages  // всего страниц
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class NewsIndexView
    {
        public IEnumerable<Post> Posts { get; set; }
        public PageInfo PageInfo { get; set; }
    }

}