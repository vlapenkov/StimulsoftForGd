using Refit;
using Shared.Dto;
using System.Threading.Tasks;

namespace Shared.Interfaces
{

    public interface IReportDataService
    {
        [Post("/api/ReportData/AddData")]
        Task AddData(ReportDataDto dataDto);

        [Get("/api/ReportData/GetData")]
        Task<byte[]> GetData(string id);

        [Put("/api/ReportData/UpdateData")]
        Task UpdateData(ReportDataDto dataDto);
    }
}