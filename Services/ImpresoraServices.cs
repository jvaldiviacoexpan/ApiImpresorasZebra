using ApiImpresorasZebra.Models;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;

namespace ApiImpresorasZebra.Services
{
    public static class ImpresoraServices
    {
        public static AnyModels.WsStatus EstadoImpresora(AnyModels.Impresora imp)
        {
            AnyModels.WsStatus status = new();
            Connection connection = new TcpConnection(imp.Ip, TcpConnection.DEFAULT_ZPL_TCP_PORT);
            try
            {
                connection.Open();
                ZebraPrinter printer = ZebraPrinterFactory.GetInstance(connection);
                PrinterStatus printerStatus = printer.GetCurrentStatus();

                if (printerStatus.isReadyToPrint)
                {
                    status.Message = "Impresora lista para imprimir.";
                    status.Status = "T";
                    status.Id = 0;
                    return status;
                }
                else
                {
                    status.Message = "Problemas para imprimir. ";
                    if (printerStatus.isPaused)     { status.Message += "Impresora pausada. "; }
                    if (printerStatus.isHeadOpen)   { status.Message += "Cabezal de la impresora abierta. "; }
                    if (printerStatus.isPaperOut)   { status.Message += "Impresora sin papel. "; }
                    if (printerStatus.isHeadCold)   { status.Message += "Cabecera fría. "; }
                    if (printerStatus.isHeadTooHot) { status.Message += "Cabecera muy caliente. "; }
                    status.Id = 1;
                    status.Status = "F";
                    return status;
                }

            }
            catch (ConnectionException ex)
            {
                status.Id = 2;
                status.Status = "W";
                status.Message = "Error al conectar con la impresora.";
                status.Message_Exception = ex.ToString();
                status.Message_Exception_Descr = ex.Message;
                return status;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
