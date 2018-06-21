using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public delegate void DelegadoEstado(object sender, EventArgs e);

    public class Paquete : IMostrar<Paquete>
    {
        private string direccionDeEntrega;
        private EEstado estado;
        private string trackingID;

        public string DireccionDeEntrega { get { return this.direccionDeEntrega; } set { this.direccionDeEntrega = value; } }
        public EEstado Estado { get { return this.estado; } set { this.estado = value; } }
        public string TrackingID { get { return this.trackingID; } set { this.trackingID = value; } }

        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(10000);
                this.Estado++;
                this.InformaEstado(this.Estado, EventArgs.Empty);
            }
            PaqueteDAO.Insertar(this);
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return String.Format("{0} para {1}", this.trackingID, this.direccionDeEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return (p1.TrackingID == p2.TrackingID);
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        public Paquete(string direccionDeEntrega, string trackingID)
        {
            this.TrackingID = trackingID;
            this.DireccionDeEntrega = direccionDeEntrega;
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public event DelegadoEstado InformaEstado;
    }
}
