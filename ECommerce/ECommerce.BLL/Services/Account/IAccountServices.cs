using ECommerce.BLL.Dtos.AccountDtos;
using ECommerce.BLL.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.Application
{
    public interface IAccountServices
    {
        Task<GenralResponse> Login(AccountLoginDto LoginDto);
        Task<GenralResponse> Register(AccountRegisterDto registerDto);
    }
}
