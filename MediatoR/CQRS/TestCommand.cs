using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatoR.CQRS
{
    public class TestCommand : IRequest<TestResponse>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public class TestCommandHandler : IRequestHandler<TestCommand, TestResponse>
        {
            public Task<TestResponse> Handle(TestCommand request, CancellationToken cancellationToken)
            {
                // save to db
                // send notification
                
                return Task.FromResult(new TestResponse
                {
                    Name = request.Name,
                    Age = request.Age
                });
            }
        }
    }
}