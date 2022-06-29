using Himbo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Domain.Common.Interfaces
{
    public interface IImage
    {
        public Image Image { get; set; }
    }

    public interface IImages
    {
        public ICollection<Image> Images { get; set; }
    }
}
