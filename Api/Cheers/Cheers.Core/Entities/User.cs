﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheers.Core.Entities
{
  public  class User
    {

        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // נשמור רק את ה-Hash של הסיסמה
        public string Role { get; set; } = "User"; // ברירת מחדל: משתמש רגיל

    }
}
