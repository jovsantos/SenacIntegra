using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// O DTO é um filtro de dados que tem a função de transportar os dados entre as camadas da aplicação,
// ele é utilizado para evitar o acoplamento entre as camadas e para garantir que os dados sejam transportados de forma segura e eficiente.

namespace SenacIntegra.DTO
{
    public class RequestLoginDTO
    {
        public required string Email { get; set; } // Propriedade para armazenar o email do usuário
        public required string Senha{ get; set; } // Propriedade para armazenar a senha do usuário
       

    }
   

}
