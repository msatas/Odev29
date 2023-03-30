using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odev29.Data;
using Odev29.ViewModels;

namespace Odev29.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarController : ControllerBase
    {
        private readonly UygulamaDbContext _db;

        public YazarController(UygulamaDbContext db)
        {
            _db = db;
        }

        [HttpGet("YazarlariGetir")]
        public async Task<IActionResult> actionResultGet()
        {
            return Ok(_db.Yazarlar.ToListAsync());
        }

        [HttpGet("Ekle")]
        public async Task<IActionResult> YazarEkle(YazarVm yazarVm)
        {
            try
            {
                Yazar yazar = new Yazar();
                yazar.AdSoyad = yazarVm.AdSoyad;
                yazar.EserSayisi = yazarVm.EserSayisi;
                _db.Yazarlar.AddAsync(yazar);
                _db.SaveChangesAsync();
                return Ok("Yazar eklenmiştir.");
            }
            catch (Exception ex)
            { 


                return BadRequest("Hata!" + ex.Message);
            }
        }

        [HttpGet("Guncelle")]
        public async Task<IActionResult> YazarGuncelle(int id, YazarVm yazarVm)
        {
            try
            {
                Yazar yazar = new Yazar();
                yazar.AdSoyad = yazarVm.AdSoyad;
                yazar.EserSayisi = yazarVm.EserSayisi;
                _db.Yazarlar.AddAsync(yazar);
                _db.SaveChangesAsync();
                return Ok("Yazar eklenmiştir.");
            }
            catch (Exception ex)
            {



                return BadRequest("Hata!" + ex.Message);
            }
        }

        [HttpDelete("Sil")]
        public async Task<IActionResult> YazarSil(int id)
        {
            try
            {
                var silinecekYazar = _db.Yazarlar.Find(id);
                if (silinecekYazar != null)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
