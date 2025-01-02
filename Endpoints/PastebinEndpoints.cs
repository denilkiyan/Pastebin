using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Pastbin.DBContext;
using Pastbin.Interfaces;
using Pastbin.Models;
using System.Globalization;

namespace Pastbin.Endpoints
{
    public static class PastebinEndpoints
    {
        public static void MapRecordEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("pastbin/api", CreateAsync);
            app.MapGet("pastbin/api/{id}",FindRecordAsync);
        }

        public static void MapFrontendEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", async context => context.Response.Redirect("pastbin"));

            app.MapGet("pastbin", async context =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.SendFileAsync("Frontend/MainPage.html");
            });
            app.MapGet("pastbin/{id}", async context => 
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.SendFileAsync("Frontend/TextPage.html");
            });
        }

        public static async Task<IResult> CreateAsync(IRecordService recordService, [FromBody] RecordDTO recordDTO)
        {
            var stringGuid = await recordService.CreateRecord(recordDTO.Text);
            return Results.Ok(new { Message = "Record created", Reference = $"pastbin/{stringGuid}" });
        }

        public static async Task<IResult> FindRecordAsync(IRecordService recordService, string id)
        {
            var rec = await recordService.FindRecordFromId(id);
            if (rec != null)
            {
                return Results.Ok(new { Message = "Operation access", text = rec.Text });
            }
            else return Results.NotFound(new { Message = "Record not found" });
        }
    }
}
