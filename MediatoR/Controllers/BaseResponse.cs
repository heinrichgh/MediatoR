using System.Collections.Generic;
using FluentValidation.Results;

namespace MediatoR.Controllers
{
    public class BaseResponse<T>
    {
        public T Response { get; set; }
        public IEnumerable<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();
    }
}