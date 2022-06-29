﻿using Himbo.Application.UseCases.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Application.UseCases.Commands.Rating
{
    public interface IUpdateRatingCommand: ICommand<RatingDto>
    {
    }
}
