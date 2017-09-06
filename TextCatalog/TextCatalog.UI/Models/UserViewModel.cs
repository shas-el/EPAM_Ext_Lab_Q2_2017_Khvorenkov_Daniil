using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TextCatalog.DAL.Model;

namespace TextCatalog.UI.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<Text> Texts { get; set; }
    }
}