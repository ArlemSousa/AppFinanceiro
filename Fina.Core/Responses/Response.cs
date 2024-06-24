using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fina.Core.Responses
{

    //new response<Category>
    //new Response<Transaction>
    public class Response<TData>
    {
        private int _code = Configuration.DefaultStatus;

        //padrão - informar que é o construtor padrão
        [JsonConstructor]
        public Response()
        {
            _code = Configuration.DefaultStatus;
        }


        //construtor para instanciar os responses de categoria e reponses de transações 
        //var res = new Response<Category>(Model);
        //optional parameters
        public Response(
            TData? data,
            int code = Configuration.DefaultStatus,
            string? message = null)
        {
            _code = code;
            Message = message;
            Data = data;

        }

        public string? Message { get; set; }

        public TData? Data { get; set; }

        [JsonIgnore]
        //public bool IsSuccess { get { return _code == 200; } }
        public bool IsSuccess => _code is >= 200 and < 299;

    }
}
