using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Passenger.Infrastructure.Commands.Users;
using Xunit;

namespace Passenger.Tests.EndToEnd.Controllers
{
    public class AccountControllerTests : ControllerTestsBase
    {
        [Fact]
        public async Task given_valid_current_and_new_passwort_it_should_be_changed()
        {
            var command = new ChangeUserPassword()
            {
                CurrentPassword = "secret",
                NewPassowrd = "secret2"
            };
            var payload = GetPayload(command);
            var response = await Client.PutAsync("account/password", payload);
            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.NoContent);
        }

    }
}