using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NumberGambling.Application.Interfaces;
using NumberGambling.Application.Services;
using NumberGambling.Domain.CommandHandlers.GamblingCommandHandler;
using NumberGambling.Domain.CommandHandlers.UserCommandHandler;
using NumberGambling.Domain.Commands.GamblingCommands;
using NumberGambling.Domain.Commands.UserCommands;
using NumberGambling.Domain.Core.Bus;
using NumberGambling.Domain.IRepository;
using NumberGambling.Infra.Bus;
using NumberGambling.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGambling.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyContainer));
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            #region Gambling
            //Application Layer
            services.AddScoped<IGamblingService, GamblingService>();
            //Data Layer
            services.AddScoped<IGamblingRepository, GamblingRepository>();
            //Domain Layer
            services.AddScoped<IRequestHandler<AddGamblingCommand, bool>, AddGamblingCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateGamblingCommand, bool>, UpdateGamblingCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteGamblingCommand, bool>, DeleteGamblingCommandHandler>();
            #endregion

            #region User
            //Application Layer
            services.AddScoped<IUserService, UserService>();
            //Data Layer
            services.AddScoped<IUserRepository, UserRepository>();
            //Domain Layer
            services.AddScoped<IRequestHandler<AddUserCommand, bool>, AddUserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, bool>, UpdateUserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, bool>, DeleteUserCommandHandler>();
            #endregion
        }
    }
}
