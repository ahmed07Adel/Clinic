using Clinic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Repository
{
   public interface IClinic
    {
        Admission AddAdmission(Admission admission);
        IEnumerable<PatientType> GetPatientType();
        IEnumerable<PadiatricandNeonate> GetAdmissionPadiatricandNeonates();
    }
}
