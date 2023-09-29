namespace Application.Core.Entities
{
    public class Funcionario
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string DocFederal { get; set; }
        public string Nacionalidade { get; set; }
        public string Cargo { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }

        public static Funcionario ConvertDTO(FuncionarioDTO dto)
        {
            var funcionario = new Funcionario
            {
                Nome = dto.Nome,
                DocFederal = dto.DocFederal,
                Nacionalidade = dto.Nacionalidade,
                Cargo = dto.Cargo,
                Idade = dto.Idade,
                Telefone = dto.Telefone
            };

            return funcionario;
        }
    }
}
