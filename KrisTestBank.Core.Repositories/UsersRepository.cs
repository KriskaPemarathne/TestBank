using Dapper;
using KrisTestBank.Core.Entities;
using KrisTestBank.Core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IConnectionRepository _connectionRepository;

        public UsersRepository(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }

        public User Create(User entity)
        {
            try
            {
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "INSERT INTO [dbo].[UserDetails] " +
                     "([UserName],[Email],[PhoneNo],[PassPortNo],[DriverLicenceNo],[FirstName],[MiddleNames],[LastName],[Gender],[DateOfBirth],[CreatedDate] ,[IsDeleted])" +
                     "VALUES" +
                     "(@UserName,@Email,@PhoneNo,@PassPortNo,@DriverLicenceNo, @FirstName,@MiddleNames,@LastName, @Gender,@DateOfBirth,CURRENT_TIMESTAMP,0 )", entity);

                _connectionRepository.Connection.Close();

                entity.UserId = id;


            }
            catch (Exception)
            {
            }
            return entity;
        }

        public User Delete(User entity)
        {
            try{
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "UPDATE [dbo].[UserDetails] SET " +
                     "[IsDeleted] =1,[UpdatedDate]=CURRENT_TIMESTAMP" +
                     "WHERE UserId= @UserId", entity);

                _connectionRepository.Connection.Close();

                entity.UserId = id;
            }
            catch(Exception){ }
            return entity;
        }

        public User GetDetailById(int id)
        {
            
           User users = new User();
            try
            {
                _connectionRepository.Connection.Open();

                 users = _connectionRepository.Connection.Query<User>("SELECT * FROM [dbo].[UserDetails] WHERE [IsDeleted]=0 and [UserId] = " + id)?.FirstOrDefault();

                _connectionRepository.Connection.Close();

                
            }
            catch (Exception) { }
            return users;
        }

        public IEnumerable<User> GetAll()
        {
            IList<User> users = new List<User>();
            try
            {
                _connectionRepository.Connection.Open();

                users = _connectionRepository.Connection.Query<User>("SELECT * FROM [dbo].[UserDetails] WHERE [IsDeleted]=0 ")?.ToList();

                _connectionRepository.Connection.Close();



            }
            catch (Exception) { }
            return users;
        }

        public User GetUserById(int uId)
        {
            User user = new User();
            try
            {
                _connectionRepository.Connection.Open();

                user = _connectionRepository.Connection.Query<User>("SELECT * FROM [dbo].[UserDetails] WHERE [IsDeleted]=0 and [UserId] = " + uId)?.FirstOrDefault();

                _connectionRepository.Connection.Close();
            }
            catch (Exception) { }
            return user;
        }

        public User Update(User entity)
        {
            
            try
            {
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "UPDATE [dbo].[UserDetails] SET " +
                     "[UserName]=@UserName,[Email]=@Email,[PhoneNo]=@PhoneNo,[PassPortNo]=@PassPortNo,[DriverLicenceNo]=@DriverLicenceNo,[FirstName]=@FirstName,[MiddleNames]=@MiddleNames,[LastName]=@LastName,[Gender]=@Gender,[DateOfBirth]=@DateOfBirth,[UpdatedDate]=CURRENT_TIMESTAMP ,[IsDeleted]=@IsDeleted" +
                     "WHERE UserId= @UserId", entity);

                _connectionRepository.Connection.Close();

                entity.UserId = id;

                



            }
            catch (Exception) { }
            return entity;
        }
    }
}
