﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.Applicationn.TelescopeUseCases.Queries.GetTelescopeById
{
    public sealed record GetTelescopeByIdRequest(int Id) : IRequest<IEnumerable<Telescope>>
    { }
}
