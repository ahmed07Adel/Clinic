using AutoMapper;
using Clinic.Entities;
using Clinic.Models;
using Clinic.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;
        private readonly IClinic clinicRepo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IClinic clinicRepo, AppDbContext context)
        {
            this.context = context;
            this.clinicRepo = clinicRepo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var admissionViewModel = new AdmissionViewModel();
            var patientTypes = new List<SelectListItem>();
            var admissionPadiatricandNeonates = new List<PadiatricandNeonateViewModel>();
            admissionPadiatricandNeonates.AddRange(clinicRepo.GetAdmissionPadiatricandNeonates().ToList().Select(ap => new PadiatricandNeonateViewModel { Name = ap.Name, Id = ap.Id }));
            foreach (var item in clinicRepo.GetPatientType().ToList())
            {
                patientTypes.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name });
            }
            admissionViewModel.PatientSubType = patientTypes;
            admissionViewModel.PatientTypes = patientTypes;
            admissionViewModel.PadiatricandNeonates = admissionPadiatricandNeonates;
            return View(admissionViewModel);
        }
        [HttpPost]
        public IActionResult Index(AdmissionViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                Admission newadmission = new Admission
                {

  
                    AdmissionRequestNumber = model.AdmissionRequestNumber,
                    AddminssionTime = model.AddminssionTime,
                    AdmittingDoctor = model.AdmittingDoctor,
                    ERAdmission = model.ERAdmission,
                    Total = model.Total,
                    MedicalIsolation = model.MedicalIsolation,
                    ServiceAdviced = model.ServiceAdviced,
                    MobileNumber = model.MobileNumber,
                    SpecialInstructions = model.SpecialInstructions,
                    RegistrationNumber = model.RegistrationNumber,
                    EstimatedLengthOfDays = model.EstimatedLengthOfDays,
                    Bed = new Bed { BedNumber = model.Bed.BedNumber,Room = model.Bed.Room, Ward = model.Bed.Ward, BedBillingClass = model.Bed.BedBillingClass, RoomType = model.Bed.RoomType},
                    //PatientSubType = model.PatientSubType,
                    PatientType = new PatientType { Id = model.SelectedPatienType },
                    PatientSubType = new PatientType { Id = model.SelectedPatienSubType },
                    HasPatientMobile = model.HasPatientMobile,
                    Remarks = model.Remarks,
                    TrafficScheme = model.TrafficScheme,
                    DoctorInCharge = model.DoctorInCharge
                                    
                };
              
                clinicRepo.AddAdmission(newadmission);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
