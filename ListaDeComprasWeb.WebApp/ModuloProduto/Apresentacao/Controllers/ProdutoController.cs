using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ListaDeComprasWeb.ModuloCategoria.Aplicacao.Servicos;
using ListaDeComprasWeb.ModuloProduto.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloProduto.Aplicacao.Servicos;
using ListaDeComprasWeb.ModuloProduto.Apresentacao.Models;

namespace ListaDeComprasWeb.ModuloProduto.Apresentacao.Controllers;

public class ProdutoController : Controller
{
    private readonly IServicoProduto servicoProduto;

    private readonly IServicoCategoria servicoCategoria;

    private readonly IMapper mapper;

    public ProdutoController(
        IServicoProduto servicoProduto,
        IServicoCategoria servicoCategoria,
        IMapper mapper)
    {
        this.servicoProduto = servicoProduto;
        this.servicoCategoria = servicoCategoria;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<ProdutoDto> registros =
            servicoProduto.SelecionarTodos();

        List<VisualizarProdutoViewModel> viewModels =
            mapper.Map<List<VisualizarProdutoViewModel>>(registros);

        return View(viewModels);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        CadastrarProdutoViewModel viewModel =
            new();

        CarregarCategorias(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarProdutoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategorias(viewModel);

            return View(viewModel);
        }

        CadastrarProdutoDto dto =
            mapper.Map<CadastrarProdutoDto>(viewModel);

        Result resultado =
            servicoProduto.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            CarregarCategorias(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Produto cadastrado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(Guid id)
    {
        ProdutoDto? produto =
            servicoProduto.SelecionarPorId(id);

        if (produto is null)
            return RedirectToAction(nameof(Index));

        EditarProdutoViewModel viewModel =
            mapper.Map<EditarProdutoViewModel>(produto);

        CarregarCategorias(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(
        EditarProdutoViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategorias(viewModel);

            return View(viewModel);
        }

        EditarProdutoDto dto =
            mapper.Map<EditarProdutoDto>(viewModel);

        Result resultado =
            servicoProduto.Editar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            CarregarCategorias(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Produto editado com sucesso!";

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        ProdutoDto? produto =
            servicoProduto.SelecionarPorId(id);

        if (produto is null)
            return RedirectToAction(nameof(Index));

        VisualizarProdutoViewModel viewModel =
            mapper.Map<VisualizarProdutoViewModel>(produto);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(Guid id)
    {
        Result resultado =
            servicoProduto.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] =
                resultado.Errors.First().Message;
        }
        else
        {
            TempData["Sucesso"] =
                "Produto excluído com sucesso!";
        }

        return RedirectToAction(nameof(Index));
    }

    private void CarregarCategorias(
        CadastrarProdutoViewModel viewModel)
    {
        viewModel.Categorias =
            servicoCategoria
                .SelecionarTodos()
                .Select(c => new SelectListItem(
                    c.Nome,
                    c.Id.ToString()))
                .ToList();
    }

    private void CarregarCategorias(
        EditarProdutoViewModel viewModel)
    {
        viewModel.Categorias =
            servicoCategoria
                .SelecionarTodos()
                .Select(c => new SelectListItem(
                    c.Nome,
                    c.Id.ToString()))
                .ToList();
    }
}