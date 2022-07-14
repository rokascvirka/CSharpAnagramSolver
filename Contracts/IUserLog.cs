namespace Contracts
{
    public interface IUserLog
    {
        void AddUserLogToDB(string input, string anagram, string ip);
    }
}