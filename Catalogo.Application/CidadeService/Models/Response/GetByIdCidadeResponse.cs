using Catalogo.Application.Common;
using Catalogo.Application.CidadeService.Models.Dtos;

namespace Catalogo.Application.CidadeService.Models.Response
{
    public class GetByIdCidadeResponse : BaseResponse
    {
        public CidadeDto Cidade { get; set; }
    }
}
