using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReservaVuelos
{
    public class Vuelo
    {
        public string Codigo { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Asientos { get; set; } 

        public static List<Vuelo> VuelosRegistrados = new List<Vuelo>();

        public Vuelo(string codigo, string origen, string destino, DateTime fechaSalida, int asientos)
        {
            Codigo = codigo;
            Origen = origen;
            Destino = destino;
            FechaSalida = fechaSalida;
            Asientos = asientos;
        }

        public static string RegistrarVuelo(string codigo, string origen, string destino, DateTime fechaSalida, int asientos)
        {
           if(VuelosRegistrados.Any(v => v.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)))
            {
                return "El vuelo ya se encuentra registrado";
            }
            else
            {
                VuelosRegistrados.Add(new Vuelo(codigo, origen, destino, fechaSalida, asientos));
                return "Vuelo registrado";
            }
        }

        public static string RealizarReserva(string codigo, int cantidadReservar)
        {
            foreach (Vuelo vuelo in VuelosRegistrados)
            {
                if (vuelo.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase))
                {
                    if (vuelo.Asientos < cantidadReservar || vuelo.Asientos <= 0)
                    {
                        return "No hay asientos disponibles";
                    }
                    else
                    {
                        vuelo.Asientos -= cantidadReservar;
                        return "Reserva realizada";
                    }
                }
            }
            return "vuelo no encontrado";
        }

        public static List<Vuelo> ConsultarVuelos()
        {
            return VuelosRegistrados;
        }
    }
}
