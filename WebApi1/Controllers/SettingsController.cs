using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Dto;
using Shared.Interfaces;

namespace WebApi1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SettingsController : ControllerBase, IReportSettingsService
    {
        ReportsDbContext _dbContext;
        public SettingsController(ReportsDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        [HttpGet]        
        public async Task<byte[]> GetSettings(string id)
        {

            if (id == null) throw new ArgumentException($" id пустой");
            var settings = await _dbContext.ReportSettings.FirstOrDefaultAsync(p => p.Id == id);
            if (settings == null) throw new ArgumentException($"Настройки с ключом {id} не найдены");
            return settings.FileBody;
         //   return new FileContentResult(settings.FileBody, "application/octet-stream");
        }



        [HttpPost]
        public async Task AddSettings([FromBody] ReportSettingsDto settingsDto)
        {
            if (settingsDto == null || settingsDto.Id == null) throw new ArgumentException($"Настройки  не переданы");
            var settings = new ReportSettings { Id = settingsDto.Id, FileBody = settingsDto.FileBody };

            _dbContext.ReportSettings.Add(settings);
            await _dbContext.SaveChangesAsync();
        }



        [HttpPut]
        public async Task UpdateSettings(ReportSettingsDto settingsDto)
        {
            if (settingsDto == null || settingsDto.Id == null) throw new ArgumentException($"Настройки  не переданы");


            var settingsFound = await _dbContext.ReportSettings.FirstOrDefaultAsync(p => p.Id == settingsDto.Id);
            if (settingsFound == null) throw new NullReferenceException($"Настройки с ключом {settingsDto.Id} не найдены");

            settingsFound.FileBody = settingsDto.FileBody;

            await _dbContext.SaveChangesAsync();
        }

    }
}
