﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Toz.Dotnet.Models;

namespace Toz.Dotnet.Core.Interfaces
{
    public interface IAccountManagementService
    {
        string RequestUri { get; set; }
        Task<JwtToken> SignIn(Login login, CancellationToken cancelationToken = default(CancellationToken));
    }
}
