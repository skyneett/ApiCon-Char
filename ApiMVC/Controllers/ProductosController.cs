using ApiMVC.Models;
using ApiMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IApiclient _apiClient;

        public ProductosController(IApiclient apiClient)
        {
            _apiClient = apiClient;
        }

        // GET: /Productos
        public async Task<IActionResult> Index()
        {
            try
            {
                var productos = await _apiClient.GetProductosAsync();
                return View(productos);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar productos: {ex.Message}";
                return View(new List<Producto>());
            }
        }

        // GET: /Productos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var producto = await _apiClient.GetProductoByIdAsync(id);
                if (producto == null)
                {
                    TempData["Error"] = "Producto no encontrado";
                    return RedirectToAction(nameof(Index));
                }
                return View(producto);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar producto: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _apiClient.CreateProductoAsync(producto);
                    if (result != null)
                    {
                        TempData["Success"] = "Producto creado exitosamente";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Error"] = "No se pudo crear el producto";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al crear producto: {ex.Message}";
            }
            
            return View(producto);
        }

        // GET: /Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var producto = await _apiClient.GetProductoByIdAsync(id);
                if (producto == null)
                {
                    TempData["Error"] = "Producto no encontrado";
                    return RedirectToAction(nameof(Index));
                }
                return View(producto);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar producto: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: /Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            try
            {
                if (id != producto.Id)
                {
                    TempData["Error"] = "ID del producto no coincide";
                    return RedirectToAction(nameof(Index));
                }

                if (ModelState.IsValid)
                {
                    var result = await _apiClient.UpdateProductoAsync(id, producto);
                    if (result)
                    {
                        TempData["Success"] = "Producto actualizado exitosamente";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["Error"] = "No se pudo actualizar el producto";
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al actualizar producto: {ex.Message}";
            }
            
            return View(producto);
        }

        // GET: /Productos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var producto = await _apiClient.GetProductoByIdAsync(id);
                if (producto == null)
                {
                    TempData["Error"] = "Producto no encontrado";
                    return RedirectToAction(nameof(Index));
                }
                return View(producto);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al cargar producto: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _apiClient.DeleteProductoAsync(id);
                if (result)
                {
                    TempData["Success"] = "Producto eliminado exitosamente";
                }
                else
                {
                    TempData["Error"] = "No se pudo eliminar el producto";
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error al eliminar producto: {ex.Message}";
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
