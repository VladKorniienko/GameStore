using GameStore.BLL.Games;
using GameStore.BLL.Genres;
using GameStore.DAL.DbContext;
using GameStore.DAL.Interfaces;
using GameStore.DAL.Repositories;
using GameStore.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore
{
    public static class DependenciesManager
    {
        public static IServiceCollection ConfigureDal(this IServiceCollection services)
        {
            var connection = Startup.Configuration.GetConnectionString("GameStoreContext");
            services.AddDbContext<GameStoreContext>(options =>
                options.UseSqlServer(connection));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();


            return services;
        }
        public static IServiceCollection ConfigureBll(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenreService, GenreService>();

            return services;
        }
    }
}
