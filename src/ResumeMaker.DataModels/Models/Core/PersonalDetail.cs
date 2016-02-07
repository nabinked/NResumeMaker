using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DbPortal;

namespace ResumeMaker.Data.Models.Core
{
    public class PersonalDetail : DbEntity
    {
        public PersonalDetail()
        {
            SchemaName = "core";
            EntityName = "personal_details";
        }
        [Required]
        public long UserId { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [Range(1, 3, ErrorMessage = "Select a valid option")]
        public int GenderId { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "Select a valid option")]
        [Display(Name = "Driver's Licence")]
        public int DriverLicenceId { get; set; }

        [Required]
        public string Nationality { get; set; }

        public string Religion { get; set; }

        [Required]
        [Display(Name = "Languages Known")]
        public string LanguagesSpoken { get; set; }

    }
}
