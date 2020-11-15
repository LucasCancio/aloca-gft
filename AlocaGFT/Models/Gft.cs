using System;
using System.ComponentModel.DataAnnotations.Schema;
using AlocaGFT.Interfaces.Generics;

namespace AlocaGFT.Models
{
    public class Gft : IDefaultCrudEntity
    {
        public long id { get; set; }
        public bool HasId => this.id > 0;
        public string nome { get; set; }
        public string telefone { get; set; }
        public Endereco endereco { get; set; }
        [ForeignKey("endereco")]
        public long enderecoid {get;set;}

        public bool? status { get; set; }
        public DateTime data_criacao { get; set; } = DateTime.Now;
        public DateTime? data_alteracao { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Gft gft = (Gft)obj;

            return gft.id == this.id;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}