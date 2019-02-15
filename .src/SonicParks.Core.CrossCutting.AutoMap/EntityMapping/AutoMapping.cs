using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SonicParks.Core.CrossCutting.AutoMap.EntityMapping {

    public static class AutoMapping {

        public static void Register<TSource, TDestination>() {

            Mapper.Initialize(cfg => cfg.CreateMap<TSource, TDestination>());

        }

        public static TDestination Convert<TSource, TDestination>(TSource source) {

            return Mapper.Map<TSource, TDestination>(source);

        }

    }

}
