using System.ComponentModel.DataAnnotations;

namespace LojaWeb.Models
{
    //É uma classe que serve para apenas exibir informação para a view.Os dados da 'ViewModel' podem não estar
    //armazenados exatamente da mesma forma que a 'ViewModel' se apresenta.
    public class ClienteViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
    }
}
