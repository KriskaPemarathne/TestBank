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
    public class TransactionTypesRepository:ITransactionTypesRepository
    {
        private readonly IConnectionRepository _connectionRepository;

        public TransactionTypesRepository(IConnectionRepository connectionRepository)
        {

            _connectionRepository = connectionRepository;
        }

        public TransactionType Create(TransactionType entity)
        {
            try
            {
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "INSERT INTO [dbo].[TransactionTypeDetails] " +
                     "([TransactionTypeName],[IsDeteted])" +
                     "VALUES" +
                     "(@TransactionTypeName, 0 )", entity);

                _connectionRepository.Connection.Close();

                entity.TransactionTypeId = id;


            }
            catch (Exception)
            {
            }
            return entity;
          
        }

        public TransactionType Delete(TransactionType entity)
        {
            try
            {
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "UPDATE [dbo].[TransactionTypeDetails] SET " +
                     "[IsDeleted] =1" +
                     "WHERE TransactionTypeId= @TransactionTypeId", entity);

                _connectionRepository.Connection.Close();

                entity.TransactionTypeId = id;
            }
            catch (Exception)
            {
            }
            return entity;
        }

        public TransactionType GetDetailById(int id)
        {
            TransactionType transactionType = new TransactionType();
            try
            {
                _connectionRepository.Connection.Open();

                transactionType = _connectionRepository.Connection.Query<TransactionType>("SELECT * FROM [dbo].[TransactionTypeDetails] WHERE [IsDeleted]=0 and [TransactionTypeId] = " + id)?.FirstOrDefault();

                _connectionRepository.Connection.Close();
            }
            catch (Exception)
            {
            }
            return transactionType;
        }

        public IEnumerable<TransactionType> GetAll()
        {
            IList<TransactionType> transactionType = new List<TransactionType>();
            try
            {
                _connectionRepository.Connection.Open();

                transactionType = _connectionRepository.Connection.Query<TransactionType>("SELECT * FROM [dbo].[TransactionTypeDetails] WHERE [IsDeleted]=0 ")?.ToList();

                _connectionRepository.Connection.Close();


            }
            catch (Exception)
            {
            }
            return transactionType;
        }

        public TransactionType GetTransactionTypeById(int trTypId)
        {
            TransactionType transactionType = new TransactionType();
            try
            {
                _connectionRepository.Connection.Open();

                transactionType = _connectionRepository.Connection.Query<TransactionType>("SELECT * FROM [dbo].[TransactionTypeDetails] WHERE [IsDeleted]=0 and [TransactionTypeId] = " + trTypId)?.FirstOrDefault();

                _connectionRepository.Connection.Close();


            }
            catch (Exception)
            {
            }
            return transactionType;
        }

        public TransactionType Update(TransactionType entity)
        {
            try
            {
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "UPDATE [dbo].[TransactionTypeDetails] SET " +
                     "[TransactionTypeName]=@TransactionTypeName,[IsDeteted]=@IsDeteted" +
                     "WHERE TransactionTypeId= @TransactionTypeId", entity);

                _connectionRepository.Connection.Close();

                entity.TransactionTypeId = id;
            }
            catch (Exception)
            {
            }
            return entity;
        }
    }
}
