using AutoMapper;

using ListaDeComprasWeb.ModuloCategoria.Dominio;
using ListaDeComprasWeb.ModuloCategoria.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloCategoria.Apresentacao.Models;

namespace ListaDeComprasWeb.ModuloCategoria.Aplicacao.Mapeamentos;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<CadastrarCategoriaViewModel,
                  CadastrarCategoriaDto>();

        CreateMap<EditarCategoriaViewModel,
                  EditarCategoriaDto>();

        CreateMap<CadastrarCategoriaDto,
                  Categoria>();

        CreateMap<EditarCategoriaDto,
                  Categoria>();

        CreateMap<Categoria,
                  CategoriaDto>();

        CreateMap<CategoriaDto,
                  VisualizarCategoriaViewModel>();

        CreateMap<CategoriaDto,
                  EditarCategoriaViewModel>();
    }
}