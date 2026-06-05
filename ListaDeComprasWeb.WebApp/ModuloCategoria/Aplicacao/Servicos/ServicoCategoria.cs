using AutoMapper;

using FluentResults;

using ListaDeComprasWeb.ModuloCategoria.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloCategoria.Dominio;

namespace ListaDeComprasWeb.ModuloCategoria.Aplicacao.Servicos;

public class ServicoCategoria : IServicoCategoria
{
    private readonly IRepositorioCategoria repositorioCategoria;

    private readonly IMapper mapper;

    public ServicoCategoria(
        IRepositorioCategoria repositorioCategoria,
        IMapper mapper)
    {
        this.repositorioCategoria = repositorioCategoria;
        this.mapper = mapper;
    }

    public Result Cadastrar(
        CadastrarCategoriaDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
            return Result.Fail(
                "O nome da categoria é obrigatório.");

        if (dto.Nome.Length > 50)
            return Result.Fail(
                "O nome deve possuir no máximo 50 caracteres.");

        if (repositorioCategoria.ExisteNome(dto.Nome))
            return Result.Fail(
                "Já existe uma categoria cadastrada com este nome.");

        Categoria categoria =
            mapper.Map<Categoria>(dto);

        repositorioCategoria.Cadastrar(categoria);

        return Result.Ok();
    }

    public Result Editar(
        EditarCategoriaDto dto)
    {
        Categoria? categoriaSelecionada =
            repositorioCategoria.SelecionarPorId(dto.Id);

        if (categoriaSelecionada is null)
            return Result.Fail(
                "Categoria não encontrada.");

        if (string.IsNullOrWhiteSpace(dto.Nome))
            return Result.Fail(
                "O nome da categoria é obrigatório.");

        if (dto.Nome.Length > 50)
            return Result.Fail(
                "O nome deve possuir no máximo 50 caracteres.");

        if (repositorioCategoria.ExisteNome(
            dto.Id,
            dto.Nome))
        {
            return Result.Fail(
                "Já existe uma categoria cadastrada com este nome.");
        }

        Categoria categoriaEditada =
            mapper.Map<Categoria>(dto);

        repositorioCategoria.Editar(
            categoriaEditada);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Categoria? categoriaSelecionada =
            repositorioCategoria.SelecionarPorId(id);

        if (categoriaSelecionada is null)
            return Result.Fail(
                "Categoria não encontrada.");

        if (repositorioCategoria.PossuiProdutos(id))
            return Result.Fail(
                "Não é possível excluir uma categoria que possui produtos vinculados.");

        repositorioCategoria.Excluir(
            categoriaSelecionada);

        return Result.Ok();
    }

    public CategoriaDto? SelecionarPorId(Guid id)
    {
        Categoria? categoriaSelecionada =
            repositorioCategoria.SelecionarPorId(id);

        if (categoriaSelecionada is null)
            return null;

        return mapper.Map<CategoriaDto>(
            categoriaSelecionada);
    }

    public List<CategoriaDto> SelecionarTodos()
    {
        List<Categoria> categorias =
            repositorioCategoria.SelecionarTodos();

        return mapper.Map<List<CategoriaDto>>(
            categorias);
    }
}