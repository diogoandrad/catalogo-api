using Catalogo.Application.Common;
using Catalogo.Application.PessoaService.Models.Dtos;

namespace Catalogo.Application.PessoaService.Models.Response
{
    public class GetAllPessoaResponse: BaseResponse
    {
        public List<PessoaDto> Pessoas { get; set; }
    }
}
