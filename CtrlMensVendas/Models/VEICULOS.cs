namespace CtrlMensVendas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VEICULOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VEICULOS()
        {
            VENDA = new HashSet<VENDA>();
        }

        [Key]
        public int IDVEICULO { get; set; }

        [Required]
        [StringLength(50)]
        public string DESCVEICULO { get; set; }

        [StringLength(8)]
        public string PLACAVEICULO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VENDA> VENDA { get; set; }
    }
}
