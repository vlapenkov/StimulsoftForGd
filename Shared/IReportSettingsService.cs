using Refit;
using Shared.Dto;
using System.Threading.Tasks;


namespace Shared.Interfaces
{
    public interface IReportSettingsService
    {
        [Post("/api/settings/AddSettings")]
        Task AddSettings(ReportSettingsDto settingsDto);

        [Get("/api/settings/GetSettings")]
        Task<byte[]> GetSettings(string hash);

        [Put("/api/settings/UpdateSettings")]
        Task UpdateSettings(ReportSettingsDto settingsDto);
    }
}