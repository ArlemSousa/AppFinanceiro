﻿using System.Security.Claims;
using Fina.Api.Common.Api;
using Fina.Core;
using Fina.Core.Services;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.Api.Endpoints.Categories;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Categories: Get All")
            .WithSummary("Recupera todas as categorias")
            .WithDescription("Recupera todas as categorias")
            .WithOrder(5)
            .Produces<PagedResponse<List<Category>?>>();

    private static async Task<IResult> HandleAsync(
        ICategoryServices services,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllCategororyRequest
        {
            UserId = ApiConfiguration.UserId,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };

        var result = await services.GetAllAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}