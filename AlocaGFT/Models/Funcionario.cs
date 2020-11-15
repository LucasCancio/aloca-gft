using System;
using System.ComponentModel.DataAnnotations.Schema;
using AlocaGFT.Interfaces.Generics;

namespace AlocaGFT.Models
{
    public class Funcionario : IDefaultCrudEntity
    {
        public long id { get; set; }
        public Cargo cargo { get; set; }
        [ForeignKey("cargo")]
        public long cargoid { get; set; }
        public DateTime inicio_wa { get; set; }
        public DateTime termino_wa { get; set; }
        public string nome { get; set; }
        public string matricula { get; set; }
        public Vaga vaga { get; set; }
        [ForeignKey("vaga")]
        public long? vagaid { get; set; }
        public Gft gft { get; set; }
        [ForeignKey("gft")]
        public long gftid { get; set; }

        public bool? status { get; set; }
        public DateTime data_criacao { get; set; } = DateTime.Now;
        public DateTime? data_alteracao { get; set; }



        public bool HasId => this.id > 0;
        public bool EstaAlocado(Vaga vaga) => (this.vaga != null && this.vaga.id == vaga.id);
        public bool NaoEstaAlocado(Vaga vaga) => !(this.EstaAlocado(vaga));

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Funcionario funcionario = (Funcionario)obj;

            return funcionario.id == this.id;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}