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
    public class TransactionsRepository:ITransactionsRepository
    {
        private readonly IConnectionRepository _connectionRepository;

        public TransactionsRepository(IConnectionRepository connectionRepository)
        {
            
               _connectionRepository = connectionRepository;
        }

        public Transaction Create(Transaction entity)
        {
            try
            {
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "INSERT INTO [dbo].[TransactionDetails] " +
                     "([AccountId],[TransactionNote],[Debit],[Credit],[TransactionDate],[TransactionTypeId],[CreatedDate],[IsDeteted])" +
                     "VALUES" +
                     "(@AccountId, @TransactionNote,@Debit,@Credit, CURRENT_TIMESTAMP,@TransactionTypeId,CURRENT_TIMESTAMP,0 );" +
                     "UPDATE[dbo].[AccountDetails]   SET[AccountBalance] = (Select[AccountBalance] from[dbo].[AccountDetails]  WHERE[AccountId] = @AccountId) + @Debit-@Credit WHERE[AccountId] = @AccountId; SET @TransactionId = @@IDENTITY", entity);

                _connectionRepository.Connection.Close();

                entity.TransactionId = id;


            }
            catch (Exception e)
            {
            }
            return entity;
        }

        public string Transfer(Transaction entity, string AccountName)
        {
            var returnMessage = "";
            try
            {
                _connectionRepository.Connection.Open();

                var message = _connectionRepository.Connection.Query<String>(
                     "IF EXISTS (SELECT [AccountId] FROM [dbo].[AccountDetails] WHERE [AccountNumber]='"+ AccountName + "')" +
                "BEGIN "+                
                     "INSERT INTO [dbo].[TransactionDetails] " +
                     "([AccountId],[TransactionNote],[Debit],[Credit],[TransactionDate],[TransactionTypeId],[CreatedDate],[TransferTo],[IsDeteted])" +
                     "VALUES" +
                     "(@AccountId, @TransactionNote,@Debit,@Credit, CURRENT_TIMESTAMP,@TransactionTypeId,CURRENT_TIMESTAMP,'" + AccountName + "',0 );" +
                     "UPDATE[dbo].[AccountDetails]   SET[AccountBalance] = (Select[AccountBalance] from[dbo].[AccountDetails]  WHERE[AccountId] = @AccountId) - @Credit WHERE[AccountId] = @AccountId; " +
                     
                     "INSERT INTO [dbo].[TransactionDetails] " +
                     "([AccountId],[TransactionNote],[Debit],[Credit],[TransactionDate],[TransactionTypeId],[CreatedDate],[IsDeteted])" +
                     "VALUES" +
                     "((SELECT [AccountId] FROM [dbo].[AccountDetails] WHERE [AccountNumber]='" + AccountName + "'), @TransactionNote,@Credit,0, CURRENT_TIMESTAMP,@TransactionTypeId,CURRENT_TIMESTAMP,0 );" +
                     "UPDATE[dbo].[AccountDetails]   SET[AccountBalance] = (Select[AccountBalance] from[dbo].[AccountDetails]  WHERE[AccountId] = (SELECT [AccountId] FROM [dbo].[AccountDetails] WHERE [AccountNumber]='" + AccountName + "')) + @Credit WHERE[AccountId] = (SELECT [AccountId] FROM [dbo].[AccountDetails] WHERE [AccountNumber]='" + AccountName + "' ); SELECT 'Y' FROM [dbo].[TransactionDetails] WHERE TransactionId=(SELECT max(TransactionId) FROM [dbo].[TransactionDetails]);" +
                      " END ELSE BEGIN  SELECT 'N' FROM [dbo].[TransactionDetails] WHERE TransactionId=(SELECT max(TransactionId) FROM [dbo].[TransactionDetails]); END ", entity);

                _connectionRepository.Connection.Close();

                //entity.TransactionId = id;
                 returnMessage = message.ToList()[0].ToString();

            }
            catch (Exception e)
            {
            }
            return returnMessage;
        }




        public Transaction Delete(Transaction entity)
        {
            try
            {
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "UPDATE [dbo].[TransactionDetails] SET " +
                     "[IsDeleted] =1,[UpdatedDate]=CURRENT_TIMESTAMP" +
                     "WHERE TransactionId= @TransactionId", entity);

                _connectionRepository.Connection.Close();

                entity.TransactionId = id;
            }
            catch (Exception) { }
            return entity;
        }

        public Transaction GetDetailById(int id)
        {
            Transaction transactions = new Transaction();
            try
            {
                _connectionRepository.Connection.Open();

                transactions = _connectionRepository.Connection.Query<Transaction>("SELECT *   FROM [dbo].[TransactionDetails] t INNER JOIN [dbo].[AccountDetails] ac ON t.AccountId=ac.AccountId WHERE t.[IsDeleted]=0 and t.[TransactionId] = " + id)?.FirstOrDefault();

                _connectionRepository.Connection.Close();


            }
            catch (Exception) { }
            return transactions;
        }

        public IEnumerable<Transaction> GetAll()
        {
            IList<Transaction> transactions = new List<Transaction>();
            try
            {
                _connectionRepository.Connection.Open();

                transactions = _connectionRepository.Connection.Query<Transaction>("SELECT * FROM [dbo].[TransactionDetails] WHERE [IsDeleted]=0 ")?.ToList();

                _connectionRepository.Connection.Close();



            }
            catch (Exception) { }
            return transactions;
        }

        public IEnumerable<Transaction> GetTransactionDetailsByAccountId(int accountId)
        {
            IList<Transaction> transactions = new List<Transaction>();
            try
            {
                _connectionRepository.Connection.Open();

                transactions = _connectionRepository.Connection.Query<Transaction>("SELECT ac.*,t.*,tp.*   FROM [dbo].[TransactionDetails] t INNER JOIN [dbo].[AccountDetails] ac ON t.AccountId=ac.AccountId INNER JOIN [dbo].[TransactionTypeDetails] tp ON t.TransactionTypeId=tp.TransactionTypeId WHERE t.IsDeteted=0 AND  t.[AccountId] = " + accountId)?.ToList();

                _connectionRepository.Connection.Close();
            }
            catch (Exception) { }
            return transactions;
        }

        public Transaction Update(Transaction entity)
        {
            try
            {
                _connectionRepository.Connection.Open();

                var id = _connectionRepository.Connection.Execute(
                     "UPDATE [dbo].[TransactionDetails] SET " +
                     "[AccountId]=@AccountId,[TransactionNote]=@TransactionNote,[Debit]=@Debit,[Credit]=@Credit,[TransactionDate]=@TransactionDate,[TransactionTypeId]=@TransactionTypeId,[UpdatedDate]=CURRENT_TIMESTAMP,[IsDeteted]=@IsDeteted" +
                     "WHERE TransactionId= @TransactionId", entity);

                _connectionRepository.Connection.Close();

                entity.TransactionId = id;





            }
            catch (Exception) { }
            return entity;
        }
    }
}
