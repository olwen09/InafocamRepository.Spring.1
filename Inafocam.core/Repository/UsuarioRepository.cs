using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
   public class UsuarioRepository : IUsuario
    {
        private readonly inafocam_tracingContext _context;

        // Contructor para cargar el valor de AndamiosDominicanosContext 
        public UsuarioRepository(inafocam_tracingContext context)
        {
            // pasar el valor del objeto AndamiosDominicanosContext al atributo _context
            _context = context;
        }
        public IQueryable<Usuario> Usuarios => _context.Usuarios;

        public IQueryable<Usuario> GetUsuariosActivosByRole(string role)
        {
            return _context.Usuarios.Where(x => x.Role == role && x.Estado);
        }

        public Usuario GetUsuarioById(string id)
        {
            return _context.Usuarios.Find(id);
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
