using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Open_Group.Models
{
    [Table("T_OP_INSIGHT")]
    public class Insight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_INSIGHT")]
        public int IdInsight { get; set; }

        [Required]
        [Column("DATA_GERACAO")]
        public DateTime DataGeracao { get; set; }

        [Required]
        [StringLength(255)]
        public string Detalhes {get; set;}

        [Required]
        [StringLength(255)]
        public string Recomendacao { get; set; }

        [Required]
        public int Impacto { get; set; }

        [Required]
        [Column("DADOS_INSIGHT")]
        public int DadosClienteId { get; set; } // 1..N
        public DadosCliente? DadosCliente { get; set; }
    }
}
