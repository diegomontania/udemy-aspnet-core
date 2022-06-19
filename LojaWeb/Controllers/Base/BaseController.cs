using Microsoft.AspNetCore.Mvc;
using System;

namespace LojaWeb.Controllers.Base
{
    public class BaseController : Controller
    {
        //https://stackoverflow.com/a/424380/13156642
        public enum TiposMensagem
        {
            MensagemInfo = 1,
            MensagemErro = 2,
            MensagemSucesso = 3,
            MensagemAtencao = 4
        }

        public void Mensagem(string mensagem, TiposMensagem tiposMensagem)
        {
            //recebe o tipo do enum e converte a index no texto do enum
            string textoEnum = Enum.GetName(typeof(TiposMensagem), tiposMensagem);

            ViewData[textoEnum] = mensagem;
        }
    }
}
