﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericApi.Core.BaseModel
{
    public interface IBaseEntity : IBase
    {
        DateTimeOffset? DeletedDate { get; set; }
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset? UpdatedDate { get; set; }
        string CreatedBy { get; set; }
        string DeletedBy { get; set; }
        string UpdatedBy { get; set; }
    }
    public class BaseEntity : Base, IBaseEntity
    {
        public virtual DateTimeOffset? DeletedDate { get; set; }
        public virtual DateTimeOffset CreatedDate { get; set; }
        public virtual DateTimeOffset? UpdatedDate { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string DeletedBy { get; set; }
        public virtual string UpdatedBy { get; set; }
    }
}
