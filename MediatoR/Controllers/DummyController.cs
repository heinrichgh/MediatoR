using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatoR.CQRS;
using MediatoR.Validators;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MediatoR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DummyController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public DummyController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<DummyResponse>>> Get(int damage, string car)
        {
            var response = new BaseResponse<DummyResponse>();
            try
            {
                response.Response = await mediator.Send(new DummyCommand
                {
                    Car = car,
                    Damage = damage
                });
            }
            catch (ValidationException e)
            {
                response.Errors = e.Errors;
            }
            
            return response;
        }
    }
}