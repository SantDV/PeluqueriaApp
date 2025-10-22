using Microsoft.AspNetCore.Components.WebView.WindowsForms;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PeluqueriaApp;
using System;


namespace WinFormsBlazor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            var services = new ServiceCollection();



            // Primero registramos Blazor
            services.AddWindowsFormsBlazorWebView();

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
