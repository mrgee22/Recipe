using System;
using System.Threading.Tasks;
using Recipe.Model;
using Recipe.Data;


namespace Recipe.Service
{
    public class UserService : IUserService
    {
        public UserService()
        {            
            DBRepository<User>.Initialize();            
        }

        public async Task<User> Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = await DBRepository<User>.GetItemSingleItemAsync(u => u.Username == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!user.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<User> Create(User user, string password)
        {
            
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");


            var dbUser = await DBRepository<User>.GetItemSingleItemAsync(u => u.Username == user.Username);
            if (dbUser != null)
                throw new Exception("Username " + user.Username + " is already taken");

            byte[] passwordHash, passwordSalt;
            user.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

           var createdUser = await DBRepository<User>.CreateItemAsync(user);
            user.Id = createdUser.Id;

            return user;

        }

        public async void Delete(string id)
        {
            var user = GetById(id);
            if (user != null)
                await DBRepository<User>.DeleteItemAsync(id.ToString());
        }

        public async Task<User> GetById(string id)
        {
            var user = await DBRepository<User>.GetItemAsync(id.ToString());
            return user;
        }

        public async void Update(User userParam, string password = null)
        {            
            var user = await GetById(userParam.Id);

            if (user == null)
                throw new Exception("User not found");

            if (userParam.Username != user.Username)
            {
                // username has changed so check if the new username is already taken
                var dbUser = DBRepository<User>.GetItemSingleItemAsync(u => u.Username == userParam.Username);
                if (dbUser != null)
                    throw new Exception("Username " + userParam.Username + " is already taken");
            }

            // update user properties
            user.FirstName = userParam.FirstName;
            user.LastName = userParam.LastName;
            user.Username = userParam.Username;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                user.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
        }
    }
}
