using AutoMapper;

using FluentResults;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ListaDeComprasWeb.ModuloItensListaCompras.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloItensListaCompras.Aplicacao.Servicos;
using ListaDeComprasWeb.ModuloItensListaCompras.Apresentacao.Models;

using ListaDeComprasWeb.ModuloListaCompras.Aplicacao.Servicos;
using ListaDeComprasWeb.ModuloProduto.Aplicacao.Servicos;

namespace ListaDeComprasWeb.ModuloItensListaCompras.Apresentacao.Controllers;

public class ItemListaComprasController : Controller
{
    private readonly IServicoItemListaCompras servicoItens;

    private readonly IServicoListaCompras servicoListas;

    private readonly IServicoProduto servicoProdutos;

    private readonly IMapper mapper;

    public ItemListaComprasController(
        IServicoItemListaCompras servicoItens,
        IServicoListaCompras servicoListas,
        IServicoProduto servicoProdutos,
        IMapper mapper)
    {
        this.servicoItens = servicoItens;
        this.servicoListas = servicoListas;
        this.servicoProdutos = servicoProdutos;
        this.mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index(Guid listaId)
    {
        var lista =
            servicoListas.SelecionarPorId(listaId);

        if (lista is null)
            return RedirectToAction(
                "Index",
                "ListaCompras");

        var itens =
            servicoItens
                .SelecionarPorLista(listaId);

        VisualizarItensListaViewModel viewModel =
            new();

        viewModel.ListaComprasId = lista.Id;

        viewModel.NomeLista = lista.Nome;

        viewModel.ValorTotalLista = lista.ValorTotal;

        viewModel.Itens =
            mapper.Map<
                List<VisualizarItemListaViewModel>>
                (itens);

        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Cadastrar(Guid listaId)
    {
        CadastrarItemListaViewModel viewModel =
            new();

        viewModel.ListaComprasId = listaId;

        CarregarProdutos(viewModel);

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastrar(
        CadastrarItemListaViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            CarregarProdutos(viewModel);

            return View(viewModel);
        }

        CadastrarItemListaDto dto =
            mapper.Map<CadastrarItemListaDto>(
                viewModel);

        Result resultado =
            servicoItens.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
                ModelState.AddModelError(
                    string.Empty,
                    erro.Message);

            CarregarProdutos(viewModel);

            return View(viewModel);
        }

        TempData["Sucesso"] =
            "Item adicionado com sucesso!";

        return RedirectToAction(
            nameof(Index),
            new
            {
                listaId =
                    viewModel.ListaComprasId
            });
    }

    [HttpGet]
    public IActionResult Excluir(Guid id)
    {
        ViewBag.ItemId = id;

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(
        Guid id,
        Guid listaId)
    {
        Result resultado =
            servicoItens.Excluir(id);

        if (resultado.IsFailed)
        {
            TempData["Erro"] =
                resultado.Errors
                    .First()
                    .Message;
        }
        else
        {
            TempData["Sucesso"] =
                "Item removido com sucesso!";
        }

        return RedirectToAction(
            nameof(Index),
            new { listaId });
    }

    private void CarregarProdutos(
        CadastrarItemListaViewModel viewModel)
    {
        viewModel.Produtos =
            servicoProdutos
                .SelecionarTodos()
                .Select(p =>
                    new SelectListItem(
                        p.Nome,
                        p.Id.ToString()))
                .ToList();
    }
}