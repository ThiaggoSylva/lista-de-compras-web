using AutoMapper;

using FluentResults;

using ListaDeComprasWeb.ModuloProduto.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloProduto.Dominio;
using ListaDeComprasWeb.ModuloCategoria.Dominio;

namespace ListaDeComprasWeb.ModuloProduto.Aplicacao.Servicos;

public class ServicoProduto : IServicoProduto
{
    private readonly IRepositorioProduto repositorioProduto;
    private readonly IRepositorioCategoria repositorioCategoria;

    private readonly IMapper mapper;

    public ServicoProduto(
    IRepositorioProduto repositorioProduto,
    IRepositorioCategoria repositorioCategoria,
    IMapper mapper)
    {
    this.repositorioProduto = repositorioProduto;
    this.repositorioCategoria = repositorioCategoria;
    this.mapper = mapper;
    }

    public Result Cadastrar(
        CadastrarProdutoDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
            return Result.Fail(
                "O nome do produto é obrigatório.");

        if (dto.Nome.Length < 2 ||
            dto.Nome.Length > 100)
        {
            return Result.Fail(
                "O nome deve possuir entre 2 e 100 caracteres.");
        }

        if (dto.CategoriaId == Guid.Empty)
            return Result.Fail(
                "A categoria é obrigatória.");

        if (string.IsNullOrWhiteSpace(dto.UnidadeMedida))
            return Result.Fail(
                "A unidade de medida é obrigatória.");

        if (dto.PrecoAproximado <= 0)
            return Result.Fail(
                "O preço deve ser maior que zero.");

        if (repositorioProduto.ExisteProdutoNaCategoria(
            dto.Nome,
            dto.CategoriaId))
        {
            return Result.Fail(
                "Já existe um produto com este nome nesta categoria.");
        }

        Produto produto =
            mapper.Map<Produto>(dto);

        repositorioProduto.Cadastrar(produto);

        return Result.Ok();
    }

    public Result Editar(
        EditarProdutoDto dto)
    {
        Produto? produtoSelecionado =
            repositorioProduto.SelecionarPorId(dto.Id);

        if (produtoSelecionado is null)
            return Result.Fail(
                "Produto não encontrado.");

        if (string.IsNullOrWhiteSpace(dto.Nome))
            return Result.Fail(
                "O nome do produto é obrigatório.");

        if (dto.Nome.Length < 2 ||
            dto.Nome.Length > 100)
        {
            return Result.Fail(
                "O nome deve possuir entre 2 e 100 caracteres.");
        }

        if (dto.CategoriaId == Guid.Empty)
            return Result.Fail(
                "A categoria é obrigatória.");

        if (string.IsNullOrWhiteSpace(dto.UnidadeMedida))
            return Result.Fail(
                "A unidade de medida é obrigatória.");

        if (dto.PrecoAproximado <= 0)
            return Result.Fail(
                "O preço deve ser maior que zero.");
        
        if (repositorioProduto.ExisteProdutoNaCategoria(
            dto.Id,
            dto.Nome,
            dto.CategoriaId))
        {
            return Result.Fail(
                "Já existe um produto com este nome nesta categoria.");
        }

        Produto produtoEditado =
            mapper.Map<Produto>(dto);

        repositorioProduto.Editar(produtoEditado);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Produto? produtoSelecionado =
            repositorioProduto.SelecionarPorId(id);

        if (produtoSelecionado is null)
            return Result.Fail(
                "Produto não encontrado.");

        repositorioProduto.Excluir(
            produtoSelecionado);

        return Result.Ok();
    }

    public ProdutoDto? SelecionarPorId(Guid id)
    {
    Produto? produto =
        repositorioProduto.SelecionarPorId(id);

    if (produto is null)
        return null;

    string nomeCategoria =
        repositorioCategoria
            .SelecionarPorId(produto.CategoriaId)?
            .Nome ?? string.Empty;

    return new ProdutoDto(
        produto.Id,
        produto.Nome,
        produto.CategoriaId,
        nomeCategoria,
        produto.UnidadeMedida,
        produto.Preco
    );
    }

    public List<ProdutoDto> SelecionarTodos()
    {
    List<Produto> produtos =
        repositorioProduto.SelecionarTodos();

    List<ProdutoDto> produtosDto = [];

    foreach (Produto produto in produtos)
    {
        string nomeCategoria =
            repositorioCategoria
                .SelecionarPorId(produto.CategoriaId)?
                .Nome ?? string.Empty;

        produtosDto.Add(
            new ProdutoDto(
                produto.Id,
                produto.Nome,
                produto.CategoriaId,
                nomeCategoria,
                produto.UnidadeMedida,
                produto.Preco
            )
        );
    }

        return produtosDto;
    }
}