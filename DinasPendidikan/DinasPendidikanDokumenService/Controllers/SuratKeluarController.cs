using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DinasPendidikan.Shared.Models.Documents;
using DinasPendidikanDokumenService.Services;
using DinasPendidikanDokumenService.Services.SuratKeluarServices;

namespace DinasPendidikanDokumenService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuratKeluarController: ControllerBase
    {
        private readonly ISuratKeluarService _suratKeluarService;

        public SuratKeluarController(ISuratKeluarService suratKeluarService)
        {
            _suratKeluarService = suratKeluarService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuratKeluar>>> GetAllAsync()
        {
            return await _suratKeluarService.GetAllAsync();
        }
    }
}
