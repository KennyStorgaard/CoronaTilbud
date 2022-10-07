using CoronaTilbud_V2.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaTilbud_V2.ViewModels
{
    public class AddFormViewModel
    {
        public IEnumerable<AddFormSubject> AddFormSubject
        {
            get
            {
                return new List<AddFormSubject>
                {
                    new AddFormSubject{ Title ="Mad & varer"},
                    new AddFormSubject{ Title ="Service"}
                };
            }
            set => new AddFormSubject();
        }
        public string SelectedSubject { get; set; }
        public AddForm AddForm { get; set; }
        public string Path { get; set; }
    }
}
