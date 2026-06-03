using ListaDeComprasWeb.Compartilhado;
using ListaDeComprasWeb.ModuloCategoria.Aplicacao.DTOs;

namespace ListaDeComprasWeb.ModuloCategoria.Aplicacao.Servicos;

public interface IServicoCategoria
{
    Resultado<CategoriaDto> Cadastrar(
        CadastrarCategoriaDto dto);

    Resultado<CategoriaDto> Editar(
        EditarCategoriaDto dto);

    Resultado Excluir(Guid id);

    CategoriaDto? SelecionarPorId(Guid id);

    List<CategoriaDto> SelecionarTodos();
}