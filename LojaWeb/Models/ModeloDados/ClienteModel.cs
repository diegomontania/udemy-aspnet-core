﻿namespace LojaWeb.Models.ModeloDados
{
    public class ClienteModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string NumeroCartaoCredito { get; set; }
    }
}
