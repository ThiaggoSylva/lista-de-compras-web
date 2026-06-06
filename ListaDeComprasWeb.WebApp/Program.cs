using ListaDeComprasWeb.Compartilhado;
using ListaDeComprasWeb.ModuloCategoria.Aplicacao.Servicos;
using ListaDeComprasWeb.ModuloCategoria.Dominio;
using ListaDeComprasWeb.ModuloCategoria.Infraestrutura;
using ListaDeComprasWeb.ModuloProduto.Dominio;
using ListaDeComprasWeb.ModuloProduto.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

#region Contexto Json

ContextoJson contexto = new();

contexto.Carregar();

builder.Services.AddSingleton(contexto);

#endregion

#region MVC

builder.Services
    .AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add(
            "/Modulo{1}/Apresentacao/Views/{1}/{0}.cshtml");

        options.ViewLocationFormats.Add(
            "/Modulo{1}/Apresentacao/Views/{0}.cshtml");

        options.ViewLocationFormats.Add(
            "/Compartilhado/Apresentacao/Views/{0}.cshtml");
    });

#endregion

#region AutoMapper

builder.Services.AddAutoMapper(
    AppDomain.CurrentDomain.GetAssemblies());

#endregion

#region Categoria

builder.Services.AddScoped<IRepositorioCategoria,
                           RepositorioCategoriaEmArquivo>();

builder.Services.AddScoped<IServicoCategoria,
                           ServicoCategoria>();

builder.Services.AddScoped<IRepositorioProduto,
                           RepositorioProdutoEmArquivo>();

#endregion

var app = builder.Build();

#region Pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categoria}/{action=Index}/{id?}");

#endregion

app.Run();

