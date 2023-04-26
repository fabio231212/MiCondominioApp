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

namespace ApplicationCore.Services
{
    public class ServiceReporte : IServiceReporte
    {
        private readonly IRepositoryReporte _Repository;
        public ServiceReporte() {
         _Repository = new RepositoryReporte();
        }

        public dynamic reporteDeudas(DateTime? fechaInicio, DateTime? fechaFin, string numPropiedad)
        {
           IEnumerable<Factura> lista =  _Repository.reporteDeudas(fechaInicio, fechaFin, numPropiedad);
            double total = 0;
            if (lista.Any())
            {
                   
                
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Dibujar el título
                gfx.DrawString("Deudas Pendientes", new XFont("Verdana", 20), XBrushes.Green, new XRect(0, 0, page.Width, 50), XStringFormats.Center);

                // Dibujar el detalle de la factura
                gfx.DrawString("Fecha de Inicio: " + fechaInicio.ToString(), new XFont("Verdana", 12), XBrushes.Black, new XRect(0, 60, page.Width, 20), XStringFormats.TopLeft);
                gfx.DrawString("Fecha Final: " + fechaFin.ToString(), new XFont("Verdana", 12), XBrushes.Black, new XRect(0, 80, page.Width, 20), XStringFormats.TopLeft);
                gfx.DrawString("Número de Propiedad: " + (numPropiedad != "" ? numPropiedad : "Todos"), new XFont("Verdana", 12), XBrushes.Black, new XRect(0, 100, page.Width, 20), XStringFormats.TopLeft);

                // Crear la tabla para el detalle de la factura
                gfx.DrawRectangle(XBrushes.Green, new XRect(10, 150, page.Width - 20, 30));

                // Dibujar el encabezado de la tabla
                gfx.DrawString("Id Factura", new XFont("Verdana", 12, XFontStyle.Bold), XBrushes.White, new XRect(10, 155, 50, 20), XStringFormats.TopLeft);
                gfx.DrawString("Fecha de facturación", new XFont("Verdana", 12, XFontStyle.Bold), XBrushes.White, new XRect(100, 155, 100, 20), XStringFormats.TopLeft);
                if (numPropiedad == "")
                {
                    gfx.DrawString("Número de propiedad", new XFont("Verdana", 12, XFontStyle.Bold), XBrushes.White, new XRect(230, 155, 100, 20), XStringFormats.TopLeft);
                }
                gfx.DrawString("Plan de Cobro", new XFont("Verdana", 12, XFontStyle.Bold), XBrushes.White, new XRect(400, 155, 100, 20), XStringFormats.TopLeft);
                gfx.DrawString("Total", new XFont("Verdana", 12, XFontStyle.Bold), XBrushes.White, new XRect(page.Width - 70, 155, 100, 20), XStringFormats.TopLeft);

                // Dibujar la información de cada factura en la tabla
                int y = 185;
                foreach (Factura item in lista)
                {
                    gfx.DrawRectangle(XBrushes.White, new XRect(10, y, page.Width - 20, 20));
                    gfx.DrawString(item.Id.ToString(), new XFont("Verdana", 12), XBrushes.Black, new XRect(10, y, 50, 20), XStringFormats.TopLeft);
                    gfx.DrawString(item.FechaFacturacion.ToString(), new XFont("Verdana", 12), XBrushes.Black, new XRect(100, y, 100, 20), XStringFormats.TopLeft);
                    if (numPropiedad == "")
                    {
                        gfx.DrawString(item.Propiedad.NumPropiedad.ToString(), new XFont("Verdana", 12), XBrushes.Black, new XRect(260, y, 100, 20), XStringFormats.TopLeft);
                    }
                    gfx.DrawString(item.PlanCobro.Descripcion, new XFont("Verdana", 12), XBrushes.Black, new XRect(400, y, 100, 20), XStringFormats.TopLeft);
                    gfx.DrawString("₡ " + item.Total.ToString(), new XFont("Verdana", 12), XBrushes.Black, new XRect(page.Width - 70, y, 100, 20), XStringFormats.TopLeft);
                    y += 20;
                    total += (double)item.Total;
                }

                // Dibujar el total de la factura
                gfx.DrawString("Total pendiente: ₡ " + total.ToString(), new XFont("Verdana", 12), XBrushes.Green, new XRect(0, page.Height - 50, page.Width, 20), XStringFormats.BottomRight);

                // Guardar el documento en un MemoryStream
                MemoryStream stream = new MemoryStream();
                document.Save(stream);
                document.Close();

                // Devolver el contenido del MemoryStream como arreglo de bytes
                return stream.ToArray();
    }
            else
            {
                return null;
            }
        }


       
    }
}

