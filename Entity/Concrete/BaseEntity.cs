﻿using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
