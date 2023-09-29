using Application.Core.Application.Interfaces;
using Application.Core.Entities;
using Application.Core.Repository;
using Application.Core.Repository.Interfaces;
using Application.Core.Validation.Funcionarios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class FuncionariosApplicationService : IFuncionariosApplicationService
{
    private readonly IFuncionariosRepository _funcionarioRepository;
    private readonly CommandFuncionariosValidation _CommandFuncionariosValidation;
    public FuncionariosApplicationService(IFuncionariosRepository funcionarioRepository, CommandFuncionariosValidation CommandFuncionariosValidation)
    {
        _funcionarioRepository = funcionarioRepository;
        _CommandFuncionariosValidation = CommandFuncionariosValidation;
    }

    
    public IEnumerable<Funcionario> GetAll()
    {
        var repository = _funcionarioRepository.GetAll().Result;
        return repository;
    }

    public Funcionario GetByIdFuncionario(int id)
    {
        var repository = _funcionarioRepository.GetById(id).Result;
        return repository;
    }

    public Funcionario CreateFuncionario(FuncionarioDTO dto)
    {
        var validation = _CommandFuncionariosValidation.ValidateAsync(dto, default);
        var funcionario = Funcionario.ConvertDTO(dto);
        var repository = _funcionarioRepository.Create(funcionario).Result;
        return repository;
    }

    public Funcionario DeleteFuncionario(int id)
    {
        var repository = _funcionarioRepository.Delete(id).Result;
        return repository;   
    }

    public Funcionario UpdateFuncionario(int id,FuncionarioDTO dto)
    {
        var funcionario = Funcionario.ConvertDTO(dto);
        var repository = _funcionarioRepository.Update(id, funcionario).Result;
        return repository;
    }

}
