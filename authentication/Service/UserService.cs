using authentication.Domain;
using authentication.Repository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace authentication.Service{
    public interface IUserService{
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUser();
        Task<User> CreateUser(User user);
    }

    public class UserService(GenericRepository repository, UserRepository userRepository) : IUserService{
        private readonly GenericRepository _repository = repository;
        private readonly UserRepository _userRepository = userRepository;

        public async Task<User> GetUserById(int id){
            return await _repository.FindById<User>(id);
        }

        public async Task<IEnumerable<User>> GetAllUser(){
            return await _userRepository.GetAllUser();
        }

        public async Task<User> CreateUser(User user)
        {
            user = await _repository.Add(user);
            
            return user;
        }
    }
}