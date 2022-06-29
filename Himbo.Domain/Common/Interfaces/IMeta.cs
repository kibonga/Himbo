using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Common.Interfaces
{
    public interface IMeta
    {
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string Slug { get; set; }
    }
}
