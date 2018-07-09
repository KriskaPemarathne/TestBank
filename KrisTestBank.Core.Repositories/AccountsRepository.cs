using KrisTestBank.Core.Entities;
using KrisTestBank.Core.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System;

namespace KrisTestBank.Core.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly IConnectionRepository _connectionRepository;

        public AccountsRepository(IConnectionRepository connectionRepository)
        {
            _connectionRepository = connectionRepository;
        }

        public Account Create(Account entity)
        {
            try {
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "INSERT INTO [dbo].[AccountDetails] " +
                     "([AccountNumber],[UserId],[AccountBalance],[CreatedDate])" +
                     "VALUES " +
                     "(@AccountNumber,@UserId ,@AccountBalance ,CURRENT_TIMESTAMP)", entity);

                _connectionRepository.Connection.Close();

                entity.AccountId = id;

                
            }
            catch (Exception)
            {
            }
            return entity;
        }

        public Account GetDetailById(int acId)
        {
            _connectionRepository.Connection.Open();

            var accounts = _connectionRepository.Connection.Query<Account>("SELECT * FROM [dbo].[AccountDetails] WHERE [IsDeleted]=0 and [AccountId] = " + acId)?.FirstOrDefault();

            _connectionRepository.Connection.Close();

            return accounts;
        }


        public IEnumerable<Account> GetAll()
        {
            _connectionRepository.Connection.Open();

            var accounts = _connectionRepository.Connection.Query<Account>("SELECT ac.* FROM [dbo].[AccountDetails] ac INNER JOIN [dbo].[UserDetails] u ON ac.UserId=u.UserId WHERE u.IsDeleted=0 AND ac.IsDeleted=0 ")?.ToList();

            _connectionRepository.Connection.Close();

            return accounts;
        }


        public IEnumerable<Account> GetAccountDetailsByUserId(int userId)
        {
            _connectionRepository.Connection.Open();

            var account = _connectionRepository.Connection.Query<Account>(
                 "SELECT * FROM [dbo].[AccountDetails] ac INNER JOIN [dbo].[UserDetails] u ON ac.UserId=u.UserId WHERE ac.[IsDeleted]=0 and ac.[UserId] = " + userId)?.ToList();
            _connectionRepository.Connection.Close();         
            return account;
        }

        public Account  Update(Account entity)
        {
            _connectionRepository.Connection.Open();

            var id = _connectionRepository.Connection.Execute(
                 "UPDATE [dbo].[AccountDetails] SET " +
                 "[AccountNumber] =@AccountNumber,[UserId]=@UserId,[AccountBalance]=@AccountBalance,[UpdatedDate]=CURRENT_TIMESTAMP" +
                 "WHERE AccountId= @AccountId" , entity);

            _connectionRepository.Connection.Close();

            entity.AccountId = id;

            return entity;
        }

        public Account Delete (Account entity)
        {
            _connectionRepository.Connection.Open();

            var id = _connectionRepository.Connection.Execute(
                 "UPDATE [dbo].[AccountDetails] SET " +
                 "[IsDeleted] =1,[UpdatedDate]=CURRENT_TIMESTAMP" +
                 "WHERE AccountId= @AccountId", entity);

            _connectionRepository.Connection.Close();

            entity.AccountId = id;

            return entity;

        }




        //public void Delete(int accountId)
        //{
        //    _connectionRepository.Connection.Open();

        //    var id = _connectionRepository.Connection.Execute(
        //         "DELETE * FROM  [dbo].[AccountDetails] WHERE AccountId="+ accountId);

        //    _connectionRepository.Connection.Close();


        //}




    }
}
