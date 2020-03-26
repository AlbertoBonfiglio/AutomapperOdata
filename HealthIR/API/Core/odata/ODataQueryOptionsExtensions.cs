﻿using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapper.AspNet.OData
{
    internal static class ODataQueryOptionsExtensions
    {
        /// <summary>Adds the expand options to the result.</summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="options">The odata options.</param>
        /// <autogeneratedoc />
        public static void AddExpandOptionsResult<TModel>(this ODataQueryOptions<TModel> options)
        {
            if (options.SelectExpand == null)
                return;

            options.Request.ODataFeature().SelectExpandClause = options.SelectExpand.SelectExpandClause;
        }

        /// <summary>Adds the count options to the result.</summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TData">The type of the entity.</typeparam>
        /// <param name="options">The odata options.</param>
        /// <param name="query"></param>
        /// <autogeneratedoc />
        public static void AddCountOptionsResult<TModel, TData>(this ODataQueryOptions<TModel> options, long longCount)
        {
            if (options.Count?.Value != true)
                return;

            options.Request.ODataFeature().TotalCount = longCount;
        }
    }
}
