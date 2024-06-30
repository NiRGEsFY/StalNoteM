using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using StalNoteM.Data.DataItem;
using StalNoteM.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace StalNoteM.Application
{
    public class App
    {
        private readonly UserManager<StalNoteM.Data.Users.User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private IDistributedCache _redis;

        public App(UserManager<StalNoteM.Data.Users.User> userManager, RoleManager<Role> roleManager, SignInManager<User> signInManager, IDistributedCache cache)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _redis = cache;
        }

        public async Task Run()
        {
            BotBuilder builder = new BotBuilder(_userManager, _roleManager, _signInManager, _redis);
            await builder.InitialApp();
            builder.StartBeagling(20000);
        }
    }
}
