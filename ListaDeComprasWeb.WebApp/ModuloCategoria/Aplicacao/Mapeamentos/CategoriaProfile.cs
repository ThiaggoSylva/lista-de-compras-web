using AutoMapper;

using ListaDeComprasWeb.ModuloCategoria.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloCategoria.Apresentacao.Models;
using ListaDeComprasWeb.ModuloCategoria.Dominio;

namespace ListaDeComprasWeb.ModuloCategoria.Aplicacao.Mapeamentos;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        #region Domínio -> DTO

        CreateMap<Categoria, CategoriaDto>();

        #endregion

        #region DTO -> Domínio

        CreateMap<CadastrarCategoriaDto, Categoria>();

        CreateMap<EditarCategoriaDto, Categoria>();

        #endregion

        #region ViewModel -> DTO

        CreateMap<CadastrarCategoriaViewModel,
                  CadastrarCategoriaDto>();

        CreateMap<EditarCategoriaViewModel,
                  EditarCategoriaDto>();

        #endregion

        #region DTO -> ViewModel

        CreateMap<CategoriaDto,
                  EditarCategoriaViewModel>();

        CreateMap<CategoriaDto,
                  VisualizarCategoriaViewModel>();

        #endregion
    }
}