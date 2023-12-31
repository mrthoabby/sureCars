﻿using Infrastructure.Helpers;
using sureApp.Infrastructure;

namespace Infrastructure.Interfaces
{
    internal interface IPreInicializatorCommand
    {
        public Task PreInitializator(ApplicationDbContext context, CreateAutoincrementalEntitys counter);
    }
}
