using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Open_Group.Models
{
    [Table("T_OP_DADOS_CLIENTE")] 
    public class DadosCliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_DADOS")]
        public int IdDados { get; set; }

        [Required]
        [Column("USUARIO")]
        public int IdUsuario { get; set; } // 1..N
        public Usuario? Usuario { get; set; }

        [StringLength(50)] 
        public string Segmento { get; set; }

        [StringLength(255)]
        public string Localizacao { get; set; }

        [Column("TEMPO_ATUACAO")]
        public int TempoAtuacao { get; set; }

        [Column("NUM_FUNCIONARIOS")]
        public int NumFuncionarios { get; set; }

        [Column("FATURAMENTO_ANUAL")]
        public float FaturamentoAnual { get; set; }

        [Column("CANAL_VENDA")]
        [StringLength(255)]
        public string CanalVenda { get; set; }

        [Column("PRODUTO_SERVICO")]
        [StringLength(255)]
        public string ProdutoServico{ get; set; }

        [StringLength(255)]
        public string Tipo { get; set; }

        [StringLength(50)]
        public string Porte { get; set; }

        [StringLength(255)]
        public string Concorrente { get; set; }

        [StringLength(255)]
        public string Desafio { get; set; }

        [StringLength(255)]
        public string Objetivo { get; set; }

    }
}
