using AutoMapper;
using BlazorKanban.Domain.Contracts.TaskBoards;
using BlazorKanban.Domain.Contracts.TaskCards;
using BlazorKanban.Domain.Contracts.TaskLists;
using BlazorKanban.Domain.Objects.Entities;
using BlazorKanban.Infrastructure.Common;
using BlazorKanban.Infrastructure.Stores.Boards;
using BlazorKanban.Infrastructure.Stores.Cards;
using BlazorKanban.Infrastructure.Stores.Lists;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace BlazorKanban.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Action<MongoStoreOptions> setupDatabaseAction)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var dbOptions = new MongoStoreOptions();

            setupDatabaseAction(dbOptions);

            services.AddMongoBoardToInfrastructure<TaskBoard, MongoTaskBoard>(dbOptions);
            services.AddMongoListToInfrastructure<TaskList, MongoTaskList>(dbOptions);
            services.AddMongoCardToInfrastructure<TaskCard, MongoTaskCard>(dbOptions);

            return services;
        }

        private static IServiceCollection AddMongoBoardToInfrastructure<TBoard, TMongoBoard>(
            this IServiceCollection services,
            MongoStoreOptions mongoStoreOptions)
            where TBoard : TaskBoard
            where TMongoBoard : MongoTaskBoard
        {
            var taskBoardsCollection = MongoStoreUtil.FromConnectionString<TMongoBoard>(mongoStoreOptions.ConnectionString, mongoStoreOptions.TaskBoardsCollection);
            services.AddSingleton(x => taskBoardsCollection);

            services.AddTransient(typeof(ICreateTaskBoardEntity<TBoard>), typeof(TaskBoardStore<TBoard, TMongoBoard>));
            services.AddTransient(typeof(IUpdateTaskBoardEntity<TBoard>), typeof(TaskBoardStore<TBoard, TMongoBoard>));
            services.AddTransient(typeof(IDeleteTaskBoardEntity<TBoard>), typeof(TaskBoardStore<TBoard, TMongoBoard>));
            services.AddTransient(typeof(IGetTaskBoardEntity<TBoard>), typeof(TaskBoardStore<TBoard, TMongoBoard>));

            return services;
        }

        private static IServiceCollection AddMongoListToInfrastructure<TList, TMongoList>(
            this IServiceCollection services,
            MongoStoreOptions mongoStoreOptions)
            where TList : TaskList
            where TMongoList : MongoTaskList
        {
            var taskListsCollection = MongoStoreUtil.FromConnectionString<TMongoList>(mongoStoreOptions.ConnectionString, mongoStoreOptions.TaskListsCollection);
            services.AddSingleton(x => taskListsCollection);

            services.AddTransient(typeof(ICreateTaskListEntity<TList>), typeof(TaskListStore<TList, TMongoList>));
            services.AddTransient(typeof(IUpdateTaskListEntity<TList>), typeof(TaskListStore<TList, TMongoList>));
            services.AddTransient(typeof(IDeleteTaskListEntity<TList>), typeof(TaskListStore<TList, TMongoList>));
            services.AddTransient(typeof(IGetTaskListEntity<TList>), typeof(TaskListStore<TList, TMongoList>));

            return services;
        }

        private static IServiceCollection AddMongoCardToInfrastructure<TCard, TMongoCard>(
            this IServiceCollection services,
            MongoStoreOptions mongoStoreOptions)
            where TCard : TaskCard
            where TMongoCard : MongoTaskCard
        {
            var taskCardsCollection = MongoStoreUtil.FromConnectionString<TMongoCard>(mongoStoreOptions.ConnectionString, mongoStoreOptions.TaskCardsCollection);
            services.AddSingleton(x => taskCardsCollection);

            services.AddTransient(typeof(ICreateTaskCardEntity<TCard>), typeof(TaskCardStore<TCard, TMongoCard>));
            services.AddTransient(typeof(IUpdateTaskCardEntity<TCard>), typeof(TaskCardStore<TCard, TMongoCard>));
            services.AddTransient(typeof(IDeleteTaskCardEntity<TCard>), typeof(TaskCardStore<TCard, TMongoCard>));
            services.AddTransient(typeof(IGetTaskCardEntity<TCard>), typeof(TaskCardStore<TCard, TMongoCard>));

            return services;
        }
    }
}