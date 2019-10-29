using EvilRabbot.Database.Models;

namespace EvilRabbot.Database.Services
{
    public class UserService
    {
        public void CreateOrUpdate(User user)
        {
            var foundUser = Context.UserRepo.FindFirstOrDefault("snowflake_id", user.SnowflakeId);
            if (foundUser != null)
            {
                user.Id = foundUser.Id;
                Context.UserRepo.Update(user);
            }

            user.Id = (int)Context.UserRepo.Insert(user);
        }
    }
}