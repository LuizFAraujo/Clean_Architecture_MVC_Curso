//using System;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        //public DateTime CreateDate { get; protected set; }
        //public DateTime ModifiedDate { get; protected set; }
        //public string CreatedBy { get; protected set; }
        //public string ModifiedBy { get; protected set; }
    }
}
