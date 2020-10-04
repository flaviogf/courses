using System.Threading.Tasks;

namespace School.Domain.Students
{
    public interface IHash
    {
        Task<string> Make(string value);

        Task<bool> Compare(string value, string hash);
    }
}
