﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CasaEmpeñoModel.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CasaEmpeñoEntities : DbContext
    {
        public CasaEmpeñoEntities()
            : base("name=CasaEmpeñoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EstadoProducto> EstadoProducto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<TipoProducto> TipoProducto { get; set; }
        public virtual DbSet<TipoTransaccion> TipoTransaccion { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Transaccion> Transaccion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
