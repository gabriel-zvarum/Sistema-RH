using Application.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Core.Repository.Interfaces
{
    public interface IFuncionariosRepository
    {
        Task<List<Funcionario>> GetAll();
        Task<Funcionario> GetById(int id);
        Task<Funcionario> Delete(int id);
        Task<Funcionario> Create(Funcionario funcionario);
        Task<Funcionario> Update(int id, Funcionario funcionario);
    }
}
