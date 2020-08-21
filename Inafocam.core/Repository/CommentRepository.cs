using Inafocam.core.Help;
using Inafocam.core.Interfaces;
using Inafocam.core.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inafocam.core.Repository
{
    public class CommentRepository : IComment
    {

        private inafocam_tracingContext _context;

        public CommentRepository(inafocam_tracingContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetAll => _context.Comment
            .Include(x => x.Usuario)
            .Include(x => x.Status)
            .Include(x => x.ScholarshipProgramTracing);

        public IEnumerable<Comment> GetAllActiveByTracingId(int tracingId)
        {
            return GetAll.Where(x => x.ScholarshipProgramTracingId == tracingId && x.StatusId == StatusValues.Activo);
        }

        public IEnumerable<Comment> GetAllByTracingId(int tracingId)
        {
            return GetAll.Where(x => x.ScholarshipProgramTracingId == tracingId);
        }

        public IEnumerable<Comment> GetAllByTracingIdAndUserId(int tracingId, string userId)
        {

            var prueba = GetAll.Where(x => x.ScholarshipProgramTracingId == tracingId && x.CreatorUserId == userId);
            return GetAll.Where(x => x.ScholarshipProgramTracingId == tracingId && x.CreatorUserId == userId);
        }

        public Comment GetById(int commentId)
        {
           return  GetAll.FirstOrDefault(x => x.CommentId == commentId);
        }

        public void Save(Comment model)
        {

            var now = DateTime.Today;

            if(model.CommentId != 0)
            {
                _context.Comment.Update(model);
            }
            else
            {
                model.CreationDate = now;
                model.StatusId = StatusValues.Pendiente;
                _context.Add(model);
            }

            _context.SaveChanges();
        }

        public void ChangeStatus(long comentId , long statusId)
        {
            

            var data = _context.Comment.Find(comentId);
            data.StatusId = statusId;

            _context.Comment.Update(data);

            _context.SaveChanges();

        }
    }
}
