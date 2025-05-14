using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
	{

	}
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<IdentityRole>().HasData(
		new IdentityRole
		{
			Id = "44ddcbe1-9eed-4999-8bd1-62ba82b299d5",
			Name = "Employee",
			NormalizedName = "EMPLOYEE"

		},
		new IdentityRole
		{
			Id = "43609b62-813a-4c0c-be99-f6945346c591",
			Name = "Supervisor",
			NormalizedName = "SUPERVISOR"
		},
		new IdentityRole
		{
			Id = "5d168a9c-5a99-4204-8dbe-07f2447797d0",
			Name = "Administrator",
			NormalizedName = "ADMINISTRATOR"
		});
		var hasher = new PasswordHasher<ApplicationUser>();
		builder.Entity<ApplicationUser>().HasData(new ApplicationUser
		{
			Id = "92da7035-5c36-4e70-80e0-ec40af95f29d",
			Email = "admin@localhost.com",
			NormalizedEmail = "ADMIN@LOCALHOST.COM",
			UserName = "admin@localhost.com",
			NormalizedUserName = "ADMIN@LOCALHOST.COM",
			EmailConfirmed = true,
			PasswordHash = hasher.HashPassword(null, "P@ssword1"),
			FirstName = "Default",
			LastName = "Admin",
			DateOfBirht = new DateOnly(2004, 11, 4)

		});
		builder.Entity<IdentityUserRole<string>>().HasData(
			new IdentityUserRole<string>
			{
				RoleId = "5d168a9c-5a99-4204-8dbe-07f2447797d0",
				UserId = "92da7035-5c36-4e70-80e0-ec40af95f29d"
			});

	}
}
