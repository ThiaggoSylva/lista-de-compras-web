using AutoMapper;

using ListaDeComprasWeb.ModuloItensListaCompras.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloItensListaCompras.Apresentacao.Models;

namespace ListaDeComprasWeb.ModuloItensListaCompras.Aplicacao.Perfis;

public class ItemListaComprasProfile
    : Profile
{
    public ItemListaComprasProfile()
    {
        CreateMap<CadastrarItemListaViewModel,
                  CadastrarItemListaDto>();

        CreateMap<ItemListaComprasDto,
                  VisualizarItemListaViewModel>();
    }
}