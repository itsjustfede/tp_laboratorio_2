using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes { get { return this.paquetes; } set { this.paquetes = value; } }

        public Correo()
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                    item.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            List<Paquete> nuevaLista = (List<Paquete>)((Correo)elemento).paquetes;
            StringBuilder sb = new StringBuilder();
            foreach (Paquete item in nuevaLista)
            {
                sb.AppendFormat("{0} para {1} ({2})", item.TrackingID, item.DireccionDeEntrega, item.Estado.ToString());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El ID ya existe");
                }
            }

            Thread thread = new Thread(p.MockCicloDeVida);
            c.Paquetes.Add(p);
            c.mockPaquetes.Add(thread);
            thread.Start();

            return c;
        }
    }
}
