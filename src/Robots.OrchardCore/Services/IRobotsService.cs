using System.Threading.Tasks;

namespace Robots.OrchardCore.Services {
    public interface IRobotsService {
        Task<string> FetchTextAsync();
    }
}