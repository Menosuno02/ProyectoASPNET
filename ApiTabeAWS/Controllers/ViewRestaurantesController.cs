﻿using ApiTabeAWS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TabeNuget;

namespace TabeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewRestaurantesController : ControllerBase
    {
        private RepositoryRestaurantes repo;

        public ViewRestaurantesController(RepositoryRestaurantes repo)
        {
            this.repo = repo;
        }

        // GET: api/ViewRestaurantes
        /// <summary>
        /// Devuelve los restaurantes con sus datos públicos
        /// </summary>
        /// <remarks>
        /// Permite obtener todos los restaurantes formateados con sus datos públicos
        /// </remarks>
        /// <param name="searchquery">Parámetro de búsqueda (opcional)</param>
        /// <response code="200">Devuelve el conjunto de restaurantes</response>
        /// <response code="401">No autorizado. No se ha iniciado sesión</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<RestauranteView>>> GetRestaurantesView(string? searchquery = "")
        {
            return await this.repo.GetRestaurantesViewAsync(searchquery);
        }

        // GET: api/ViewRestaurantes/FindRestauranteView/{id}
        /// <summary>
        /// Busca un restaurante formateado
        /// </summary>
        /// <remarks>
        /// Permite obtener un restaurante formateado con sus datos públicos recibiendo su ID
        /// </remarks>
        /// <param name="id">ID del restaurante</param>
        /// <response code="200">Devuelve el restaurante</response>
        /// <response code="401">No autorizado. No se ha iniciado sesión</response>
        [HttpGet]
        [Route("Find/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RestauranteView>> FindRestauranteView(int id)
        {
            return await this.repo.FindRestauranteViewAsync(id);
        }

        // GET: api/ViewRestaurantes/FilterRestaurantesView
        /// <summary>
        /// Devuelve los restaurantes con sus datos públicos según una categoría
        /// </summary>
        /// <remarks>
        /// Permite obtener todos los restaurantes formateados con sus datos públicos en base a una categoría
        /// </remarks>
        /// <param name="categoria">Categoría de los restaurantes</param>
        /// <param name="searchquery">Parámetro de búsqueda (opcional)</param>
        /// <response code="200">Devuelve el conjunto de restaurantes</response>
        /// <response code="401">No autorizado. No se ha iniciado sesión</response>
        [HttpGet]
        [Route("Filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<RestauranteView>>> FilterRestaurantesView([FromQuery] string categoria, [FromQuery] string? searchquery = "")
        {
            return await this.repo.FilterRestaurantesViewAsync(categoria, searchquery);
        }
    }
}