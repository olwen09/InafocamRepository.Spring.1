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

        void Save(Comment model);

    }
}
