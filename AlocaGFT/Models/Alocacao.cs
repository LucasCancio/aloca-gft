using System;
using System.ComponentModel.DataAnnotations.Schema;
using AlocaGFT.Utils.Enums;

namespace AlocaGFT.Models
{
    public class Alocacao
    {
        public long id { get; set; }
        public bool HasId => this.id > 0;
        public Vaga vaga { get; set; }
        [ForeignKey("vaga")]
        public long vagaid { get; set; }
        public Funcionario funcionario { get; set; }
        [ForeignKey("funcionario")]
        public long funcionarioid { get; set; }
        public DateTime data_operacao { get; set; }

        public OperacoesAlocacao operacao { get; set; }
        public DateTime data_criacao { get; set; } = DateTime.Now;
        public string applicationUserId { get; set; }

        [NotMapped]
        public string username { get; set; }
        


    }
}