using Catalogo.Domain.Exceptions;

namespace Catalogo.Domain.Entities
{
    public class Pessoa
    {
        private Pessoa(string nome, string cpf, int idade, int cidadeId)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Idade = idade;
            this.CidadeId = cidadeId;
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Idade { get; set; }

        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }

       
        public static Pessoa Create(string nome, string cpf, int idade, int cidadeId)
        {
            if (nome == null) 
                throw new ArgumentException("Invalid " + nameof(nome));

            if (cpf == null)
                throw new ArgumentException("Invalid " + nameof(cpf));

            if (idade == 0)
                throw new ArgumentException("Invalid " + nameof(idade));

            if (cidadeId == 0)
                throw new ArgumentException("Invalid " + nameof(cidadeId));

            return new Pessoa(nome, cpf, idade, cidadeId);
        }

        public void Update(string nome, string cpf, int idade, int cidadeId)
        {
            if (nome != null) 
                Nome = nome;

            if (cpf != null)
                Cpf = cpf;

            if (idade < 0 || idade > 120)
                throw new InvalidIdadeExceptions();

            if (idade != 0)
                Idade = idade;

            if (cidadeId != 0)
                CidadeId = cidadeId;
        }
    }
}
