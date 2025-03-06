using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservaVuelos
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
            ActualizarVuelos();
        }

        private void btnAgregarVuelo_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoVuelo.Text;
            string origen = txtOrigen.Text;
            string destino = txtDestino.Text;
            DateTime fechaSalida = dtpFechaSalida.Value;

            if (!int.TryParse(txtAsientosDisponibles.Text, out int asientos))
            {
                MessageBox.Show("El número de asientos debe ser un número entero");
                return;
            }

            string resultado = Vuelo.RegistrarVuelo(codigo, origen, destino, fechaSalida, asientos);
           MessageBox.Show(resultado);
            ActualizarVuelos();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigoReserva.Text;
            if (!int.TryParse(txtCantidadReservas.Text, out int cantidadReservar))
            {
                MessageBox.Show("La cantidad de asientos a reservar debe ser un número entero");
                return;
            }
            string resultado = Vuelo.RealizarReserva(codigo, cantidadReservar);
            MessageBox.Show(resultado);
            ActualizarVuelos();
        }

        private void ActualizarVuelos()
        {
          listBox1.Items.Clear();
            foreach (var vuelo in Vuelo.ConsultarVuelos())
            {
                listBox1.Items.Add(
                    $"{vuelo.Codigo} - {vuelo.Origen} a {vuelo.Destino} - " +
                    $"{vuelo.FechaSalida.ToShortDateString()} - Asientos: {vuelo.Asientos}"
                );
            }

        }
    }
}
