using AutoMapper;

using ListaDeComprasWeb.ModuloProduto.Aplicacao.DTOs;
using ListaDeComprasWeb.ModuloProduto.Apresentacao.Models;
using ListaDeComprasWeb.ModuloProduto.Dominio;

namespace ListaDeComprasWeb.ModuloProduto.Aplicacao.Mapeamentos;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        #region Domínio -> DTO

        CreateMap<Produto, ProdutoDto>();

        #endregion

        #region DTO -> Domínio

        CreateMap<CadastrarProdutoDto, Produto>();

        CreateMap<EditarProdutoDto, Produto>();

        #endregion

        #region ViewModel -> DTO

        CreateMap<CadastrarProdutoViewModel,
                  CadastrarProdutoDto>();

        CreateMap<EditarProdutoViewModel,
                  EditarProdutoDto>();

        #endregion

        #region DTO -> ViewModel

        CreateMap<ProdutoDto,
                  EditarProdutoViewModel>();

        CreateMap<ProdutoDto,
                  VisualizarProdutoViewModel>();

        #endregion
    }
}