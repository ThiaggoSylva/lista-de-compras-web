using AutoMapper;

using FluentResults;

using ListaDeComprasWeb.ModuloListaCompras.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloListaCompras.Dominio;

namespace ListaDeComprasWeb.ModuloListaCompras.Aplicacao.Servicos;

public class ServicoListaCompras
    : IServicoListaCompras
{
    private readonly IRepositorioListaCompras repositorio;

    private readonly IMapper mapper;

    public ServicoListaCompras(
        IRepositorioListaCompras repositorio,
        IMapper mapper)
    {
        this.repositorio = repositorio;
        this.mapper = mapper;
    }

    public Result Cadastrar(
        CadastrarListaComprasDto dto)
    {
        if (repositorio.ExisteNome(dto.Nome))
            return Result.Fail(
                "Já existe uma lista com este nome.");

        ListaCompras lista =
            new(dto.Nome);

        repositorio.Cadastrar(lista);

        return Result.Ok();
    }

    public Result Editar(
        EditarListaComprasDto dto)
    {
        if (repositorio.ExisteNome(
            dto.Id,
            dto.Nome))
        {
            return Result.Fail(
                "Já existe uma lista com este nome.");
        }

        ListaCompras? lista =
            repositorio.SelecionarPorId(dto.Id);

        if (lista is null)
            return Result.Fail(
                "Lista não encontrada.");

        lista.Nome = dto.Nome;

        lista.Status = dto.Status;

        repositorio.Editar(lista);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
    ListaCompras? lista =
        repositorio.SelecionarPorId(id);

    if (lista is null)
        return Result.Fail(
            "Lista não encontrada.");

    if (repositorio.PossuiItens(id))
        return Result.Fail(
            "Não é possível excluir listas com itens cadastrados.");

    repositorio.Excluir(lista);

    return Result.Ok();
    }

    public ListaComprasDto? SelecionarPorId(Guid id)
    {
    ListaCompras? lista =
        repositorio.SelecionarPorId(id);

    if (lista is null)
        return null;

    return new ListaComprasDto(
        lista.Id,
        lista.Nome,
        lista.DataCriacao,
        lista.Status,
        repositorio.ObterTotalItens(lista.Id),
        repositorio.ObterValorTotal(lista.Id)
    );
    }

    public List<ListaComprasDto> SelecionarTodos()
    {
    List<ListaCompras> listas =
        repositorio.SelecionarTodos();

    List<ListaComprasDto> dtos = [];

    foreach (var lista in listas)
    {
        dtos.Add(
            new ListaComprasDto(
                lista.Id,
                lista.Nome,
                lista.DataCriacao,
                lista.Status,
                repositorio.ObterTotalItens(lista.Id),
                repositorio.ObterValorTotal(lista.Id)
            )
        );
    }

    return dtos;
    }
}