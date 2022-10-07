using CoronaTilbud_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTilbud_V2.Data.Interfaces
{
    public interface IEmailService
    {
        Task Send(EmailForm emailForm);

        Task SendAdd(AddForm addForm);
    }
}
