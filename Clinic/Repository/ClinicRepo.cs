using AutoMapper;
using Clinic.Entities;
using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Repository
{
    public class ClinicRepo : IClinic
    {
        private readonly AppDbContext context;

        public ClinicRepo(AppDbContext context)
        {
            this.context = context;
        }
       
        public Admission AddAdmission(Admission admission)
        {


            var res = context.Admissions.Add(admission);
            context.Entry(admission.PatientSubType).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
           context.Entry(admission.PatientType).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            return res.Entity;
        }

        public IEnumerable<PadiatricandNeonate> GetAdmissionPadiatricandNeonates()
        {
            return context.PadiatricandNeonates;
        }

        public IEnumerable<PatientType> GetPatientType()
        {
           
            return context.PatientTypes.ToList();
        }
    }
}
