using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class AdmissionPadiatricandNeonate
    {
        public int AdmissionId { get; set; }
        public Admission Admission { get; set; }
        public int PadiatricandNeonateId { get; set; }
        public PadiatricandNeonate PadiatricandNeonate { get; set; }
    }
}
