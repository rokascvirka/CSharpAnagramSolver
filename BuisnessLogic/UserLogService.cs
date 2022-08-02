using Anagram.Database;
using Contracts;
using System.Net;
using System.Net.Sockets;
using System;
using Contracts.Models;

namespace BuisnessLogic
{
    public class UserLogService : IUserLogService
    {
        private readonly IUserLogRepository _repository;

        public UserLogService(IUserLogRepository repository)
        {
            _repository = repository;
        }

        public void AddUserLogToDB(string input, string anagram)
        {
             _repository.AddUserLogToDB(input, anagram, GetIP());
        }


        private string GetIP()
        {
            IPAddress[] ip = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ipAddress in ip)
            {
                if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ipAddress.ToString();
                }
            }
            return "No IP Address Found";
        }

    }
}
