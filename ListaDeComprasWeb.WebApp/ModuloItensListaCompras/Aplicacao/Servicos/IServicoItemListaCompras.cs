using FluentResults;

using ListaDeComprasWeb.ModuloItensListaCompras.Aplicacao.DTOs;

namespace ListaDeComprasWeb.ModuloItensListaCompras.Aplicacao.Servicos;

public interface IServicoItemListaCompras
{
    Result Cadastrar(
        CadastrarItemListaDto dto);

    Result Excluir(
        Guid id);

    List<ItemListaComprasDto> SelecionarPorLista(
        Guid listaId);
}