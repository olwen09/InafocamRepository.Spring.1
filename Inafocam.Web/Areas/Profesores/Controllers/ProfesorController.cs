using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Humanizer;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.Profesores.Models;
using Inafocam.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace Inafocam.Web.Areas.Profesores.Controllers
{
    [Area("Profesores"), ReturnArea("Profesores")]
    [ReturnControllador("Profesores"), ReturnController("Profesores")]
    [Authorize]
    public class ProfesorController : Controller
    {
        private readonly ITeacher _teacher;
        private readonly IContactType _contactType;
        private readonly IDocumentType _documentType;
        private readonly ICountry _country;
        private readonly ICity _city;
        private readonly IAddressType _addressType;
        private readonly IStatus _status;
        private readonly IEducationType _educationType;
        private readonly ITeacherEducation _teacherEducation;
        private readonly ITeacherFileType _teacherFileType;
        private readonly ITeacherHiringType _teacherHiringType;
        private readonly INationality _nationality;
        private readonly IMatirialStatus _matirialStatus;
        private readonly IProvince _province;
        private readonly ITeacherFile _teacherFile;
        private readonly IContactAddress _contactAddress;
        private readonly IContactCommunication _contactCommunication;
        private readonly IWebHostEnvironment _hostingEnv;
        private IConfiguration _config;


        public ProfesorController(ITeacher teacher, IContactType contactType, 
            IDocumentType documentType, ICountry country ,ICity city,
            IAddressType addressType, IStatus status, IEducationType educationType,
            ITeacherEducation teacherEducation, INationality nationality, IMatirialStatus matirialStatus, IProvince province,
            ITeacherHiringType teacherHiringType, ITeacherFileType teacherFileType, ITeacherFile teacherFile,
            IWebHostEnvironment hostingEnv,IConfiguration config, IContactAddress contactAddress, IContactCommunication contactCommunication
            )
        {
            _teacher = teacher;
            _contactType = contactType;
            _documentType = documentType;
            _country= country;
            _city= city;
            _addressType= addressType;
            _status = status;
            _educationType = educationType;
            _teacherEducation = teacherEducation;
            _nationality = nationality;
            _matirialStatus = matirialStatus;
            _province = province;
            _teacherHiringType = teacherHiringType;
            _teacherFileType = teacherFileType;
            _teacherFile = teacherFile;
            _hostingEnv = hostingEnv;
            _config = config;
            _contactAddress = contactAddress;
            _contactCommunication = contactCommunication;
        }

        public IActionResult Index()
        {
            var teachers = _teacher.GetAll;
           
            
            return View(teachers);
        }  
        
        public IActionResult Crear(TeacherModel model)
        {


            
            ViewBag.ContactTypes = new SelectList(_contactType.GetAll, "ContactTypeId", "ContactTypeName");
            ViewBag.DocumentType = new SelectList(_documentType.GetAll, "DocumentTypeId", "DocumentTypeName");
            ViewBag.Countries = new SelectList(_country.GetAll, "CountryId", "CountryName");
            ViewBag.Cities = new SelectList(_city.Cities, "CityId", "CityName");
            ViewBag.AddressTypes = new SelectList(_addressType.addressTypes, "AddressTypeId", "AddressTypeName");
            ViewBag.TeacherHiringType = new SelectList(_teacherHiringType.GetAll, "TeacherHiringTypeId", "TeacherHiringTypeName");
            ViewBag.EducationType = new SelectList(_educationType.GetAll, "EducationTypeId", "EducationTypeName");
            ViewBag.TeacherEducation = new SelectList(_teacherEducation.GetAll, "TeacherEducationId", "TeacherEducationTitle");
            ViewBag.Nationality = new SelectList(_nationality.GetAll, "NationalityId", "NationalityName");
            ViewBag.MatirialStatus = new SelectList(_matirialStatus.GetAll, "MaritalStatusId", "MaritalStatusName");
        

            return View(model);
        }

        public IActionResult Editar(int id)
        {
            var data = _teacher.GetById(id);

            var teacherEducation = new TeacherEducation();

          var model =   CopyPropierties.Convert<Teacher, TeacherModel>(data);
            model.HigherTeacherEducation = teacherEducation;

            

            ViewBag.ContactTypes = new SelectList(_contactType.GetAll, "ContactTypeId", "ContactTypeName");
            ViewBag.DocumentType = new SelectList(_documentType.GetAll, "DocumentTypeId", "DocumentTypeName");
            ViewBag.Countries = new SelectList(_country.GetAll, "CountryId", "CountryName");
            ViewBag.Cities = new SelectList(_city.Cities, "CityId", "CityName");
            ViewBag.AddressTypes = new SelectList(_addressType.addressTypes, "AddressTypeId", "AddressTypeName");
            ViewBag.TeacherHiringType = new SelectList(_teacherHiringType.GetAll, "TeacherHiringTypeId", "TeacherHiringTypeName");
            ViewBag.EducationType = new SelectList(_educationType.GetAll, "EducationTypeId", "EducationTypeName");
            ViewBag.TeacherEducation = new SelectList(_teacherEducation.GetAll, "TeacherEducationId", "TeacherEducationTitle");
            ViewBag.Nationality = new SelectList(_nationality.GetAll, "NationalityId", "NationalityName");
            ViewBag.MatirialStatus = new SelectList(_matirialStatus.GetAll, "MaritalStatusId", "MaritalStatusName");

            return View("Crear",model);
        }

        [HttpPost]
        public IActionResult GuardarTeacher(TeacherModel model)
        {


            //if (ModelState.IsValid)
            //{
                try
                {
                    var data = CopyPropierties.Convert<TeacherModel, Teacher>(model);
                    _teacher.Save(data);

                }
                catch (Exception e)
                {


                    return RedirectToAction("Editar", new { id = model.TeacherId });

                }
            //}
            


            return View("Index", _teacher.GetAll);
        }

        [HttpGet]
        public IActionResult TeacherEducation(int id)
        {

        var model = new TeacherEducationModel();
            var teacherById = _teacher.GetById(id);

            model.TeacherFullName = teacherById.Contact.ContactName + " " + teacherById.Contact.ContactLastname;

            model.TeacherId = id;
            model.TeacherEducationList =  _teacherEducation.GetAll.Where(x=> x.TeacherId == id).ToList();
            ViewBag.EducationType = new SelectList(_educationType.GetAll, "EducationTypeId", "EducationTypeName");
            return View(model);
        }  
        
        [HttpPost]
        public IActionResult GuardarTeacherEducation(TeacherEducationModel model)
        {

            var data = CopyPropierties.Convert<TeacherEducationModel, TeacherEducation>(model);
            if (ModelState.IsValid)
            {

                try
            {
                _teacherEducation.Save(data);
            }
            catch(Exception e){

                return RedirectToAction("TeacherEducation", new { id = model.TeacherId });

            }
            }
            else
            {
                EnviarMensaje.Enviar(TempData, "red", "Debe Completar Todos Los Campos");
                return RedirectToAction("TeacherEducation", new { id = model.TeacherId });
            }

            return RedirectToAction("TeacherEducation", new { id = model.TeacherId });
        }


        [HttpGet]
        public IActionResult AgregarDocumento(int id)
        {

            var model = new TeacherFileModel();


            var teacherById = _teacher.GetById(id);

            model.TeacherId = id;
            model.TeacherFullName = teacherById.Contact.ContactName + " " + teacherById.Contact.ContactLastname;
            model.TeacherFileList = _teacherFile.GetByTeacherId(id).ToList();
            model.TeacherFileTypeList = _teacherFileType.GetAll.ToList();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> File(TeacherFileModel model, IFormFile file)
        {
            var rutaPdf = _config.GetSection("rutas").GetSection("TeacherFiles").Value;
            //var file = model.FormFile;

            if (file != null)
            {
                //upload files to wwwroot
                //var fileName = Path.GetFileName(file.FileName);         
                
                //judge if it is pdf file
                string ext = Path.GetExtension(file.FileName);
                var fileName = model.TeacherId + "-" + Guid.NewGuid() + ext;
                if (ext.ToLower() != ".pdf")
                {
                    return View();
                }
                var fileFullPath = Path.Combine(rutaPdf, fileName);
                //var filePath = "\\app-assets\\documentos\\teacher" + fileName; 

                using (var fileSteam = new FileStream(fileFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }
                //your logic to save filePath to database, for example


                model.File.FileName = file.FileName;
                model.File.FilePath = fileName;
                model.File.FileFullPath = fileFullPath;
                model.File.FileTypeId = model.TeacherFileTypeId;
    

                var data = CopyPropierties.Convert<TeacherFileModel, TeacherFile>(model);

                try
                {
                    _teacherFile.Save(data);
                }
                catch (Exception e)
                {
                    return RedirectToAction("AgregarDocumento", new { id = model.TeacherId });
                }
            }
            else
            {

            }


            return RedirectToAction("AgregarDocumento", new { id = model.TeacherId });
        }

        public IActionResult AgregarDireccion(int id)
        {



           var model = new ContactAddressModel();
           var contactId =  _teacher.GetContactId(id);
           var teacherById = _teacher.GetById(id);

            model.ContactId = contactId;
            model.TeacherId = teacherById.TeacherId;
            model.TeacherFullName = teacherById.Contact.ContactName + " " + teacherById.Contact.ContactLastname;
            model.ContactAddressList =  _contactAddress.GetByContactId(contactId).ToList();

            ViewBag.Countries = new SelectList(_country.GetAll, "CountryId", "CountryName");
            ViewBag.Cities = new SelectList(_city.Cities, "CityId", "CityName");
            ViewBag.Province = new SelectList(_province.Provinces, "ProvinceId", "ProvinceName");
            ViewBag.AddressTypes = new SelectList(_addressType.addressTypes, "AddressTypeId", "AddressTypeName");
            return View(model);
        }


        [HttpPost]
        public IActionResult AgregarDireccion(ContactAddressModel model)
        {
            var data = CopyPropierties.Convert<ContactAddressModel, ContactAddress>(model);

            try
            {
                _contactAddress.Save(data);
            }
            catch (Exception e)
            {
                return RedirectToAction("AgregarDireccion", new { id = model.TeacherId });
            }

            return RedirectToAction("AgregarDireccion", new { id = model.TeacherId });
        }

        public IActionResult AgregarComunicacion(int id)
        {
            var model = new ContactCommunicationModel();
            var contactId = _teacher.GetContactId(id);
            var teacherById = _teacher.GetById(id);

            model.ContactId = contactId;
            model.TeacherId = teacherById.TeacherId;
            model.TeacherFullName = teacherById.Contact.ContactName + " " + teacherById.Contact.ContactLastname;
            model.CommunicationList = _contactCommunication.GetByContactId(contactId).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult AgregarComunicacion(ContactCommunicationModel model)
        {
            var data = CopyPropierties.Convert<ContactCommunicationModel, ContactCommunication>(model);


            try
            {
                _contactCommunication.Save(data);
            }
            catch(Exception e)
            {
                return RedirectToAction("AgregarComunicacion", new { id = model.TeacherId });
            }

            return RedirectToAction("AgregarComunicacion", new { id = model.TeacherId });
        }
    }
}
