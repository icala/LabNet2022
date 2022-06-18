using Lab.Demo.EF.Common;
using Lab.Demo.EF.Entities;
using Lab.Demo.EF.Entities.DTOs;
using Lab.Demo.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Lab.Demo.EF.API.Controllers
{
    public class CategoriesController : ApiController
    {
        CategoriesLogic categoriesLogic;
        public CategoriesController()
        {
            categoriesLogic = new CategoriesLogic();
        }
        // GET: api/Categories
        public async Task<IEnumerable<CategoriesDTO>> Get()
        {
            var categories = await categoriesLogic.GetAllAsync();
            var categoriesDTO = categories.Select(c => new CategoriesDTO(c));
            return categoriesDTO;
        }

        // GET: api/Categories/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var category = await categoriesLogic.GetCategoryByIdAsync(id);
                return Ok(new CategoriesDTO(category));
            }
            catch (NullReferenceException)
            {
                return BadRequest("No existe categoria con ese id");
            }
        }

        // POST: api/Categories
        public IHttpActionResult Post([FromBody] CategoriesDTO category)
        {
            var idNuevo = categoriesLogic.GetNextId();
            var nuevaCategoria = new Categories()
            {
                CategoryID = idNuevo,
                CategoryName = category.CategoryName,
                Description = category.Description,
            };
            categoriesLogic.Add(nuevaCategoria);
            category.CategoryID = idNuevo;
            // Supongo que aca tengo que devolver el dto de categoria y no la entidad categoria creada
            // por eso reemplazo el id del dto pasado como parametro
            return Created("categories", category);
        }

        // PATCH: api/Categories/5
        public IHttpActionResult Patch(int id, [FromBody] CategoriesDTO category)
        {
            if (id != category.CategoryID) return BadRequest("No coincide el id de la ruta con el id de la categoria");
            try
            {
                var categoriaModificada = new Categories()
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                categoriesLogic.Update(categoriaModificada);
                return Ok();
            }
            catch (IdCategoryNotFoundException e1)
            {
                return BadRequest("No existe categoria con ese id");
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }

        // DELETE: api/Categories/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                categoriesLogic.Delete(id);

                return Ok();
            }

            catch (IdCategoryNotFoundException e1)
            {
                return BadRequest("No existe categoria con ese id");
            }
            catch (DbUpdateException e)
            {
                var ej = e.InnerException.GetType();
                if (e.InnerException is System.Data.Entity.Core.UpdateException)
                {
                    if (e.InnerException.InnerException is SqlException)
                    {
                        var sqlex = (SqlException)e.InnerException.InnerException;
                        if (sqlex.Number == 547)
                        {
                            var errorMsg = "Hay productos que tienen esta categoria, por lo tanto no puede ser borrada";
                            return BadRequest(errorMsg);
                        }
                    }
                }
                var errorMsg2 = "Error indeterminado al actualizar base de datos";
                return BadRequest(errorMsg2);
            }
            catch
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }
    }
}
