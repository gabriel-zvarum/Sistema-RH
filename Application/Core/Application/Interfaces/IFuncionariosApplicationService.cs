using Application.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Application.Interfaces
{
    public interface IFuncionariosApplicationService
    {

        Funcionario CreateFuncionario(FuncionarioDTO dto);
        Funcionario DeleteFuncionario(int id);
        Funcionario UpdateFuncionario(int id, FuncionarioDTO dto);
        Funcionario GetByIdFuncionario(int id);
        IEnumerable<Funcionario> GetAll();
    }
}
