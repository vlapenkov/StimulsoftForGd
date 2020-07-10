using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;
using Shared.Interfaces;
using WebApi1.Data;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportDataController : ControllerBase, IReportDataService
    {
        ReportsDbContext _dbContext;
        public ReportDataController(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<byte[]> GetData(string id)
        {

            if (id == null) throw new ArgumentException($" id пустой");
            var settings = await _dbContext.ReportData.FirstOrDefaultAsync(p => p.Id == id);
            if (settings == null) throw new ArgumentException($"Настройки с ключом {id} не найдены");
            return settings.FileBody;
            //   return new FileContentResult(settings.FileBody, "application/octet-stream");
        }



        [HttpPost]
        public async Task AddData([FromBody] ReportDataDto dataDto)
        {
            if (dataDto == null || dataDto.Id == null || dataDto.ReportSettingsId==null) throw new ArgumentException($"Настройки переданы в некорректном виде");
            var settings = new ReportData 
            { 
                Id = dataDto.Id,
                ReportSettingsId=dataDto.ReportSettingsId,
                FileBody = dataDto.FileBody 
            };

            _dbContext.ReportData.Add(settings);
            await _dbContext.SaveChangesAsync();
        }



        [HttpPut]
        public async Task UpdateData(ReportDataDto dataDto)
        {
            if (dataDto == null || dataDto.Id == null) throw new ArgumentException($"Настройки  не переданы");


            var settingsFound = await _dbContext.ReportData.FirstOrDefaultAsync(p => p.Id == dataDto.Id);
            if (settingsFound == null) throw new NullReferenceException($"Настройки с ключом {dataDto.Id} не найдены");

            settingsFound.FileBody = dataDto.FileBody;

            await _dbContext.SaveChangesAsync();
        }
    }
}