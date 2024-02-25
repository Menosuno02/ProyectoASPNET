﻿using Microsoft.EntityFrameworkCore;
using ProyectoASPNET.Models;

namespace ProyectoASPNET.Data
{
    public class RestaurantesContext : DbContext
    {
        public RestaurantesContext(DbContextOptions<RestaurantesContext> options) : base(options) { }

        public DbSet<CategoriaProducto> CategoriasProducto { get; set; }
        public DbSet<CategoriaRestaurante> CategoriaRestaurantes { get; set; }
        public DbSet<EstadoPedido> EstadoPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoCategorias> ProductoCategorias { get; set; }
        public DbSet<ProductoPedido> ProductoPedidos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ValoracionRestaurante> ValoracionRestaurantes { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}