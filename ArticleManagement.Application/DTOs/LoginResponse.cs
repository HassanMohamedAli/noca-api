﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleManagement.Application.DTOs
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string UserName { get; set; }
    }

}
