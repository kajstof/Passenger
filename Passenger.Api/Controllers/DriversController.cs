using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Drivers;

namespace Passenger.Api.Controllers
{
    public class DriversController : ApiControllerBase
    {
        public DriversController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Put([FromBody] CreateDriver command)
        {
            // TODO: Implement create driver logic
            await Task.CompletedTask;
            
            return NoContent();
        }
    }
}