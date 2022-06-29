using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.DTO.Common
{
    public abstract class MetaDto: TitleDto
    {
        #region IMetaDto
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; } 
        #endregion
    }
    
}
