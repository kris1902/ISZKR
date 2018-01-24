using ISZKR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISZKR.ViewModels
{
    public class PersonTablesViewModel
    {
        public Person person { get; set; }
        public List<EducationHistory> EducationHistoryList { get; set; }
        public List<ResidenceHistory> ResidenceHistoryList { get; set; }
        public List<ProfessionHistory> ProfessionHistoryList { get; set; }
        public List<string> SchoolTypesNames { get; set; }

        public PersonTablesViewModel()
        {
            EducationHistoryList = new List<EducationHistory>();
            ResidenceHistoryList = new List<ResidenceHistory>();
            ProfessionHistoryList = new List<ProfessionHistory>();
            SchoolTypesNames = new List<string>();
        }
        
    }
}