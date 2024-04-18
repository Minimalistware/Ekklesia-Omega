﻿using Asp.Versioning;
using Ekkleisa.Business.Contract.IBusiness;
using Ekklesia.Entities.DTOs;
using Ekklesia.Entities.Entities;
using Ekklesia.Entities.Enums;
using Ekklesia.Entities.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ekklesia.Api.Controllers
{

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize]
    public class TransactionController : ApiController
    {
        private readonly ITransactionBusiness _transactionBusiness;

        public TransactionController(ITransactionBusiness memberBusiness)
        {
            this._transactionBusiness = memberBusiness;
        }


        [HttpPost]
        [Route(nameof(Browse))]
        public ActionResult<Response> Browse([FromBody] BaseFilter<Transaction, TransactionDTO> filter)
        {
            return Ok(_transactionBusiness.Browse(filter));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Response>> Get(string id)
        {
            var response = await _transactionBusiness.FindSync(id);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }


        [HttpPost]
        [Route(nameof(Post))]
        public async Task<ActionResult<Response>> Post([FromBody] TransactionDTO transaction)
        {
            var response = await _transactionBusiness.AddAsync(transaction);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }

        [HttpPut]
        [Route(nameof(Edit))]
        public async Task<ActionResult<Response>> Edit([FromBody] TransactionDTO transaction)
        {
            var response = await _transactionBusiness.UpdateAsync(transaction);
            if (response.Status == ResponseStatus.Ok) return Ok(response);
            return ErrorResponse(response);
        }

    }
}
