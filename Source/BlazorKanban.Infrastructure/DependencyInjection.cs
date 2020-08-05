using BlazorKanban.Domain.Contracts.Common;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Infrastructure.Common;
using BlazorKanban.Infrastructure.Stores.Boards;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorKanban.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient(typeof(IFindEntity<>), typeof(TaskBoardStore<>));
            services.AddTransient(typeof(ICreateEntity<>), typeof(TaskBoardStore<>));
            services.AddTransient(typeof(IDeleteEntity<>), typeof(TaskBoardStore<>));
            services.AddTransient(typeof(IUpdateEntity<>), typeof(TaskBoardStore<>));

            services.AddMongoInfrastructure<TaskBoard, TaskList, TaskCard>();

            return services;
        }

        private static IServiceCollection AddMongoInfrastructure<TBoard, TList, TCard>(this IServiceCollection services)
            where TBoard: TaskBoard
            where TList : TaskList
            where TCard : TaskCard
        {
            var dbOptions = new MongoStoreOptions();

            var taskBoardsCollection = MongoStoreUtil.FromConnectionString<TBoard>(dbOptions.ConnectionString, dbOptions.TaskBoardsCollection);
            services.AddSingleton(x => taskBoardsCollection);
            services.AddTransient<IFindEntity<TBoard>>(x => new TaskBoardStore<TBoard>(taskBoardsCollection));

            var taskListsCollection = MongoStoreUtil.FromConnectionString<TList>(dbOptions.ConnectionString, dbOptions.TaskListsCollection);
            services.AddSingleton(x => taskListsCollection);
            //services.AddTransient<IFindEntity<TBoard>>(x => new TaskBoardStore<TBoard>(taskBoardsCollection));

            var taskCardsCollection = MongoStoreUtil.FromConnectionString<TCard>(dbOptions.ConnectionString, dbOptions.TaskCardsCollection);
            services.AddSingleton(x => taskCardsCollection);
            //services.AddTransient<IFindEntity<TBoard>>(x => new TaskBoardStore<TBoard>(taskBoardsCollection));


            return services;
        }
    }
}