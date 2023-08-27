using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InnovexBackend;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace InnovexBackend.Models
{
    [Table("Staff")]
    public class StaffModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string Fullname { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string RoleTitle { get; set; } = "User";

        [Required]
        public bool IsActive { get; set; } = true;

    }


public static class StaffModelEndpoints
{
	public static void MapStaffModelEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/StaffModel").WithTags(nameof(StaffModel));

        group.MapGet("/", async (AppDbContext db) =>
        {
            return await db.Staff.ToListAsync();
        })
        .WithName("GetAllStaffModels")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<StaffModel>, NotFound>> (int id, AppDbContext db) =>
        {
            return await db.Staff.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is StaffModel model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetStaffModelById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, StaffModel staffModel, AppDbContext db) =>
        {
            var affected = await db.Staff
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, staffModel.Id)
                  .SetProperty(m => m.Username, staffModel.Username)
                  .SetProperty(m => m.Password, staffModel.Password)
                  .SetProperty(m => m.Fullname, staffModel.Fullname)
                  .SetProperty(m => m.Email, staffModel.Email)
                  .SetProperty(m => m.RoleTitle, staffModel.RoleTitle)
                  .SetProperty(m => m.IsActive, staffModel.IsActive)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateStaffModel")
        .WithOpenApi();

        group.MapPost("/", async (StaffModel staffModel, AppDbContext db) =>
        {
            db.Staff.Add(staffModel);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/StaffModel/{staffModel.Id}",staffModel);
        })
        .WithName("CreateStaffModel")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, AppDbContext db) =>
        {
            var affected = await db.Staff
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteStaffModel")
        .WithOpenApi();
    }
}}
