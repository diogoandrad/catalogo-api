using Catalogo.Application.Common;
using Catalogo.Application.CidadeService.Models.Dtos;
using Catalogo.Application.CidadeService.Models.Request;
using Catalogo.Application.CidadeService.Models.Response;
using Catalogo.Domain.Entities;
using Catalogo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Catalogo.Application.CidadeService.Service
{
    public class CidadeService : BaseService<CidadeService>, ICidadeService
    {
        private readonly BaseContext _db;

        public CidadeService(ILogger<CidadeService> logger, BaseContext db) : base(logger)
        {
            _db = db;
        }

        public async Task<GetAllCidadeResponse> GetAllAsync()
        {
            var response = new GetAllCidadeResponse();

            var entity = await _db.Cidades.OrderBy(x => x.Nome).ToListAsync();

            response.Cidades = entity != null ? entity.Select(a => (CidadeDto)a).ToList() : new List<CidadeDto>();

            return response;
        }

        public async Task<GetByIdCidadeResponse> GetByIdAsync(int id)
        {
            var response = new GetByIdCidadeResponse();

            var entity = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null) response.Cidade = (CidadeDto)entity;

            return response;
        }

        public async Task<CreateCidadeResponse> CreateAsync(CreateCidadeRequest request)
        {
            var response = new CreateCidadeResponse();

            if (request == null)
                throw new ArgumentException("Request empty!");

            var newCidade = Cidade.Create(request.Nome, request.Uf);

            _db.Cidades.Add(newCidade);

            await _db.SaveChangesAsync();

            return response;
        }

        public async Task<UpdateCidadeResponse> UpdateAsync(int id, UpdateCidadeRequest request)
        {
            var response = new UpdateCidadeResponse();

            if (request == null)
                throw new ArgumentException("Request empty!");

            var entity = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                entity.Update(request.Nome, request.Uf);
                await _db.SaveChangesAsync();
            }

            return response;
        }

        public async Task<DeleteCidadeResponse> DeleteAsync(int id)
        {
            var response = new DeleteCidadeResponse();

            var entity = await _db.Cidades.FirstOrDefaultAsync(item => item.Id == id);

            if (entity != null)
            {
                _db.Remove(entity);
                await _db.SaveChangesAsync();
            }

            return response;
        }
    }
}
