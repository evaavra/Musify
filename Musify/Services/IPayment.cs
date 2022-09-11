using Musify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musify.Services
{
    interface IPayment
    {
        string ToUrlEncodedString(Dictionary<string, string> request);
        Dictionary<string, string> ToDictionary(string response);
        bool AddTransaction(Dictionary<string, string> request, string payRequestId);
        bool UpdateTransaction(Dictionary<string, string> request, string PayrequestId);
        Transaction GetTransaction(string payRequestId);
        string GetMd5Hash(Dictionary<string, string> data, string encryptionKey);
        bool VerifyMd5Hash(Dictionary<string, string> data, string encryptionKey, string hash);
        //void UpdateTransactionStatus(Transaction transaction);
    }
}
