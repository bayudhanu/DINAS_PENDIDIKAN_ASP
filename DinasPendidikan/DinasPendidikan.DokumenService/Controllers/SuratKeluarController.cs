using DinasPendidikan.DokumenService.Services.SuratKeluarServices;
using DinasPendidikan.Shared.Models.Documents;
using Microsoft.AspNetCore.Mvc;

namespace DinasPendidikan.DokumenService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuratKeluarController : ControllerBase
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
