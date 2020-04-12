using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AdvertManager>().As<IAdvertService>();
            builder.RegisterType<EfAdvertDal>().As<IAdvertDal>();


            builder.RegisterType<RealEstateManager>().As<IRealEstateService>();
            builder.RegisterType<EfRealEstateDal>().As<IRealEstateDal>();

            builder.RegisterType<AdvertManager>().As<IAdvertService>();
            builder.RegisterType<EfAdvertDal>().As<IAdvertDal>();

            builder.RegisterType<ProvinceManager>().As<IProvinceService>();
            builder.RegisterType<EfProvinceDal>().As<IProvinceDal>();



            builder.RegisterType<PlaceManager>().As<IPlaceService>();
            builder.RegisterType<EfPlaceDal>().As<IPlaceDal>();

            builder.RegisterType<NeighborhoodManager>().As<INeighborhoodService>();
            builder.RegisterType<EfNeighborhoodDal>().As<INeighborhoodDal>();

            builder.RegisterType<DistrictManager>().As<IDistrictService>();
            builder.RegisterType<EfDistrictDal>().As<IDistrictDal>();

            builder.RegisterType<PlaceManager>().As<IPlaceService>();
            builder.RegisterType<EfPlaceDal>().As<IPlaceDal>();


            builder.RegisterType<AdvertTypeManager>().As<IAdvertTypeService>();
            builder.RegisterType<EfAdvertTypeDal>().As<IAdvertTypeDal>();

            builder.RegisterType<HeatingManager>().As<IHeatingService>();
            builder.RegisterType<EfHeatingDal>().As<IHeatingDal>();


            builder.RegisterType<AdminManager>().As<IAdminService>();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
       
        }
    }
}
