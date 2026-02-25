using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenacIntegra.DTO
{
    public class ResponseLoginDTO
    {  
        public bool Erro { get; set; } // Propriedade para indicar se o login foi bem-sucedido
        public string Message { get; set; } = string.Empty;
         

    }

 
}
