﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooKeeper.Web.Data.Entities
{
    public class SaleDetail
    {
        [Key]
        public int IdSaleDetail { get; set; }

        public Sale Sale { get; set; }
        
        public Book Isbn { get; set; }

    }
}
