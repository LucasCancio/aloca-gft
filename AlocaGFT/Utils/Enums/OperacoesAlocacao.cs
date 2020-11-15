using System.ComponentModel.DataAnnotations;

namespace AlocaGFT.Utils.Enums
{
    public enum OperacoesAlocacao
    {
        [Display(Name="Alocação")]
        ALOCAR,
        [Display(Name="Desalocação")]
        DESALOCAR
    }
}