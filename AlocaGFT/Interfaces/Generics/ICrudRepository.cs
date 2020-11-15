using System.Collections.Generic;

namespace AlocaGFT.Interfaces.Generics
{
    public interface ICrudRepository<T> where T : class
    {
        List<T> GetTodosAtivos();
        T GetPorId(long id);
        T Salvar(T entity);//Update e Insert
        void DeletarPorId(long id);
        void DesativarPorId(long id);
        
    }
}