using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odev29.Data;

namespace Odev29.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobilyaController : ControllerBase
    {
        private readonly UygulamaDbContext _db;

        public MobilyaController(UygulamaDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public List<Urun> GetKisiler()
        {
            return _db.Urunler.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Urun> GetKisi(int id)
        {
            Urun? urun = _db.Urunler.Find(id);

            if (urun == null)
                return NotFound();

            return urun;
        }

        [HttpPost]
        public ActionResult<Urun> PostKisi(Urun urun)
        {
            if (ModelState.IsValid)
            {
                _db.Add(urun);
                _db.SaveChanges();
                return Created(Url.Action("GetKisi", new { id = urun.Id })!, urun);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public ActionResult<Urun> DeleteKisi(int id)
        {
            Urun? urun = _db.Urunler.Find(id);

            if (urun == null)
                return NotFound();

            _db.Remove(urun);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult PutKisi(int id, Urun urun)
        {
            if (id != urun.Id)
                return BadRequest();

            if (!_db.Urunler.Any(x => x.Id == id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Update(urun);
            _db.SaveChanges();
            return Ok();
        }
    }
}
