using Catalogo.Domain.Entities;

namespace Catalogo.Application.CidadeService.Models.Dtos
{
    public class CidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }

        public static explicit operator CidadeDto(Cidade x)
        {
            return new CidadeDto()
            {
                Id = x.Id,
                Nome = x.Nome,
                Uf = x.Uf
            };
        }
    }
}
