using AuthMock.DTO;

namespace AuthMock.Client.Services
{
    public interface IProjectsService
    {
        Task<IEnumerable<Project>> GetAsync();
    }

    public class ProjectsService : IProjectsService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProjectsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Project>> GetAsync()
        {
            List<Project> projects = null;
            var httpClient = _httpClientFactory.CreateClient("BackendClient");
            HttpResponseMessage response = await httpClient.GetAsync("projects");
            if (response.IsSuccessStatusCode)
            {
                projects = await response.Content.ReadAsAsync<List<Project>>();
            }

            return projects;
        }
    }
}