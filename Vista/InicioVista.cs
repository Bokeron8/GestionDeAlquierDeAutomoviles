using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    /// <summary>
    /// Sections a role can reach without going through the menu. The home screen must not
    /// offer more than the menu shows, so PrincipalForm builds this list with the same
    /// role rules it applies to the menu.
    /// </summary>
    public enum SeccionInicio
    {
        Vehiculos,
        Clientes,
        Reservas,
        Alquileres,
        Danios,
        Empleados,
        Estados,
        Roles,
        Reportes
    }

    public partial class InicioVista : UserControl
    {
        public InicioVista()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Greets the signed-in employee and draws one shortcut per section their role can
        /// reach. Called every time the section is opened, so it always reflects the session.
        /// </summary>
        public void Configurar(string nombre, string rol, IReadOnlyList<SeccionInicio> secciones)
        {
            lblBienvenida.Text = string.IsNullOrWhiteSpace(nombre) ? "Bienvenido" : $"Hola, {nombre}";
            lblRol.Text = string.IsNullOrWhiteSpace(rol) ? "" : $"Rol: {rol}";

            panelAccesos.Controls.Clear();
            foreach (var seccion in secciones)
            {
                panelAccesos.Controls.Add(CrearBoton(seccion));
            }

            bool hayAccesos = secciones.Count > 0;
            lblAccesos.Visible = hayAccesos;
            lblPista.Visible = hayAccesos;
        }

        private Button CrearBoton(SeccionInicio seccion)
        {
            var boton = new Button
            {
                Text = NombreDe(seccion),
                Size = new Size(200, 56),
                Margin = new Padding(0, 0, 14, 14),
                FlatStyle = FlatStyle.Flat,
                BackColor = Theme.Primario,
                ForeColor = Color.White,
                Font = Theme.CuerpoNegrita(),
                Cursor = Cursors.Hand,
                Tag = seccion
            };
            boton.FlatAppearance.BorderSize = 0;
            boton.Click += BotonSeccion_Click;
            return boton;
        }

        private void BotonSeccion_Click(object? sender, EventArgs e)
        {
            var boton = sender as Button;
            if (boton == null) return;

            var parentForm = FindForm() as PrincipalForm;
            if (boton.Tag is SeccionInicio seccion)
            {
                parentForm?.AbrirSeccion(seccion);
            }
        }

        private static string NombreDe(SeccionInicio seccion)
        {
            switch (seccion)
            {
                case SeccionInicio.Vehiculos: return "Vehículos";
                case SeccionInicio.Clientes: return "Clientes";
                case SeccionInicio.Reservas: return "Reservas";
                case SeccionInicio.Alquileres: return "Alquileres";
                case SeccionInicio.Danios: return "Daños";
                case SeccionInicio.Empleados: return "Empleados";
                case SeccionInicio.Estados: return "Estados";
                case SeccionInicio.Roles: return "Roles";
                case SeccionInicio.Reportes: return "Reportes";
                default: return seccion.ToString();
            }
        }
    }
}
