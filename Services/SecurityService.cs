using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VibrantVoluntaire3.Data;
using VibrantVoluntaire3.Models;

namespace VibrantVoluntaire3.Services
{
    public class SecurityService
    {
        SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(UserAcc user)
        {
            return daoService.FindByUser(user);
        }

        public int StoreId(UserAcc user)
        {
            return daoService.FindId(user);
        }

    }
}