using System;
using Black.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Black.Domain.Entities;

namespace Blackcoding.Controllers.IbankController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreatePersonController : ControllerBase
    {
        private readonly ICreatePersonService _createPersonService;

        public CreatePersonController(ICreatePersonService createPersonService)
        {
            _createPersonService = createPersonService;
        }

        [HttpPost("create")]
        public IActionResult CreatePerson([FromBody] Person person)
        {
            _createPersonService.CreatePersonAsync(person);
            return Ok("Person created successfully.");
        }
    }
}
