﻿using System.Net.Http;
using System.Threading.Tasks;
using TRMDesktopUI.Models;

namespace TRMDesktopUI.Helpers
{
    public interface IAPIHelper
    {

        Task<AuthenticatedUser> AuthenticateAsync(string userName, string password);
    }
}