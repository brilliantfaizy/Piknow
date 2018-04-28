using PersianDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webservice.Models;

namespace Webservice.Repo
{
    public class TransactionRepo
    {
        protected Service_DBEntities DBContext;
        
        public TransactionRepo()
        {
            DBContext = new Service_DBEntities();
            
        }

        public object getTransactions(int user_id)
        {
            try
            {
                var result = DBContext.tbl_WalletTransaction.Where(e=>e.user_id == user_id).OrderByDescending(e=>e.transaction_datetime);
                if (result == null)
                {
                    return new SuccessMessage { success = "No data found" };
                }
                else
                {
                    List<userTransaction> userTransactionList = new List<userTransaction>();
                    foreach (tbl_WalletTransaction item in result)
                    {
                        userTransaction userTransactions = new userTransaction { 
                            
                            Balance = item.Balance,
                            Credit = item.Credit,
                            Debit = item.Debit,
                            rechargedBy = item.rechargedBy,//language.Trim().Equals("Persian") ? TranslateCls.Translate(item.rechargedBy, "English", "Persian") : item.rechargedBy,
                            transaction_datetime = String.Format("{0:f}", item.transaction_datetime),//language.Trim().Equals("Persian") ? ConvertDate.ToFa((DateTime)item.transaction_datetime, "F") : String.Format("{0:f}", item.transaction_datetime),//String.Format("{0:f}", item.transaction_datetime),
                            transaction_ID = item.transaction_ID,
                            transaction_Title = item.transaction_Title,
                            TransactionDetail= DBContext.tbl_transDetails.SingleOrDefault(e=>e.transaction_ID == item.transaction_ID)
                        };

                        userTransactionList.Add(userTransactions);
                    }

                    return userTransactionList;
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }

        }

        public object walletRecharge(tbl_WalletTransaction data)
        {
            try
            {
                if (data.user_id != 0 && data.Debit != "0" && (!string.IsNullOrWhiteSpace(data.rechargedBy)))
                {
                    var userTransData = DBContext.tbl_WalletTransaction.Where(e => e.user_id == data.user_id).ToList();
                    if (userTransData.Count == 0)
                    {

                        DBContext.tbl_WalletTransaction.Add(new tbl_WalletTransaction
                        {
                            user_id = data.user_id,
                            transaction_Title = data.transaction_Title,
                            transaction_datetime = data.transaction_datetime,
                            Debit = data.Debit,
                            Balance = data.Debit,
                            rechargedBy = data.rechargedBy,
                            Credit = ""
                        });
                    }
                    else
                    {
                        double currentBalance = 0;
                        currentBalance = double.Parse(userTransData.LastOrDefault().Balance) + double.Parse(data.Debit);
                        DBContext.tbl_WalletTransaction.Add(new tbl_WalletTransaction
                        {
                            user_id = data.user_id,
                            transaction_Title = data.transaction_Title,
                            transaction_datetime = data.transaction_datetime,
                            Debit = data.Debit,
                            Balance = currentBalance.ToString(),
                            rechargedBy = data.rechargedBy,
                            Credit = ""

                        });
                    }

                    DBContext.SaveChanges();
                    return new SuccessMessage { success = "Wallet successfully recharged." };
                }
                else
                {
                    return new ErrorMessage { error = "All fields required." };
                }

            }
            catch (Exception ex)
            {
                HandleAndLogException.LogErrorToText(ex);
                return new ErrorMessage { error = "Something went wrong" };
            }
        }

        public class SuccessMessage
        {
            public string success { get; set; }
        }

        public class ErrorMessage
        {
            public string error { get; set; }
        }

        public class userTransaction
        {
            public int transaction_ID { get; set; }
            public string transaction_Title { get; set; }
            public string transaction_datetime { get; set; }
            public string Debit { get; set; }
            public string Credit { get; set; }
            public string Balance { get; set; }
            public string rechargedBy { get; set; }
            public tbl_transDetails TransactionDetail { get; set; }
        }

       
    }
}