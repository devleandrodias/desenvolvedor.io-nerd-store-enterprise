using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult result)
        {
            if (result != null && result.Erros.Messages.Any())
            {

                foreach (string mensagem in result.Erros.Messages)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
