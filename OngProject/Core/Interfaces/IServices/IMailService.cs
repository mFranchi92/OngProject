﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces.IServices
{
    public interface IMailService
    {
        public Task SendMail(string ToEmail, string body, string subject);
    }
}
