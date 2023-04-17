using Infraestructure.Models;
using Infraestructure.Repository;

using PdfSharp.Drawing;

using PdfSharp.Pdf;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApplicationCore.Services
{

    public class ServiceEstadoCuenta : IServiceEstadoCuenta
    {
        private IRepositoryEstadoCuenta repository;
        public ServiceEstadoCuenta()
        {
            repository = new RepositoryEstadoCuenta();
        }

        public IEnumerable<Factura> GetAll() => repository.GetAll();
        

        public IEnumerable<Factura> GetByIdProp(int id)=> repository.GetByIdProp(id);
        public IEnumerable<Factura> GetEstadoCuentaByFilter(bool active, int id)=> repository.GetEstadoCuentaByFilter(active, id);

        public Factura GetDetalleEstadoCuenta(int idEstadoCuenta) => repository.GetDetalleEstadoCuenta(idEstadoCuenta);

        public IEnumerable<Factura> GetEstadoCuentaPendiente() => repository.GetEstadoCuentaPendiente();



        public Factura GetOldestFactura(int idUsuario)
        {
            IRepositoryEstadoCuenta repository = new RepositoryEstadoCuenta();
            return repository.GetOldestFactura(idUsuario);
        }
        public void Create(Factura factura) =>repository.Create(factura);
        
        public IEnumerable<Factura> GetFacturasByFecha() => repository.GetFacturasByFecha();

        public int UpdateNumTarjeta(string numTajeta, int idFactura) {
            const string FORMATO = "**** **** **** ****";
            string numTarjetaParsed = FORMATO + numTajeta.Substring(numTajeta.Length - 4);
            return repository.UpdateNumTarjeta(numTarjetaParsed, idFactura); 
        }

        public int PagarFactura(int idFactura) => repository.PagarFactura(idFactura);

        public byte[] GenerarPDF(Factura oFactura)
        {
            // Crear el documento PDF
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Dibujar el encabezado
            gfx.DrawString("Factura", new XFont("Verdana", 20), XBrushes.Black, new XRect(0, 0, page.Width, 50), XStringFormats.Center);

            // Dibujar el detalle de la factura
            gfx.DrawString("Id: " + oFactura.Id, new XFont("Verdana", 12, XFontStyle.Underline), XBrushes.Black, new XRect(0, 40, page.Width, 20), XStringFormats.TopLeft);
            gfx.DrawString("Fecha: " + oFactura.FechaFacturacion.ToString(), new XFont("Verdana", 12, XFontStyle.Underline), XBrushes.Black, new XRect(0, 60, page.Width, 20), XStringFormats.TopLeft);
            gfx.DrawString("Propiedad: " + oFactura.Propiedad.NumPropiedad, new XFont("Verdana", 12,XFontStyle.Underline), XBrushes.Black, new XRect(0, 80, page.Width, 20), XStringFormats.TopLeft);
            gfx.DrawString("Usuario: " + oFactura.Propiedad.Usuario.Nombre + " " + oFactura.Propiedad.Usuario.Apellido1, new XFont("Verdana", 12, XFontStyle.Underline), XBrushes.Black, new XRect(0, 100, page.Width, 20), XStringFormats.TopLeft);

            // Crear la tabla para el detalle de la factura
            // Dibujar la tabla de detalles
            gfx.DrawRectangle(XBrushes.Black, new XRect(10, 150, page.Width - 20, 30));
            gfx.DrawString("Id", new XFont("Verdana", 12), XBrushes.White, new XRect(10, 155, 50, 20), XStringFormats.TopLeft);
            gfx.DrawString("Descripción", new XFont("Verdana", 12), XBrushes.White, new XRect(60, 155, 200, 20), XStringFormats.TopLeft);
            gfx.DrawString("Total", new XFont("Verdana", 12), XBrushes.White, new XRect(page.Width - 110, 155, 100, 20), XStringFormats.TopLeft);

            gfx.DrawRectangle(XBrushes.LightGray, new XRect(10, 180, page.Width - 20, 20));
            gfx.DrawString(oFactura.PlanCobro.Id.ToString(), new XFont("Verdana", 12), XBrushes.Black, new XRect(10, 182, 50, 20), XStringFormats.TopLeft);
            gfx.DrawString(oFactura.PlanCobro.Descripcion, new XFont("Verdana", 12), XBrushes.Black, new XRect(60, 182, 200, 20), XStringFormats.TopLeft);
            gfx.DrawString("$" + oFactura.PlanCobro.Total.ToString(), new XFont("Verdana", 12), XBrushes.Black, new XRect(page.Width - 110, 182, 100, 20), XStringFormats.TopLeft);


            // Dibujar el total de la factura
            gfx.DrawString("Total: " + oFactura.Total.ToString(), new XFont("Verdana", 12), XBrushes.Black, new XRect(0, page.Height - 50, page.Width, 20), XStringFormats.BottomRight);

            // Guardar el documento en un MemoryStream
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close();

            // Devolver el contenido del MemoryStream como arreglo de bytes
            return stream.ToArray();
        }


        public async Task EnviarPorCorreo(Factura factura, byte[] pdf)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("gymforcecr@hotmail.com");
            message.To.Add(new MailAddress(factura.Propiedad.Usuario.Email));
            message.Subject = "Factura de Condominios Villa del Poás";
            message.Body = "Adjuntamos la factura correspondiente al plan de cobro " + factura.PlanCobro.Descripcion + " con un total de $" + factura.Total.ToString() + ".";

            // Adjuntar el PDF
            MemoryStream stream = new MemoryStream(pdf);
            message.Attachments.Add(new Attachment(stream, "Factura.pdf"));

            // Enviar el correo electrónico usando SmtpClient
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("gymforcecr@hotmail.com", "proyectoprogra3");
            client.EnableSsl = true;
            await client.SendMailAsync(message);
        }
    }
}
