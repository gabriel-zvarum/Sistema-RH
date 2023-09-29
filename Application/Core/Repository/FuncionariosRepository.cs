using Application.Core.Entities;
using Application.Core.Repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core.Repository
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private readonly string ConectionString = "Data Source=FULL-92\\SQLEXPRESS;Initial Catalog=SistemaRHTreinamento;Integrated Security=True";
        public async Task<List<Funcionario>> GetAll()
        {
            using (var db = new SqlConnection(ConectionString))
            {
                await db.OpenAsync();
                var query = $"SELECT * FROM Funcionario ";
                var fromDB = await db.QueryAsync<Funcionario>(query);
                return fromDB.ToList();
            }
        }
        public async Task<Funcionario> GetById(int id)
        {
            using (var db = new SqlConnection(ConectionString))
            {
                await db.OpenAsync();
                var query = $"SELECT * FROM Funcionario WHERE id = @FuncionarioId";
                var user = await db.QueryFirstOrDefaultAsync<Funcionario>(query, new { FuncionarioId = id});
                return user;
            }
        }

        public async Task<Funcionario> Delete(int id)
        {
            using (var db = new SqlConnection(ConectionString))
            {
                await db.OpenAsync();
                var query = $"SELECT * FROM Funcionario WHERE id = @FuncionarioId;" +
                    $"Delete Funcionario WHERE id = @FuncionarioId";
                var user = await db.QueryFirstOrDefaultAsync<Funcionario>(query, new { FuncionarioId = id });
                return user;
            }
        }
        public async Task<Funcionario> Create(Funcionario funcionario)
        {
            using (var db = new SqlConnection(ConectionString))
            {
                await db.OpenAsync();
                var query = $"INSERT INTO Funcionario (Nome, docFederal, Nacionalidade, Cargo, Idade, Telefone)" +
                            $"VALUES(@FuncionarioNome, @FuncionarioDocFederal, @FuncionarioNacionalidade," +
                            $" @FuncionarioCargo, @FuncionarioIdade, @FuncionarioFone)";

                var user = await db.QueryFirstOrDefaultAsync<Funcionario>(query, new { FuncionarioNome = funcionario.Nome, 
                    FuncionarioDocFederal = funcionario.DocFederal, FuncionarioNacionalidade = funcionario.Nacionalidade,
                    FuncionarioCargo = funcionario.Cargo, FuncionarioIdade = funcionario.Idade,
                    FuncionarioFone = funcionario.Telefone
                });
                return user;
            }
        }

        public async Task<Funcionario> Update(int id, Funcionario funcionario)
        {
            using (var db = new SqlConnection(ConectionString))
            {
                await db.OpenAsync();
                var query = $"UPDATE Funcionario SET Nome = @FuncionarioNome, docFederal = @FuncionarioDocFederal," +
                            $"Nacionalidade = @FuncionarioNacionalidade, Cargo = @FuncionarioCargo, Idade = @FuncionarioIdade," +
                            $" Telefone = @FuncionarioFone WHERE id = @FuncionarioId";

                var user = await db.QueryFirstOrDefaultAsync<Funcionario>(query, new
                {
                    FuncionarioNome = funcionario.Nome,
                    FuncionarioDocFederal = funcionario.DocFederal,
                    FuncionarioNacionalidade = funcionario.Nacionalidade,
                    FuncionarioCargo = funcionario.Cargo,
                    FuncionarioIdade = funcionario.Idade,
                    FuncionarioFone = funcionario.Telefone,
                    FuncionarioId = id
                });
               
                return user;
            }
        }
    }
}
