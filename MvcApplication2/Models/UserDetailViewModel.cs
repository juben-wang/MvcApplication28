using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class UserDetailViewModel
    {
        public User User { get; set; }
        public List<Email> EmailList { get; set; }
    }
}