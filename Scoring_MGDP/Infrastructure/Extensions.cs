using AutoMapper;
using PagedList;
using Scoring_MGDP.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.Infrastructure
{
    public static class Extensions
    {
        public static IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this IPagedList<TSource> list)
        {
            IEnumerable<TDestination> sourceList = ModelMappingProfile.Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list.ToList());
            IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
            return pagedResult;
        }
    }
}