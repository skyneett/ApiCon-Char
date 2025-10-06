using ApiMVC.Models;

namespace ApiMVC.Services
{
    public interface IApiclient
    {
        Task<IEnumerable<Producto>> GetProductosAsync();
        Task<Producto?> GetProductoByIdAsync(int id);
        Task<Producto?> CreateProductoAsync(Producto producto);
        Task<bool> UpdateProductoAsync(int id, Producto producto);
        Task<bool> DeleteProductoAsync(int id);
    }
}
