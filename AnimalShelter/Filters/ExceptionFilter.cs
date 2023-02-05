using AnimalShelter.CastomExceptions.Animal;
using AnimalShelter.CastomExceptions.Employee;
using AnimalShelter.CastomExceptions.Volunteer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AnimalShelter.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            this._logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            Exception exception = context.Exception;

            Handle((dynamic)exception, context);
        }

        public void Handle(AnimalIsNotFoundException ex, ExceptionContext context)
        {
            _logger.LogError($"[MY LOG]\n Animal Is Not Found\n{ex.Message}\n{context.Exception.StackTrace}");

            context.Result = new ContentResult { Content = $"{ex.Message}\n{context.Exception.StackTrace}" };

        }

        public void Handle(AnimalIsnotValidExceptoin ex, ExceptionContext context)
        {
            _logger.LogError($"[MY LOG]\nAnimal Is not Valid Exceptoin\n{ex.Message}\n{context.Exception.StackTrace}");

            context.Result = new JsonResult(new { message = ex.Message });
            context.ExceptionHandled = true;
        }

        public void Handle(EmployeeIsNotFoundException ex, ExceptionContext context)
        {
            _logger.LogError($"[MY LOG]\nEmployee Is Not Found Exception\n{ex.Message}\n{context.Exception.StackTrace}");

            context.Result = new JsonResult(new { message = ex.Message });
            context.ExceptionHandled = true;
        }
        public void Handle(EmployeeIsnotValidExceptoin ex, ExceptionContext context)
        {
            _logger.LogError($"[MY LOG]\nEmployee Is not Valid Exceptoin\n{ex.Message}\n{context.Exception.StackTrace}");

            context.Result = new JsonResult(new { message = ex.Message });
            context.ExceptionHandled = true;
        }
        public void Handle(VolunteerIsNotFoundException ex, ExceptionContext context)
        {
            _logger.LogError($"[MY LOG]\nVolunteer Is Not Found Exception\n{ex.Message}\n{context.Exception.StackTrace}");

            context.Result = new JsonResult(new { message = ex.Message });
            context.ExceptionHandled = true;
        }
        public void Handle(VolunteerIsnotValidExceptoin ex, ExceptionContext context)
        {
            _logger.LogError($"[MY LOG]\nVolunteer Is not Valid Exceptoin\n{ex.Message}\n{context.Exception.StackTrace}");

            context.Result = new JsonResult(new { message = ex.Message });
            context.ExceptionHandled = true;
        }
        public void Handle(NullReferenceException ex, ExceptionContext context)
        {
            _logger.LogError($"[MY LOG]\n Null Reference Exception\n{ex.Message}\n{context.Exception.StackTrace}");

            context.Result = new JsonResult(new { message = ex.Message });
            context.ExceptionHandled = true;
        }
    }
}
