using FluentResults;

using ListaDeComprasWeb.ModuloProduto.Aplicacao.DTOs;

namespace ListaDeComprasWeb.ModuloProduto.Aplicacao.Servicos;

public interface IServicoProduto
{
    Result Cadastrar(
        CadastrarProdutoDto dto);

    Result Editar(
        EditarProdutoDto dto);

    Result Excluir(
        Guid id);

    ProdutoDto? SelecionarPorId(
        Guid id);

    List<ProdutoDto> SelecionarTodos();
}