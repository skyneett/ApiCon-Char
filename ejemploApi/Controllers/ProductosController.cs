using ejemploApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ejemploApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly ApiContext _context;
        public ProductosController(ApiContext context) 
        {
            _context = context;
        }
        //--------------- METODO GET---------------------------------//
        [HttpGet(Name = "GetProductos")]
        
        public ActionResult<IEnumerable<Producto>> GetAll()
        {
            return _context.Productos.ToList();
        }

        //------------------- METODO GET POR ID ------------------------//
        [HttpGet("{id}")]

        public  ActionResult <Producto> GetById(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }
        //----------------------- Metodo POST----------------------------//
        [HttpPost]
        public ActionResult<Producto> Create(Producto producto) 
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = producto.Id},producto);
        }
        //-------------------------- Metodo PUT --------------------------//
        [HttpPut("{id}")]
        public ActionResult Update(int id, Producto producto) 
        {
            if (id != producto.Id)
            {
                return BadRequest();
            }
            _context.Entry(producto).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }
        //------------------ Metodo DELETE----------------//
        [HttpDelete("{id}")]
        public ActionResult<Producto> Delete(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return producto;
        }
    }
}
