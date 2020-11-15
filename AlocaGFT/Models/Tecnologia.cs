using System;
using System.ComponentModel.DataAnnotations.Schema;
using AlocaGFT.Interfaces.Generics;

namespace AlocaGFT.Models
{
    public class Tecnologia : IDefaultCrudEntity
    {
        public long id { get; set; }
        public bool HasId => this.id > 0;
        public string nome { get; set; }
        public string imageName { get; set; }

        [NotMapped]
        public string imageSource { get; set; }

        public bool? status { get; set; }
        public DateTime data_criacao { get; set; } = DateTime.Now;
        public DateTime? data_alteracao { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var tecnologia = (Tecnologia)obj;

            return tecnologia.id == this.id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}