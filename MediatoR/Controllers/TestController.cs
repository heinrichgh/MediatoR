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
    public class TestController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public TestController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<TestVm>>> Get(int age, string name)
        {
            // var command = new TestCommand
            // {
            //     Age = age,
            //     Name = name
            // };
            //
            // var validator = new TestCommandValidator();
            // var result = validator.Validate(command);
            //
            // var x = await mediator.Send(command);
            // var response = new BaseResponse<TestVm>
            // {
            //     Response = mapper.Map<TestVm>(x),
            //     Errors = result.Errors
            // };
            //
            // return response; 
            
            var response = new BaseResponse<TestVm>();
            try
            {
                var x = await mediator.Send(new TestCommand
                {
                    Age = age,
                    Name = name
                });
                response.Response = mapper.Map<TestVm>(x);
            }
            catch (ValidationException e)
            {
                response.Errors = e.Errors;
            }
            
            return response;
        }
    }
}