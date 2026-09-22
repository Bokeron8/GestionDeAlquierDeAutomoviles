using GestionDeAlquierDeAutomoviles.Vista;

namespace GestionDeAlquierDeAutomoviles
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            while (true)
            {
                var loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new PrincipalForm(loginForm.EmpleadoLogueado));
                }
                else
                {
                    break;
                }
            }
        }
    }
}
