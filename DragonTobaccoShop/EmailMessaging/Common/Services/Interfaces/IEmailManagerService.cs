using EmailMessaging.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailMessaging.Common.Services.Interfaces
{
    public interface IEmailManagerService
    {
        public void SendEmail(IEmailMessage message);
    }
}