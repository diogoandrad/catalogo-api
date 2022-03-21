using Catalogo.Application.PessoaService.Models.Request;
using Catalogo.Application.PessoaService.Models.Response;

namespace Catalogo.Application.PessoaService.Service
{
    public interface IPessoaService
    {
        Task<GetAllPessoaResponse> GetAllAsync();
        Task<GetByIdPessoaResponse> GetByIdAsync(int id);
        Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request);
        Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request);
        Task<DeletePessoaResponse> DeleteAsync(int id);
    }
}
