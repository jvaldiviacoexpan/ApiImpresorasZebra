namespace ApiImpresorasZebra.Models
{
    public class AnyModels
    {

        public class Datos
        {
            public Impresora Impresora { get; set; }
            public WsStatus Status { get; set; }
        }

        public class Impresora
        {
            public string Ip { get; set; }
        }

        public class WsStatus
        {
            public int Id { get; set; }
            public string Message { get; set; }
            public string Status { get; set; }
            public string Message_Exception { get; set; }
            public string Message_Exception_Descr { get; set; }
        }
    }
}
