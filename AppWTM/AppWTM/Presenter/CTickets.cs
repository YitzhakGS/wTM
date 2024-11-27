using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWTM.Presenter
{
    public class CTickets
    {
        public int Id_Ticket { get; set; }
        public int fkUsuario { get; set; }
        public string Ticket_Titulo { get; set; }
        public int fkPrioridad { get; set; }
        public string Tick_Descripcion { get; set; }
        public int fkEstado { get; set; }

        public int fkArea { get; set; }

        public CTickets() 
        {
            Id_Ticket = 0;
            fkUsuario = 0;
            Ticket_Titulo = "";
            fkPrioridad = 0;
            Tick_Descripcion = "";
            fkEstado = 0;
            fkArea = 0;
        }
    }
}