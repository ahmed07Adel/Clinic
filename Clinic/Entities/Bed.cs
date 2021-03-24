using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Entities
{
    public class Bed
    {
        public int Id { get; set; }
        public int BedTypeId { get; set; }
        public int RoomTypeId { get; set; }
        public string BedType { get; set; }
        public string RoomType { get; set; }
        public string Ward { get; set; }
        public int Room { get; set; }
        public int BedNumber { get; set; }
        public string BedBillingClass { get; set; }
        public int AdmissionId { get; set; }
        public Admission Admission { get; set; }
    }
}
