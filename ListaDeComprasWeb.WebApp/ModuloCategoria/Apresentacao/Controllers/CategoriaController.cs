using AutoMapper;

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

    public IActionResult Index()
    {
        List<CategoriaDto> categorias =
            servicoCategoria.SelecionarTodos();

        List<VisualizarCategoriaViewModel> viewModels =
            mapper.Map<List<VisualizarCategoriaViewModel>>(categorias);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarCategoriaViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);

        CadastrarCategoriaDto dto =
            mapper.Map<CadastrarCategoriaDto>(viewModel);

        var resultado =
            servicoCategoria.Cadastrar(dto);

        if (!resultado.Sucesso)
        {
            ModelState.AddModelError(
                string.Empty,
                resultado.Mensagem);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Categoria cadastrada com sucesso.";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
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
        if (!ModelState.IsValid)
            return View(viewModel);

        EditarCategoriaDto dto =
            mapper.Map<EditarCategoriaDto>(viewModel);

        var resultado =
            servicoCategoria.Editar(dto);

        if (!resultado.Sucesso)
        {
            ModelState.AddModelError(
                string.Empty,
                resultado.Mensagem);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Categoria editada com sucesso.";

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
        var resultado =
            servicoCategoria.Excluir(id);

        if (!resultado.Sucesso)
        {
            TempData["Erro"] =
                resultado.Mensagem;

            return RedirectToAction(nameof(Index));
        }

        TempData["Sucesso"] =
            "Categoria excluída com sucesso.";

        return RedirectToAction(nameof(Index));
    }
}