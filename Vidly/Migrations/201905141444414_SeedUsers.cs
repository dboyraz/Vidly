namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9633b4bc-4d1a-4f71-a64d-e01b1f664344', N'guest@vidly.com', 0, N'AKDSjoqf7kPquWFUhUFPle1sC6k2AHX57Kgh8fFm3f9lJaLN9o895vZAb7SFEUeHEw==', N'eee91e75-0d65-4f32-a5e5-7370e6bdd364', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd744b8ae-b14e-4e7d-adc2-2ac0a7680b51', N'admin@vidly.com', 0, N'ADA6f/bzG5W8kdbXbU5euNEHPy5y0snLuHOHbbHBz+JqVP8x5kwRO59CuZHucZhd6g==', N'ca20483a-b5d1-4629-9803-5937a129c826', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0e0257db-d098-447b-8045-fdcc0d776cdd', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd744b8ae-b14e-4e7d-adc2-2ac0a7680b51', N'0e0257db-d098-447b-8045-fdcc0d776cdd')
");
        }

        public override void Down()
        {
        }
    }
}
