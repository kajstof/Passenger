using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using Xunit;

namespace Passenger.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_async_on_repository()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypter = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, encrypter.Object, mapperMock.Object);
            
            await userService.RegisterAsync("user@user.com", "user", "secret", "role");
            userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
        
        [Fact]
        public async Task when_calling_get_async_and_user_does_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypter = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, encrypter.Object, mapperMock.Object);
            
            await userService.GetAsync("user1@email.com");
            
            var user = new User("user1@email.com", "user1", "secret", "salt", "user");

            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                              .ReturnsAsync(user);
            
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }
        
        [Fact]
        public async Task when_calling_get_async_and_user_does_not_exists_it_should_invoke_user_repository_get_async()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var encrypter = new Mock<IEncrypter>();
            var mapperMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, encrypter.Object, mapperMock.Object);
            
            await userService.GetAsync("user@email.com");

            userRepositoryMock.Setup(x => x.GetAsync("user@email.com"))
                              .ReturnsAsync(() => null);
            
            userRepositoryMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }
    }
}