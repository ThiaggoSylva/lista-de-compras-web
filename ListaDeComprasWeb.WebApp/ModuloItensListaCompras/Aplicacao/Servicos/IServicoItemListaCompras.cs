using FluentResults;

using ListaDeComprasWeb.ModuloItemListaCompras.Aplicacao.DTOs;

namespace ListaDeComprasWeb.ModuloItemListaCompras.Aplicacao.Servicos;

public interface IServicoItemListaCompras
{
    Result Cadastrar(
        CadastrarItemListaDto dto);

    Result Excluir(
        Guid id);

    List<ItemListaComprasDto> SelecionarPorLista(
        Guid listaId);
}