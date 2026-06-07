using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;

using ListaDeComprasWeb.ModuloListaCompras.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloListaCompras.Aplicacao.Servicos;
using ListaDeComprasWeb.ModuloListaCompras.Apresentacao.Models;

namespace ListaDeComprasWeb.ModuloListaCompras.Apresentacao.Controllers;

public class ListaComprasController : Controller
{
    private readonly IServicoListaCompras servicoListaCompras;

    private readonly IMapper mapper;

    public ListaComprasController(
        IServicoListaCompras servicoListaCompras,
        IMapper mapper)
    {
        this.servicoListaCompras = servicoListaCompras;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<ListaComprasDto> registros =
            servicoListaCompras.SelecionarTodos();

        List<VisualizarListaComprasViewModel> viewModels =
            mapper.Map<List<VisualizarListaComprasViewModel>>(registros);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        CadastrarListaComprasViewModel viewModel =
            new();

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarListaComprasViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        CadastrarListaComprasDto dto =
            mapper.Map<CadastrarListaComprasDto>(viewModel);

        Result resultado =
            servicoListaCompras.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Lista cadastrada com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        ListaComprasDto? lista =
            servicoListaCompras.SelecionarPorId(id);

        if (lista is null)
            return RedirectToAction(nameof(Index));

        EditarListaComprasViewModel viewModel =
            mapper.Map<EditarListaComprasViewModel>(lista);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(
        EditarListaComprasViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        EditarListaComprasDto dto =
            mapper.Map<EditarListaComprasDto>(viewModel);

        Result resultado =
            servicoListaCompras.Editar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Lista editada com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        ListaComprasDto? lista =
            servicoListaCompras.SelecionarPorId(id);

        if (lista is null)
            return RedirectToAction(nameof(Index));

        VisualizarListaComprasViewModel viewModel =
            mapper.Map<VisualizarListaComprasViewModel>(lista);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        Result resultado =
            servicoListaCompras.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] =
                resultado.Errors.First().Message;
        }
        else
        {
            TempData["Sucesso"] =
                "Lista excluída com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }
}