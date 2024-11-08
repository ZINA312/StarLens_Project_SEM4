﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.FilterUseCases.Queries.GetFilterByName
{
    public sealed record GetFilterByNameRequest(string name) : IRequest<IEnumerable<Filter>>
    { }
}
