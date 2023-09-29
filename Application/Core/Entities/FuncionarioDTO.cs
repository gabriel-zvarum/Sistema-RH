using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Entities
{
	public class FuncionarioDTO
	{
		public string Nome { get; set; }
		public string DocFederal { get; set; }
		public string Nacionalidade { get; set; }
		public string Cargo { get; set; }
		public int Idade { get; set; }
		public string Telefone { get; set; }
	}
}
