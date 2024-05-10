﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Open_Group.Models
{
    [Table("T_OP_USUARIO")]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Identificacao), IsUnique = true)]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_USUARIO")]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Identificacao { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [StringLength(255)]
        public string Senha { get; set; }

        [Required]
        [Column("DATA_CRIACAO")]
        public DateTime DataCriacao { get; set; }
    }
}
