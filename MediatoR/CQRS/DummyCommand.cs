using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatoR.CQRS
{
    public class DummyCommand : IRequest<DummyResponse>
    {
        public string Car { get; set; }
        public int Damage { get; set; }

        public class DummyCommandHandler : IRequestHandler<DummyCommand, DummyResponse>
        {
            public Task<DummyResponse> Handle(DummyCommand request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new DummyResponse
                {
                    Car = request.Car,
                    StillAlive = request.Damage < 100
                });
            }
        }
    }
}