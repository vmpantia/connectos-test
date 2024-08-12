using ACME.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Api.Contracts
{
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator) => _mediator = mediator;

        protected async Task<IActionResult> HandleRequestAsync<TRequest>(TRequest request)
            where TRequest : class
        {
            try
            {
                // Check if the request is NULL
                if (request is null) throw new ArgumentNullException(typeof(TRequest).Name);

                // Process the request using mediator
                var response = await _mediator.Send(request);

                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
