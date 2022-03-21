using Catalogo.Application.Common;
using Catalogo.Application.PessoaService.Models.Dtos;
using Catalogo.Application.PessoaService.Models.Request;
using Catalogo.Application.PessoaService.Models.Response;
using Catalogo.Domain.Entities;
using Catalogo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalogo.Application.PessoaService.Service
{
    public class PessoaService : BaseService<PessoaService>, IPessoaService
    {
        private readonly BaseContext _db;

        public PessoaService(ILogger<PessoaService> logger, BaseContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllPessoaResponse> GetAllAsync()
        {
            var response = new GetAllPessoaResponse();

            var entity = await _db.Pessoas.Include(x => x.Cidade).OrderBy(x => x.Nome).ToListAsync();

            response.Pessoas = entity != null ? entity.Select(a => (PessoaDto)a).ToList() : new List<PessoaDto>();

            return response;
        }

        public async Task<GetByIdPessoaResponse> GetByIdAsync(int id)
        {
            var response = new GetByIdPessoaResponse();

            var entity = await _db.Pessoas.Include(x => x.Cidade).FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Pessoa = (PessoaDto)entity;

            return response;
        }

        public async Task<CreatePessoaResponse> CreateAsync(CreatePessoaRequest request)
        {
            var response = new CreatePessoaResponse();

            if (request == null)
                throw new ArgumentException("Request empty!");

            var newPessoa = Pessoa.Create(request.Nome, request.Cpf, request.Idade, request.CidadeId);

            _db.Pessoas.Add(newPessoa);

            await _db.SaveChangesAsync();

            return response;
        }

        public async Task<UpdatePessoaResponse> UpdateAsync(int id, UpdatePessoaRequest request)
        {
            var response = new UpdatePessoaResponse();

            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.Cpf, request.Idade, request.CidadeId);
                await _db.SaveChangesAsync();
            }

            return response;
        }

        public async Task<DeletePessoaResponse> DeleteAsync(int id)
        {
            var response = new DeletePessoaResponse();

            var entity = await _db.Pessoas.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return response;
        }
    }
}
