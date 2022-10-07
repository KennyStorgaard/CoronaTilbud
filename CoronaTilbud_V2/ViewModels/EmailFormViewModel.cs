using CoronaTilbud_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTilbud_V2.ViewModels
{
    public class EmailFormViewModel
    {

        public IEnumerable<EmailSubject> EmailSubjects
        {
            get
            {
                return new List<EmailSubject>
                {
                    new EmailSubject{ Title ="Action 1"},
                    new EmailSubject{ Title ="Action 2"},
                    new EmailSubject{ Title ="Action 3"},

                };
            }
            set => new EmailSubject();
        }

        public EmailForm EmailForm { get; set; }
        public string EmailSubjectSelected { get; set; }

    }
}
