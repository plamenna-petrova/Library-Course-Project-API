using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Services.DtoModels.CreateDtos
{
    public class ReaderCreateDto
    {
        public int Id { get; set; }
        [Required]
        public string ReaderFirstName { get; set; }
        [Required]
        public string ReaderLastName { get; set; }
        public int ReaderAge { get; set; }
        public enum ReaderOccupation { GradeSchoolStudent, HighSchoolStudent, Employed, Unemployed, Retiree }
        public string ReaderAddress { get; set; }
        public string ReaderCity { get; set; }
        public string ReaderEmail { get; set; }
        public int ReaderContactNumber { get; set; }
        public decimal LibraryFee { get; set; }
        public bool HasPayedTheLibraryFee { get; set; }
    }
}
