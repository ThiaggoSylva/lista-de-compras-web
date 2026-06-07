using AutoMapper;

using ListaDeComprasWeb.ModuloListaCompras.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloListaCompras.Apresentacao.Models;

namespace ListaDeComprasWeb.ModuloListaCompras.Aplicacao.Perfis;

public class ListaComprasProfile
    : Profile
{
    public ListaComprasProfile()
    {
        CreateMap<CadastrarListaComprasViewModel,
                  CadastrarListaComprasDto>();

        CreateMap<EditarListaComprasViewModel,
                  EditarListaComprasDto>();

        CreateMap<ListaComprasDto,
                  EditarListaComprasViewModel>();

        CreateMap<ListaComprasDto,
                  VisualizarListaComprasViewModel>();
    }
}