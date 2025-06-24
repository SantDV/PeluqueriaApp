namespace PeluqueriaApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FrmSplash splash = new FrmSplash())
            {
                splash.Show();
                Application.DoEvents();
                System.Threading.Thread.Sleep(2500); // o pod�s usar await como en el m�todo MostrarYSaltarAsync()
            }

            Application.Run(new Inicio());
        }
    }
}