using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace FrmTP4
{
    public partial class FrmPrincipal : Form
    {
        private Correo correo;

        public FrmPrincipal()
        {
            correo = new Correo();

            FormClosing += FrmPrincipal_FormClosing;
            InitializeComponent();
        }

        private void FrmPrincipal_FormClosing1(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);

            nuevoPaquete.InformaEstado += this.paq_InformaEstado;

            try
            {
                this.correo += nuevoPaquete;
            }
            catch (TrackingIdRepetidoException)
            {
                MessageBox.Show("El tracking ID " + this.mtxtTrackingID.Text + " ya existe");
            }

            this.ActualizarEstados();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                DelegadoEstado d = new DelegadoEstado(paq_InformaEstado);

                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                if (item.Estado == EEstado.Ingresado)
                    this.lstEstadoIngresado.Items.Add(item);

                else if (item.Estado == EEstado.EnViaje)
                    this.lstEstadoEnViaje.Items.Add(item);

                else
                    this.lstEstadoEntregado.Items.Add(item);
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }


        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);

                try
                {
                    GuardaString.Guardar(this.rtbMostrar.Text, "salida.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo guardar");
                }
            }
        }

        private void mostrarToolStripMenuItem(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
