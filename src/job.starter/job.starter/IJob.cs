using System.Threading.Tasks;

namespace job.starter
{
    public interface IJob
    {
        string StartAsync(string message);
    }
}