using AutoMapper;

using ListaDeComprasWeb.Compartilhado;

using ListaDeComprasWeb.ModuloCategoria.Dominio;

using ListaDeComprasWeb.ModuloCategoria.Aplicacao.DTOs;

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

    public Resultado<CategoriaDto> Cadastrar(
        CadastrarCategoriaDto dto)
    {
        if (repositorioCategoria.ExisteNome(dto.Nome))
        {
            return Resultado<CategoriaDto>.Falha(
                "Já existe uma categoria com este nome.");
        }

        Categoria categoria =
            mapper.Map<Categoria>(dto);

        repositorioCategoria.Cadastrar(categoria);

        CategoriaDto categoriaDto =
            mapper.Map<CategoriaDto>(categoria);

        return Resultado<CategoriaDto>.Ok(
            categoriaDto);
    }

    public Resultado<CategoriaDto> Editar(
        EditarCategoriaDto dto)
    {
        Categoria? categoria =
            repositorioCategoria.SelecionarPorId(dto.Id);

        if (categoria is null)
        {
            return Resultado<CategoriaDto>.Falha(
                "Categoria não encontrada.");
        }

        if (repositorioCategoria.ExisteNome(
                dto.Id,
                dto.Nome))
        {
            return Resultado<CategoriaDto>.Falha(
                "Já existe uma categoria com este nome.");
        }

        Categoria categoriaEditada =
            mapper.Map<Categoria>(dto);

        repositorioCategoria.Editar(
            dto.Id,
            categoriaEditada);

        CategoriaDto categoriaDto =
            mapper.Map<CategoriaDto>(
                categoriaEditada);

        return Resultado<CategoriaDto>.Ok(
            categoriaDto);
    }

    public Resultado Excluir(Guid id)
    {
        Categoria? categoria =
            repositorioCategoria.SelecionarPorId(id);

        if (categoria is null)
        {
            return Resultado.Falha(
                "Categoria não encontrada.");
        }

        if (repositorioCategoria.PossuiProdutos(id))
        {
            return Resultado.Falha(
                "Não é possível excluir uma categoria que possui produtos vinculados.");
        }

        repositorioCategoria.Excluir(id);

        return Resultado.Ok();
    }

    public CategoriaDto? SelecionarPorId(Guid id)
    {
        Categoria? categoria =
            repositorioCategoria.SelecionarPorId(id);

        if (categoria is null)
            return null;

        return mapper.Map<CategoriaDto>(categoria);
    }

    public List<CategoriaDto> SelecionarTodos()
    {
        List<Categoria> categorias =
            repositorioCategoria.SelecionarTodos();

        return mapper.Map<List<CategoriaDto>>(
            categorias);
    }
}