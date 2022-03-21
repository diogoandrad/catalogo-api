using Catalogo.Application.Common;
using Catalogo.Application.CidadeService.Models.Dtos;

namespace Catalogo.Application.CidadeService.Models.Response
{
    public class GetAllCidadeResponse: BaseResponse
    {
        public List<CidadeDto> Cidades { get; set; }
    }
}
