using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class PatientType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Admission> AdmissionTypes { get; set; }
        public List<Admission> AdmissionsSubTypes { get; set; }
    }
}
