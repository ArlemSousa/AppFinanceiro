using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fina.Core.Resposnses
{

    //new response<Category>
    //new Response<Transaction>
    public class Response<TData>
    {
        private int _code = 200;

        //construtor padrão para instanciar os responses de categoria e reponses de transações 
        public Response(int code, string? message, TData? data)
        {
          
        }

        public string? Message { get; set; }

        public TData? Data { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get { return _code == 200; } }
        //public bool IsSuccsess => _code is > 200 and < 299;
    
    }
}
