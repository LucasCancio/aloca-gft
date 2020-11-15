using System;

namespace AlocaGFT.Interfaces.Generics
{
    public interface IDefaultCrudEntity
    {
        long id { get; set; }
        bool HasId => this.id > 0;

        bool? status { get; set; }
        DateTime data_criacao { get; set; }
        DateTime? data_alteracao { get; set; }
    }
}