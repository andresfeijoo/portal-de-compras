//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortalCompras.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrganismoLicitante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrganismoLicitante()
        {
            this.Licitadors = new HashSet<Licitador>();
        }
    
        public int IdOrganismoLicitante { get; set; }
        public string NombreOrganismoLicitante { get; set; }
        public int ContactoOrganismoLicitante { get; set; }
        public string DireccionOrganismoLicitante { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Licitador> Licitadors { get; set; }
    }
}