using Catalogo.Application.Common;
using Catalogo.Application.PessoaService.Models.Dtos;

namespace Catalogo.Application.PessoaService.Models.Response
{
    public class GetByIdPessoaResponse : BaseResponse
    {
        public PessoaDto Pessoa { get; set; }
    }
}
