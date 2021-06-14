using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealSe.API.v1.APIModel
{
    //Page Index Param Api FormModel
    public class PageIndexApiFormModel
    {
        [Required]
        public int PageIndex { get; set; }
    }
}
