namespace CtrlMensVendas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VENDA")]
    public partial class VENDA
    {
        [Key]
        [Column(Order = 0)]
        public int IDVENDA { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDPROD { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDCLI { get; set; }

        public int? IDVEICULO { get; set; }

        public int? IDMEC { get; set; }

        public decimal QTD { get; set; }

        public decimal? VALORTOTAL { get; set; }

        public DateTime? DATAENTRADA { get; set; }

        public DateTime? DATASAIDA { get; set; }

        public virtual CLIENTES CLIENTES { get; set; }

        public virtual MECANICOS MECANICOS { get; set; }

        public virtual PRODUTOS PRODUTOS { get; set; }

        public virtual VEICULOS VEICULOS { get; set; }
    }
}
