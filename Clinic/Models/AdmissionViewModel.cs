using AutoMapper;
using Clinic.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
   
    public class AdmissionViewModel
    {
       
        public Guid Id { get; set; }
        public string AdmissionRequestNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime AddminssionTime { get; set; }
        public List<SelectListItem> PatientTypes { get; set; }
        public List<SelectListItem> PatientSubType { get; set; }
        public int SelectedPatienType { get; set; }
        public int SelectedPatienSubType { get; set; }
        [Required]
        public string TrafficScheme { get; set; }
        [Required]
        public int EstimatedLengthOfDays { get; set; }
        [Required]
        public string AdmittingDoctor { get; set; }
        [Required]
        public string DoctorInCharge { get; set; }
        public string Remarks { get; set; }
        public bool ERAdmission { get; set; }
        [Required]
        public bool HasPatientMobile { get; set; }
        public string MobileNumber { get; set; }
        public string SpecialInstructions { get; set; }
        public int BedId { get; set; }
        public BedViewModel Bed { get; set; }
        public List<PadiatricandNeonateViewModel> PadiatricandNeonates { get; set; }
        public string ServiceAdviced { get; set; }
        public decimal Total { get; set; }
        public string MedicalIsolation { get; set; }
        public string Speciality { get; set; }


       
    }
   
}
