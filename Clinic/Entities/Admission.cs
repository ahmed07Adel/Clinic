using Clinic.Models;
using Clinic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class Admission
    {

      
        public Guid Id { get; set; }
        public string AdmissionRequestNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime AddminssionTime { get; set; }
        public int PatientTypeId { get; set; }
        public PatientType PatientType { get; set; }
        public int PatientSubTypeId { get; set; }
        public PatientType PatientSubType { get; set; }
        public string TrafficScheme { get; set; }
        public int EstimatedLengthOfDays { get; set; }
        public string AdmittingDoctor { get; set; }
        public string DoctorInCharge { get; set; }
        public string Remarks { get; set; }
        public bool ERAdmission { get; set; }
        public bool HasPatientMobile { get; set; }
        public string MobileNumber { get; set; }
        public string SpecialInstructions { get; set; }
        public int BedId { get; set; }
        public Bed Bed { get; set; }
        public List<AdmissionPadiatricandNeonate> AdmissionPadiatricandNeonates { get; set; }
        public string ServiceAdviced { get; set; }
        public decimal Total { get; set; }
        public string MedicalIsolation { get; set; }


     }


    }

