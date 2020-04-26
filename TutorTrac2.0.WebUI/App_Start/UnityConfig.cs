using System;
using TutorTrac2.core.Contracts;
using TutorTrac2.core.Models;
using TutorTrac2.DataAccess.InMemory;
using TutorTrac2.DataAccess.SQL;
using Unity;

namespace TutorTrac2._0.WebUI
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
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IRepository<ClassGrouping>, SQLRepository<ClassGrouping>>();
            container.RegisterType<IRepository<StudentAppointment>, SQLRepository<StudentAppointment>>();
            container.RegisterType<IRepository<StudentSchedule>, SQLRepository<StudentSchedule>>();
            container.RegisterType<IRepository<TutorAppointment>, SQLRepository<TutorAppointment>>();
            container.RegisterType<IRepository<Tutors>, SQLRepository<Tutors>>();
            container.RegisterType<IRepository<TutorSchedule>, SQLRepository<TutorSchedule>>();
            container.RegisterType<IRepository<Students>, SQLRepository<Students>>();
        }
    }
}