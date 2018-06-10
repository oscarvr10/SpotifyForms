﻿using Autofac;
using SpotifyForms.Core.Services.Navigation;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace SpotifyForms.Core.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }
        
        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }


        /// <summary>
        /// Performs the dependencies registration
        /// </summary>
        /// <param name="useMockServices"><c>true</c> if uses mock services otherwise <c>false</c></param>
        public static void RegisterDependencies(bool useMockServices = false)
        {
            var builder = new ContainerBuilder();

            // View models
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<AlbumDetailViewModel>();

            // Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();

            if (useMockServices)
            {
                //builder.RegisterInstance(new CatalogMockService()).As<ICatalogService>();
                UseMockService = true;
            }
            else
            {
                //builder.RegisterType<CatalogService>().As<ICatalogService>().SingleInstance();
                UseMockService = false;
            }

            if (_container != null)
                _container.Dispose();

            _container = builder.Build();
        }

        /// <summary>
        /// Resolves a registered ViewModel from the container
        /// </summary>
        /// <typeparam name="T">The ViewModel Type</typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
                return;

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
                return;

            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
