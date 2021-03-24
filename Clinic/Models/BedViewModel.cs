using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Models
{
    public class BedViewModel
    {
        public int Id { get; set; }
        public int BedTypeId { get; set; }
        public int RoomTypeId { get; set; }
        public string BedType { get; set; }
        public string RoomType { get; set; }
        [Required]
        public string Ward { get; set; }
        [Required]
        public int Room { get; set; }
        [Required]
        public int BedNumber { get; set; }
        [Required]
        public string BedBillingClass { get; set; }
        public AdmissionViewModel Admission { get; set; }
    }
}
