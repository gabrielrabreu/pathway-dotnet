﻿using Dapper;
using DotNetSearch.Domain.Common;
using DotNetSearch.Domain.Entities;
using DotNetSearch.Domain.Enums;
using DotNetSearch.Domain.Interfaces;
using DotNetSearch.Domain.Models;
using DotNetSearch.Infra.Data.Context;
using DotNetSearch.Infra.Data.DbConnection;
using DotNetSearch.Infra.Data.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetSearch.Infra.Data.Repositories
{
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public AutorRepository(DotNetSearchDbContext dbContext,
                               IDbConnectionFactory dbConnectionFactory) : base(dbContext)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        private string BuildOrderByStatement(SearchSortModel[] searchSortModel, PostgreSqlFilterParser parser)
        {
            var orderBy = new StringBuilder();

            foreach (var sort in searchSortModel)
            {
                orderBy.Append(
                    string.Format("{0} {1} {2}",
                        orderBy.Length > 0 ? "," : "ORDER BY",
                        parser.BuildPropertyPath(sort.PropertyName),
                        sort.Direction.GetDescription()
                    )
                );
            }

            return orderBy.ToString();
        }

        private string BuildPaginationWhereStatement(object lastRow, SearchSortModel[] searchSortModel, PostgreSqlFilterParser parser)
        {
            var jsonObject = JObject.Parse(Convert.ToString(lastRow));
            var jsonProperties = jsonObject.Descendants().Where(property => property is JValue);
            var lastRowFilter = new Dictionary<string, string>();

            foreach (var sort in searchSortModel)
            {
                var value = jsonProperties.FirstOrDefault(property => property.Path == sort.PropertyName);
                if (value != null)
                {
                    var propertyPath = parser.BuildPropertyPath(sort.PropertyName);
                    var propertyValue = $"'{value}'";
                    lastRowFilter.Add(propertyPath, propertyValue);
                }
            }

            var where = new StringBuilder();

            if (lastRowFilter.Count > 0)
            {
                where.Append(
                    string.Format("AND ({0}) {1} ({2})",
                        string.Join(",", lastRowFilter.Keys),
                        searchSortModel.First().Direction == SearchSortDirection.Desc ? "<" : ">",
                        string.Join(",", lastRowFilter.Values)
                    )
                );
            }

            return where.ToString();
        }

        private string BuildWhereFilterStatement(string filter, PostgreSqlFilterParser parser)
        {
            var filterParsed = parser.Parse(filter);
            return new StringBuilder()
                .Append("AND (")
                .Append(filterParsed)
                .Append(")")
                .ToString();
        }

        private string BuildPaginationLimitStatement(int pageSize)
        {
            return string.Format("LIMIT {0}", pageSize);
        }

        public override async Task<IEnumerable<Autor>> DapperSearch(SearchRequestModel searchRequestModel)
        {
            var baseQuery = new StringBuilder()
                .AppendLine("SELECT Autor.* FROM \"Autor\" Autor WHERE 1=1");

            var parser = new PostgreSqlFilterParser("Autor");

            if (searchRequestModel.Sort == null || searchRequestModel.Sort.Length <= 0)
            {
                searchRequestModel.Sort = new SearchSortModel[]
                {
                    new SearchSortModel()
                    {
                        PropertyName = nameof(Autor.Nome).ToLower(),
                        Direction = SearchSortDirection.Asc
                    }
                }.ToArray();
            }

            if (searchRequestModel.LastRow != null)
            {
                var paginationWhereStatement = BuildPaginationWhereStatement(searchRequestModel.LastRow, searchRequestModel.Sort, parser);
                baseQuery.AppendLine(paginationWhereStatement);
            }

            if (!string.IsNullOrEmpty(searchRequestModel.Filter))
            {
                var whereFilterStatement = BuildWhereFilterStatement(searchRequestModel.Filter, parser);
                baseQuery.AppendLine(whereFilterStatement);
            }

            var orderByStatement = BuildOrderByStatement(searchRequestModel.Sort, parser);
            baseQuery.AppendLine(orderByStatement);

            if (searchRequestModel.PageSize > 0)
            {
                var paginationLimitStatement = BuildPaginationLimitStatement(searchRequestModel.PageSize);
                baseQuery.AppendLine(paginationLimitStatement);
            }

            var finalQuery = baseQuery.ToString();

            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<Autor>(finalQuery);
            }
        }

        public override async Task<IEnumerable<Autor>> DapperGetAll()
        {
            var query = "SELECT * FROM \"Autor\"";

            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QueryAsync<Autor>(query);
            }
        }

        public override async Task<Autor> DapperGetById(Guid id)
        {
            var query = $"SELECT * FROM \"Autor\" WHERE \"Id\" = @AutorId";
            var queryParams = new { AutorId = id };

            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Autor>(query, queryParams);
            }
        }
    }
}
