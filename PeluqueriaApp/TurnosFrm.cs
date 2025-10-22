using Microsoft.AspNetCore.Components.WebView.WindowsForms;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PeluqueriaApp;
using System;


namespace PeluqueriaApp
{
    public partial class TurnosFrm : Form
    {
        public TurnosFrm()
        {
            InitializeComponent();

            var services = new ServiceCollection();



            // Primero registramos Blazor
            services.AddWindowsFormsBlazorWebView();

            // Registramos EF y servicios propios
            //services.AddDbContext<GymDbContext>(options =>
    //options.UseSqlite("Data Source=MiniEstadioDB.db",
        //sqliteOptions => sqliteOptions.CommandTimeout(30)));

            //services.AddScoped<ClienteService>();
            //services.AddScoped<PagoService>();
            //services.AddScoped<PlanService>();
            //services.AddScoped<GeneroService>();


            // Construimos el provider
            var provider = services.BuildServiceProvider();

            // Configuración del BlazorWebView
            blazorWebView1.HostPage = "wwwroot/index.html";
            blazorWebView1.Services = provider;
            blazorWebView1.RootComponents.Add<App>("#app");

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
