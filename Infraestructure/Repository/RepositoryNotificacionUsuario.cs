﻿using Infraestructure.Models;
using Infraestructure.Repository.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryNotificacionUsuario : IRepositoryNotificacionUsuario
    {
        public IEnumerable<NotificacionUsuario> GetNotificacionByIdUser(int id)
        {
            IEnumerable<NotificacionUsuario> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los libros incluyendo el autor
                    lista = ctx.NotificacionUsuario.Include("Notificacion").Where(x => (bool)!x.Leida).ToList();

                    //lista = ctx.Libro.Include(x=>x.Autor).ToList();

                }
                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public NotificacionUsuario MarcarLeido(int id)
        {
            NotificacionUsuario oNotificacion = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                     oNotificacion = ctx.NotificacionUsuario.SingleOrDefault(n => n.Id == id);
                    if (oNotificacion != null)
                    {
                        oNotificacion.Leida = true;
                        ctx.SaveChanges();
                    }

                }
                return oNotificacion;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }


        public int SaveNotificacionUsuario(NotificacionUsuario notificacionUsuario)
        {

            int retorno = 0;

            using (MyContext ctx = new MyContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                //Registradas: 1,2,3
                //Actualizar: 1,3,4

                //Insertar Libro
                ctx.NotificacionUsuario.Add(notificacionUsuario);
                //SaveChanges
                //guarda todos los cambios realizados en el contexto de la base de datos.
                retorno = ctx.SaveChanges();

            }



            return retorno;

        }
    }
}
