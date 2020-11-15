using System.ComponentModel.DataAnnotations;

namespace AlocaGFT.Utils.Enums
{
    public enum UserLevels
    {
        [Display(Name="Usuário")]
        USER,
        [Display(Name="Administrador")]
        ADMIN
    }
}