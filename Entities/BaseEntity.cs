using System;
using System.Collections.Generic;
using System.Text;

namespace discussion_api.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }

        public virtual DateTime? createdAt { get; set; }
        public virtual DateTime? updatedAt { get; set; }
    }
}
