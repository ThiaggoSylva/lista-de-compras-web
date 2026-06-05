using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;

using ListaDeComprasWeb.ModuloCategoria.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloCategoria.Aplicacao.Servicos;
using ListaDeComprasWeb.ModuloCategoria.Apresentacao.Models;

namespace ListaDeComprasWeb.ModuloCategoria.Apresentacao.Controllers;

public class CategoriaController : Controller
{
    private readonly IServicoCategoria servicoCategoria;
    private readonly IMapper mapper;

    public CategoriaController(
        IServicoCategoria servicoCategoria,
        IMapper mapper)
    {
        this.servicoCategoria = servicoCategoria;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<CategoriaDto> registros =
            servicoCategoria.SelecionarTodos();

        List<VisualizarCategoriaViewModel> viewModels =
            mapper.Map<List<VisualizarCategoriaViewModel>>(registros);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        ViewBag.Titulo = "Cadastrar Categoria";

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarCategoriaViewModel viewModel)
    {
        ViewBag.Titulo = "Cadastrar Categoria";

        if (!ModelState.IsValid)
            return View(viewModel);

        CadastrarCategoriaDto dto =
            mapper.Map<CadastrarCategoriaDto>(viewModel);

        Result resultado =
            servicoCategoria.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Categoria cadastrada com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        ViewBag.Titulo = "Editar Categoria";

        CategoriaDto? categoria =
            servicoCategoria.SelecionarPorId(id);

        if (categoria is null)
            return RedirectToAction(nameof(Index));

        EditarCategoriaViewModel viewModel =
            mapper.Map<EditarCategoriaViewModel>(categoria);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(
        EditarCategoriaViewModel viewModel)
    {
        ViewBag.Titulo = "Editar Categoria";

        if (!ModelState.IsValid)
            return View(viewModel);

        EditarCategoriaDto dto =
            mapper.Map<EditarCategoriaDto>(viewModel);

        Result resultado =
            servicoCategoria.Editar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Categoria editada com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
public IActionResult Excluir(Guid id)
{
    CategoriaDto? categoria =
        servicoCategoria.SelecionarPorId(id);

    if (categoria is null)
        return RedirectToAction(nameof(Index));

    VisualizarCategoriaViewModel viewModel =
        mapper.Map<VisualizarCategoriaViewModel>(categoria);

    return View(viewModel);
}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        Result resultado =
            servicoCategoria.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] =
                resultado.Errors.First().Message;

            return RedirectToAction(nameof(Index));
        }

        TempData["Sucesso"] =
            "Categoria excluída com sucesso!";

        return RedirectToAction(nameof(Index));
    }
}