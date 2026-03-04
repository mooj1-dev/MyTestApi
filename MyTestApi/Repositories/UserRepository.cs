using MyTestApi.Models;

namespace MyTestApi.Repositories
{
    public class UserRepository
    {
        private readonly Dictionary<long, User> _users = new();
        private long _nextId = 1;
        public UserRepository() 
        {
            Seed();
        }

        private void Seed()
        {
            Create(new User
            {
                name = "Leanne Graham",
                username = "Bret",
                email = "Sincere@april.biz",
                phone = "1-770-736-8031 x56442",
                website = "hildegard.org",
            });

            Create(new User
            {
                name = "Ervin Howell",
                username = "Antonette",
                email = "Shanna@melissa.tv",
                phone = "010-692-6593 x09125",
                website = "anastasia.net",
            });

            Create(new User
            {
                name = "Clementine Bauch",
                username = "Samantha",
                email = "Nathan@yesenia.net",
                phone = "1-463-123-4447",
                website = "ramiro.info",
            });
        }

        public IEnumerable<User> GetAll() => _users.Values;

        public User? GetById(long id)
            => _users.TryGetValue(id, out var user) ? user : null;

        public User Create(User user)
        {
            user.id = _nextId++;
            _users[user.id] = user;
            return user;
        }

        public bool Update(long id, User user)
        {
            if (!_users.ContainsKey(id)) 
                return false;

            user.id = id;
            _users[id] = user;
            return true;
        }
        public bool Delete(long id) => _users.Remove(id);
    }
}
