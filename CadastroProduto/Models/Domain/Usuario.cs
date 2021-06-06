using System;
using System.ComponentModel.DataAnnotations;


namespace CadastroProduto.Models.Domain
{
    public class Usuario : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

       
        [Required(ErrorMessage = "{0} obrigatória")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8 ,ErrorMessage = "A Senha deve ser composta de pelo menos {2} caracteres, ter letras maiúsculas e minúsculas e também conter caracteres especiais.")]
        public String Senha { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua senha")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação da senha são diferentes")]
        [Required(ErrorMessage = "Confirmação obrigatória")]             
        public String ConfirmacaoSenha { get; set; }

        public Usuario() { }
        
        public Usuario(int id, String nome, String email, String senha) : base(id)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }   
    }
}
