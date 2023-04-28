using Microsoft.AspNetCore.Mvc;
using Patinaje_Torneos.Server.DataAccess;
using Patinaje_Torneos.Shared.Models;

namespace Patinaje_Torneos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        CategoriaDataAccess categoriaDA = new CategoriaDataAccess();

        [HttpGet("all")]
        public Task<List<Categoria>> GetAll()
        {
            return categoriaDA.GetAllCategorias();
        }

        [HttpGet("byId/{id}")]
        public Task<Categoria> GetId(string id)
        {
            return categoriaDA.GetCategoriaId(id);
        }
        [HttpPost("insertar")]
        public Task<Categoria> PostCategoria([FromBody] Categoria categoria)
        {
            return categoriaDA.AddCategoria(categoria);
        }
        [HttpPut("modificar")]
        public async Task PutCategoria([FromBody] Categoria categoria)
        {
            await categoriaDA.UpdateCategoria(categoria);
        }
        [HttpDelete("eliminar/{id}")]
        public async Task DeleteCategoria(string id)
        {
            await categoriaDA.DeleteCategoria(id);
        }
    }
}
