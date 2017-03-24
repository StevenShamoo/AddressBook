using AddressBook.Models.Request;
using AddressBook.Models.Response;
using AddressBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AddressBook.Domain;

namespace AddressBook.Controllers.Api
{
    [RoutePrefix("address")]
    public class AddressApiController : ApiController
    {

        [Route("{UserId:int}"), HttpPost]
        public HttpResponseMessage Insert(AddressAddRequest model, int UserId)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            model.UserId = UserId;

            AddressService.Insert(model);

            return Request.CreateResponse(HttpStatusCode.OK, "Successful Insert");
        }

        [Route("{UserId:int}/{AddressId:Guid}"), HttpPut]
        public HttpResponseMessage Update(AddressUpdateRequest model, Guid AddressId, int UserId)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            model.UserId = UserId;

            AddressService.Update(model);

            ItemResponse<bool> response = new ItemResponse<bool>();

            response.Item = true;

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{UserId:int}/{AddressId:Guid}"), HttpGet]
        public HttpResponseMessage GetByAddressId(Guid AddressId, int UserId)
        {

            ItemResponse<Address> response = new ItemResponse<Address>();

            response.Item = AddressService.GetById(AddressId);

            return Request.CreateResponse(response);
        }

        [Route("{UserId:int}"), HttpGet]
        public HttpResponseMessage List(int UserId)
        {
            ItemsResponse<Address> response = new ItemsResponse<Address>();

            response.Items = AddressService.GetAll(UserId);

            return Request.CreateResponse(response);
        }

        [Route("{UserId:int}/{AddressId:Guid}"), HttpDelete]
        public HttpResponseMessage Delete(Guid AddressId, int UserId)
        {
            SuccessResponse response = new SuccessResponse();

            AddressService.DeleteById(AddressId);

            return Request.CreateResponse(response);
        }
    }
}
