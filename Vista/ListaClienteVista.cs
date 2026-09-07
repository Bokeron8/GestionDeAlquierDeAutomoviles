using System;
using System.Windows.Forms;
using GestionDeAlquierDeAutomoviles.Modelo;

namespace GestionDeAlquierDeAutomoviles.Vista
{
    public partial class ListaClienteVista : UserControl
    {
        public ListaClienteVista()
        {
            InitializeComponent();
            btnAgregar.Click += btnAgregar_Click;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var parentForm = FindForm() as PrincipalForm;
            parentForm?.MostrarCarga(parentForm.cargaCliente);
        }
    }
}
