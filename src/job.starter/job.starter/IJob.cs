using System.Threading.Tasks;

namespace job.starter
{
    public interface IJob
    {
        Task<string> StartAsync(string message);
    }
}