using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Interfaces
{
   public interface IUsuario
    {
        /// <summary>
        /// Obtener la lista completa de usuarios
        /// </summary>
        /// <value></value>
        IQueryable<Usuario> Usuarios { get; }

        /// <summary>
        /// Obtener los usuarios activos de un mismo rol
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        IQueryable<Usuario> GetUsuariosActivosByRole(string role);


        /// <summary>
        /// Obtener un usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Usuario GetUsuarioById(string id);
        /// <summary>
        /// Desconexión de la base de datos
        /// </summary>
        /// 
        void Dispose();
    }
}
