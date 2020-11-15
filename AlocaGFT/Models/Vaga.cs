using System;
using System.ComponentModel.DataAnnotations.Schema;
using AlocaGFT.Interfaces.Generics;

namespace AlocaGFT.Models
{
    public class Vaga : IDefaultCrudEntity
    {
        public long id { get; set; }
        public bool HasId => this.id > 0;
        [Column("codigo_vaga")]
        public string codigoVaga { get; set; }//Id de identificação -> ex: #ITAU1230
        public string projeto { get; set; }
        public string descricao { get; set; }
        public DateTime abertura { get; set; }
        [Column("qtd_vaga")]
        public int qtdVaga { get; set; }
        [Column("home_office")]
        public bool homeOffice {get;set;}
        //public Endereco endereco { get; set; }

        public bool? status { get; set; }
        public DateTime data_criacao { get; set; } = DateTime.Now;
        public DateTime? data_alteracao { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Vaga vaga = (Vaga)obj;

            return vaga.id == this.id;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}