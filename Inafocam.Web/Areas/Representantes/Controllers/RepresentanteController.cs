using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.Web.Helpers;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Inafocam.core.Utilidades;
using Inafocam.Web.Areas.Representantes.Models;
using Inafocam.Web.Helpers;
using Inafocam.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoreLinq.Extensions;

namespace Inafocam.Web.Areas.Representantes.Controllers
{


    [Area("Representantes"), ReturnArea("Representantes")]
    [ReturnControllador("Representante"), ReturnController("Representante")]
    [Authorize(Roles = RoleName.AdministradorInafocam)]

    public class RepresentanteController : Controller
    {
        private readonly IAgent _agent;
        private readonly IAgentType _agentType;
        private readonly IContact _contact;
        private readonly IContactType _contactType;
        private readonly IDocumentType _documentType;
        private readonly IAddressType _addressType;
        private readonly ICountry _country;
        private readonly IProvince _province;
        private readonly ICity _city;
        private readonly IStatus _status;




        public RepresentanteController(IAgent agent,IContactType contactType, IDocumentType documentType,
            IAgentType agentType,IAddressType addressType,ICountry country,IProvince province,ICity city,
            IStatus status,IContact contact)
        {
            _agent = agent;
            _contactType = contactType;
            _documentType = documentType;
            _agentType = agentType;
            _addressType = addressType;
            _country = country;
            _province = province;
            _city = city;
            _city = city;
            _status = status;
            _status = status;
            _contact = contact;
        }

        public IActionResult Index()
        {
            var agentData = _agent.Agents.DistinctBy(x=> x.AgentId).ToList();
            //var prueba = _agent.GetCoordinators.ToList();
            
            return View(agentData);
        }


        public IActionResult Crear()
        {
            ViewBag.ContactType = new SelectList(_contactType.GetAll, "ContactTypeId", "ContactTypeName");
            ViewBag.AgentType = new SelectList(_agentType.GetAll, "AgentTypeId", "AgentTypeName");
            ViewBag.DocumentType = new SelectList(_documentType.GetAll, "DocumentTypeId", "DocumentTypeName");
            ViewBag.AddressType = new SelectList(_addressType.addressTypes, "AddressTypeId", "AddressTypeName");
            ViewBag.Countries = new SelectList(_country.GetAll, "CountryId", "CountryName");
            ViewBag.Provinces = new SelectList(_province.Provinces, "ProvinceId", "ProvinceName");
            ViewBag.Cities = new SelectList(_city.Cities, "CityId", "CityName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");

            return View();
        }


        public IActionResult Editar(int id)
        {

            var data = _agent.GetById(id);

            var model = CopyPropierties.Convert<Agent, AgentModel>(data);


            ViewBag.ContactType = new SelectList(_contactType.GetAll, "ContactTypeId", "ContactTypeName");
            ViewBag.AgentType = new SelectList(_agentType.GetAll, "AgentTypeId", "AgentTypeName");
            ViewBag.DocumentType = new SelectList(_documentType.GetAll, "DocumentTypeId", "DocumentTypeName");
            ViewBag.AddressType = new SelectList(_addressType.addressTypes, "AddressTypeId", "AddressTypeName");
            ViewBag.Countries = new SelectList(_country.GetAll, "CountryId", "CountryName");
            ViewBag.Provinces = new SelectList(_province.Provinces, "ProvinceId", "ProvinceName");
            ViewBag.Cities = new SelectList(_city.Cities, "CityId", "CityName");
            ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
            return View("Crear",model);
        }

        public IActionResult Guardar(AgentModel model)
        {
            var data = CopyPropierties.Convert<AgentModel, Agent>(model);
            var contactComunicationModel = new  ContactCommunication();
            data.Contact.ContactCommunication.ContactId = model.ContactId;


            if (ModelState.IsValid)
            {

                if (_contact.CheckIfContactDocumentNumberExits(data.Contact))
                {
                    EnviarMensaje.Enviar(TempData, "red", "Ya existe un registro con este número documento");

                    ViewBag.ContactType = new SelectList(_contactType.GetAll, "ContactTypeId", "ContactTypeName");
                    ViewBag.AgentType = new SelectList(_agentType.GetAll, "AgentTypeId", "AgentTypeName");
                    ViewBag.DocumentType = new SelectList(_documentType.GetAll, "DocumentTypeId", "DocumentTypeName");
                    ViewBag.AddressType = new SelectList(_addressType.addressTypes, "AddressTypeId", "AddressTypeName");
                    ViewBag.Countries = new SelectList(_country.GetAll, "CountryId", "CountryName");
                    ViewBag.Provinces = new SelectList(_province.Provinces, "ProvinceId", "ProvinceName");
                    ViewBag.Cities = new SelectList(_city.Cities, "CityId", "CityName");
                    ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
                    return View("Crear", model);
                }

                try
                {
                    _agent.Save(data);
                }
                catch (Exception e)
                {


                    ViewBag.ContactType = new SelectList(_contactType.GetAll, "ContactTypeId", "ContactTypeName");
                    ViewBag.AgentType = new SelectList(_agentType.GetAll, "AgentTypeId", "AgentTypeName");
                    ViewBag.DocumentType = new SelectList(_documentType.GetAll, "DocumentTypeId", "DocumentTypeName");
                    ViewBag.AddressType = new SelectList(_addressType.addressTypes, "AddressTypeId", "AddressTypeName");
                    ViewBag.Countries = new SelectList(_country.GetAll, "CountryId", "CountryName");
                    ViewBag.Provinces = new SelectList(_province.Provinces, "ProvinceId", "ProvinceName");
                    ViewBag.Cities = new SelectList(_city.Cities, "CityId", "CityName");
                    ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
                    return View("Crear", model);
                }
            }
            else
            {
                var erros = ModelState.Select(x => x.Value.Errors).FirstOrDefault(x => x.Count() > 0).First();

                EnviarMensaje.Enviar(TempData, "red", erros.ErrorMessage);

                ViewBag.ContactType = new SelectList(_contactType.GetAll, "ContactTypeId", "ContactTypeName");
                ViewBag.AgentType = new SelectList(_agentType.GetAll, "AgentTypeId", "AgentTypeName");
                ViewBag.DocumentType = new SelectList(_documentType.GetAll, "DocumentTypeId", "DocumentTypeName");
                ViewBag.AddressType = new SelectList(_addressType.addressTypes, "AddressTypeId", "AddressTypeName");
                ViewBag.Countries = new SelectList(_country.GetAll, "CountryId", "CountryName");
                ViewBag.Provinces = new SelectList(_province.Provinces, "ProvinceId", "ProvinceName");
                ViewBag.Cities = new SelectList(_city.Cities, "CityId", "CityName");
                ViewBag.Status = new SelectList(_status.Status, "StatusId", "StatusName");
                return View("Crear", model);
            }

           

            return View("Index", _agent.Agents.DistinctBy(x => x.AgentId).ToList());
        }
    }
}
