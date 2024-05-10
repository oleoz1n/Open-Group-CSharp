using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Open_Group.Models
{
    [Table("T_OP_ARQUIVO")]
    public class Arquivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_ARQUIVO")]
        public int IdArquivo { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Tipo { get; set; }

        [Required]
        public long Tamanho { get; set; }

        [Required]
        [Column("DATA_UPLOAD")]
        public DateTime DataUpload { get; set; }

        [StringLength(255)]
        [Required]
        [Url]
        public string Link { get; set; }

        [StringLength(255)]
        [Column("PALAVRA_CHAVE")]
        public string? PalavraChave { get; set; }

        [StringLength(255)]
        public string? Resumo { get; set; }


        [Column("DADOS_ARQUIVO")]
        [Required]
        public int DadosClienteId { get; set; } // 1..N
        public DadosCliente? DadosCliente { get; set; }
    }
}
