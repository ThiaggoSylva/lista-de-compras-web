using AutoMapper;

using ListaDeComprasWeb.ModuloItemListaCompras.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloItemListaCompras.Apresentacao.Models;

namespace ListaDeComprasWeb.ModuloItemListaCompras.Aplicacao.Perfis;

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