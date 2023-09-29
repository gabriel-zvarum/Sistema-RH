using Application.Core.Application.Interfaces;
using Application.Core.Entities;
using Application.Core.Validation.Funcionarios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SistemaRH_Desafio2.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FuncionariosControllers : ControllerBase
	{
		private readonly IFuncionariosApplicationService _funcionariosApplicationService;

		public FuncionariosControllers(IFuncionariosApplicationService funcionariosApplicationService, CommandFuncionariosValidation commandValidation)
		{
			_funcionariosApplicationService = funcionariosApplicationService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Funcionario>> GetAll()
		{
			try
			{
				var response = _funcionariosApplicationService.GetAll();
				return Ok(response);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("{id}")]
		public ActionResult<Funcionario> GetById(int id)
		{
			try
			{
				var response = _funcionariosApplicationService.GetByIdFuncionario(id);
				return Ok(response);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpDelete("{id}")]
		public ActionResult<Funcionario> Delete(int id)
		{
			try
			{
				var response = _funcionariosApplicationService.DeleteFuncionario(id);
				return Ok(response + " \nFuncionario Deletado com sucesso!");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPost]
		public ActionResult<Funcionario> Create([FromBody] FuncionarioDTO dto)
		{
			try
			{
				var response = _funcionariosApplicationService.CreateFuncionario(dto);
				return Ok("Funcionario criado com sucesso!");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpPut("{id}")]
		public ActionResult<Funcionario> Create(int id, [FromBody] FuncionarioDTO dto)
		{
			try
			{
				var response = _funcionariosApplicationService.UpdateFuncionario(id, dto);
				return Ok(response);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
