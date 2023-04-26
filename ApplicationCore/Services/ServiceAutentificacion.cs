using ApplicationCore.Utils;
using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf.Content.Objects;

namespace ApplicationCore.Services
{
    public class ServiceAutentificacion : IServiceAutentificacion
    {
        private IRepositoryAutentificacion repository;
        public ServiceAutentificacion()
        {
            repository = new RepositoryAutentificacion();
        }

        public int CambiarClave(string email, string clave)
        {
            return repository.CambiarClave(email, Utilitarios.ConvertirSha256(clave));
        }

        public void EnviarCodPorCorreo(string email, string codigo)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("villasdelpoas@outlook.com");
            message.To.Add(new MailAddress(email));
            message.Subject = "Solicitd Recuperación de contraseña Villas del Poás";
            message.IsBodyHtml = true;
            message.Body = "<p>Digite el siguiente código para restablecer su contraseña </br> <strong>" + codigo + "</strong></p>";


            // Enviar el correo electrónico usando SmtpClient
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("villasdelpoas@outlook.com", "progra1234");
            client.EnableSsl = true;
            client.Send(message);
        }

        public Usuario Login(string email, string clave)
        {
            clave = Utilitarios.ConvertirSha256(clave);
            return repository.Login(email, clave);
        }

        public  int RestablecerContrasennaByEmail(string email)
        {
            String codigo = Utilitarios.GenerateRandomCode();
            EnviarCodPorCorreo(email, codigo);
            return repository.RestablecerContrasennaByEmail(email, Utilitarios.ConvertirSha256(codigo));
        }

        public bool verificarCodRestablecer(string email,string codigo)
        {
            return repository.verificarCodRestablecer(email,Utilitarios.ConvertirSha256(codigo));
        }
    }
}
