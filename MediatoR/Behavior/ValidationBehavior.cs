using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatoR.Behavior
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

        public ValidationBehavior(ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validator = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.IsSubclassOf(typeof(AbstractValidator<TRequest>)));

            if (validator != null)
            {
                var instance = (AbstractValidator<TRequest>) Activator.CreateInstance(validator);
                if (instance != null)
                {
                    await instance.ValidateAndThrowAsync(request, null, cancellationToken);
                }
            }

            var response = await next();

            return response;
        }
    }
}