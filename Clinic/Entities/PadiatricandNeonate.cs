using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class PadiatricandNeonate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AdmissionPadiatricandNeonate> AdmissionPadiatricandNeonates { get; set; }

    }
}
