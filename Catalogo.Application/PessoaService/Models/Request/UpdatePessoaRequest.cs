namespace Catalogo.Application.PessoaService.Models.Request
{
    public class UpdatePessoaRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public int CidadeId { get; set; }
    }
}
