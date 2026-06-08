using FluentResults;

using ListaDeComprasWeb.ModuloItemListaCompras.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloItemListaCompras.Dominio;

using ListaDeComprasWeb.ModuloProduto.Dominio;
using ListaDeComprasWeb.ModuloCategoria.Dominio;

namespace ListaDeComprasWeb.ModuloItemListaCompras.Aplicacao.Servicos;

public class ServicoItemListaCompras
    : IServicoItemListaCompras
{
    private readonly IRepositorioItemListaCompras repositorioItens;

    private readonly IRepositorioProduto repositorioProdutos;

    private readonly IRepositorioCategoria repositorioCategorias;

    public ServicoItemListaCompras(
        IRepositorioItemListaCompras repositorioItens,
        IRepositorioProduto repositorioProdutos,
        IRepositorioCategoria repositorioCategorias)
    {
        this.repositorioItens = repositorioItens;
        this.repositorioProdutos = repositorioProdutos;
        this.repositorioCategorias = repositorioCategorias;
    }

    public Result Cadastrar(
        CadastrarItemListaDto dto)
    {
        if (dto.Quantidade <= 0)
            return Result.Fail(
                "A quantidade deve ser maior que zero.");

        Produto? produto =
            repositorioProdutos
                .SelecionarPorId(dto.ProdutoId);

        if (produto is null)
            return Result.Fail(
                "Produto não encontrado.");

        bool produtoJaExiste =
            repositorioItens
                .ProdutoJaExisteNaLista(
                    dto.ListaComprasId,
                    dto.ProdutoId);

        if (produtoJaExiste)
            return Result.Fail(
                "Este produto já foi adicionado na lista.");

        ItemListaCompras item =
            new(
                dto.ListaComprasId,
                dto.ProdutoId,
                dto.Quantidade);

        repositorioItens.Cadastrar(item);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        ItemListaCompras? item =
            repositorioItens
                .SelecionarPorId(id);

        if (item is null)
            return Result.Fail(
                "Item não encontrado.");

        repositorioItens.Excluir(item);

        return Result.Ok();
    }

    public List<ItemListaComprasDto> SelecionarPorLista(
        Guid listaId)
    {
        List<ItemListaCompras> itens =
            repositorioItens
                .SelecionarPorLista(listaId);

        List<ItemListaComprasDto> dtos = [];

        foreach (ItemListaCompras item in itens)
        {
            Produto? produto =
                repositorioProdutos
                    .SelecionarPorId(item.ProdutoId);

            if (produto is null)
                continue;

            Categoria? categoria =
                repositorioCategorias
                    .SelecionarPorId(produto.CategoriaId);

            string nomeCategoria =
                categoria?.Nome ?? string.Empty;

            dtos.Add(
                new ItemListaComprasDto(
                    item.Id,
                    item.ListaComprasId,
                    item.ProdutoId,
                    produto.Nome,
                    nomeCategoria,
                    item.Quantidade,
                    produto.Preco,
                    produto.Preco *
                    item.Quantidade
                )
            );
        }

        return dtos;
    }
}