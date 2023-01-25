using eProduct.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProduct.Data.Base
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
