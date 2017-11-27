using System;
using Recipe.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipe.Model;
using System.Threading.Tasks;

namespace Recipe.Tests
{
    [TestClass]
    public class UserTests
    {
        private IUserService _userService;
        private User _user;
        const string password = "awesomeJohn1";

        [TestInitialize]
        public void UserTestsInitialise()
        {
            _user = new User();
        }

        [TestMethod]
        public void Create_User_Should_Add_User_to_DB()
        {
            var user = CreateUserObject();
            user.Username = $"imjohn{new Random().Next(0, 100)}";
            _userService = new UserService();
            Task.Run(async () =>
            {
                var createdUser = await _userService.Create(user, password);
                Assert.IsNotNull(createdUser.Id);

            }).GetAwaiter().GetResult();
        }

       
        private User CreateUserObject()
        {
            return new User
            {
                FirstName = "John",
                LastName = "Doe",
                Password = "awesomeJohn1"
            };
        }
    }
}
