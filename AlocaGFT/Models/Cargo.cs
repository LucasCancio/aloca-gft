using System;
using AlocaGFT.Interfaces.Generics;
using AlocaGFT.Utils.Enums;
using AlocaGFT.ViewModels;

namespace AlocaGFT.Models
{
    public class Cargo : IDefaultCrudEntity
    {
        public long id { get; set; }
        public bool HasId => this.id > 0;
        public string nome { get; set; }
        public CargoLevels level { get; set; }

        public bool? status { get; set; }
        public DateTime data_criacao { get; set; } = DateTime.Now;
        public DateTime? data_alteracao { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Cargo cargo = (Cargo)obj;

            return cargo.id == this.id;
        }


        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}