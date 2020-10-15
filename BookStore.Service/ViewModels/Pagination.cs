using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace BookStore.Service.ViewModels
{
    public class Pagination<T>
    {
        public List<T> Data { get; private set; }

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public int TotalPages { get; private set; }

        public bool HasPreviousPage => PageIndex > 0;

        public bool HasNextPage => PageIndex + 1 < TotalPages;

        public string FilterColumn { get; set; }

        public string SearchTerm { get; set; }

        private Pagination(
            List<T> data,
            int count,
            int pageIndex,
            int pageSize,
            string filterColumn,
            string filterQuery)
        {
            Data = data;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            FilterColumn = filterColumn;
            SearchTerm = filterQuery;
        }

        public static Pagination<T> Create(
            IList<T> source,
            int pageIndex,
            int pageSize,
            string filterColumns = null,
            string searchTerm = null)
        {
            if (!string.IsNullOrEmpty(filterColumns)
                && !string.IsNullOrEmpty(searchTerm)
                && IsValidProperty(filterColumns))
            {
                var columns = filterColumns.Split(',');

                var filterQuery = string.Empty;
                foreach (var column in columns)
                {
                    filterQuery += $"|| {column}.IndexOf(@0,StringComparison.OrdinalIgnoreCase) >= 0 ";
                }

                source = source.AsQueryable().Where(
                   filterQuery.Substring(3), searchTerm).ToList();
            }

            var count = source.Count();

            var data = source
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList();

            return new Pagination<T>(
                data,
                count,
                pageIndex,
                pageSize,
                filterColumns,
                searchTerm);
        }

        private static bool IsValidProperty(
            string propertyName,
            bool throwExceptionIfNotFound = true)
        {
            var propertyNames = propertyName.Split(',');

            PropertyInfo prop = null;
            foreach (var name in propertyNames)
            {
                prop = typeof(T).GetProperty(
               name,
               BindingFlags.IgnoreCase |
               BindingFlags.Public |
               BindingFlags.Instance);
                if (prop == null && throwExceptionIfNotFound)
                    throw new NotSupportedException(
                        $"ERROR: Property '{name}' does not exist."
                    );
            }

            return prop != null;
        }
    }
}
