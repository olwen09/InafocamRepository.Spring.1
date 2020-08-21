using Inafocam.core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inafocam.core.Interfaces
{
    public interface IComment
    {
        IEnumerable<Comment> GetAll { get; }

        Comment GetById(int commentId);

        IEnumerable<Comment> GetAllByTracingId(int tracingId);
        IEnumerable<Comment> GetAllActiveByTracingId(int tracingId);
        IEnumerable<Comment> GetAllByTracingIdAndUserId(int tracingId , string userId);

        void Save(Comment model);

        public void ChangeStatus(long comentId, long statusId);

    }
}
