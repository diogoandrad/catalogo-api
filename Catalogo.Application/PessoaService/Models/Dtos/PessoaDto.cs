using Catalogo.Domain.Entities;
using Catalogo.Application.CidadeService.Models.Dtos;

namespace Catalogo.Application.PessoaService.Models.Dtos
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public CidadeDto Cidade { get; set; }

        public static explicit operator PessoaDto(Pessoa x)
        {
            return new PessoaDto()
            {
                Id = x.Id,
                Nome = x.Nome,
                Cpf = x.Cpf,
                Idade = x.Idade,
                Cidade = (CidadeDto)x.Cidade
            };
        }
    }
}
