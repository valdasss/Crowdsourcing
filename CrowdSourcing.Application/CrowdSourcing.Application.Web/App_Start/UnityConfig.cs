using CommonServiceLocator;
using CrowdSourcing.Contract.Interfaces;
using CrowdSourcing.EntityCore.Context;
using CrowdSourcing.Module.TaskManagment.Services;
using CrowdSourcing.Repository.FileManagment;
using CrowdSourcing.Repository.Interface;
using CrowdSourcing.Repository.SolutionManagment;
using CrowdSourcing.Repository.TaskManagment;
using CrowdSourcing.Repository.UserManagment;
using System;

using Unity;
using Unity.ServiceLocation;

namespace CrowdSourcing.Application.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IDbContext, CrowdSourcingContext>();
            container.RegisterType<ICrowdSourcingContext, CrowdSourcingContext>();
            container.RegisterType<ITaskTypeRepository, TaskTypeRepository>();
            container.RegisterType<ITaskTypeService, TaskTypeService>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IPersonRepository,PersonRepository>();
            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<ITaskService, TaskService>();
            container.RegisterType<IFileTypeRepository, FileTypeRepository>();
            container.RegisterType<IFileTypeService, FileTypeService>();
            container.RegisterType<IFileRepository, FileRepository>();
            container.RegisterType<IFileService, FileService>();         
            container.RegisterType<IDataRepository, DataRepository>();
            container.RegisterType<IDataService, DataService>();
            container.RegisterType<ITaskDataRepository, TaskDataRepository>();
            container.RegisterType<ITaskDataService, TaskDataService>();
            container.RegisterType<IDownloadService, DownloadService>();
            container.RegisterType<ISolutionRepository, SolutionRepository>();
            container.RegisterType<ISolutionService, SolutionService>();



            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));
        }
    }
}