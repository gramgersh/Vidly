namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateInitialRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'a4d52949-a706-4933-bb7b-356cea878c8a', N'root@scottywotty.net', 0, N'AOeJvynQNifWiwzoS4c+38RdUB2wkqzi4FLRIKfZ2tF2Wa3qeZKP4lxTI3bT8cZHkA==', N'cd42c4fb-d478-4f7a-aec3-b42107a97035', NULL, 0, 0, NULL, 1, 0, N'root@scottywotty.net')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'e226575f-8059-4b47-b162-107357c93de7', N'guest@scottywotty.net', 0, N'AOA3Cr1zjoc3kyBJmrx98Np07U7R0uospfmksnqoROds8ToVYdEICSoBwfymW9rggQ==', N'017d8c6e-b6d1-4433-8330-1581104aeb4a', NULL, 0, 0, NULL, 1, 0, N'guest@scottywotty.net')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bfb167aa-a905-4786-966a-bcc75c55028f', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a4d52949-a706-4933-bb7b-356cea878c8a', N'bfb167aa-a905-4786-966a-bcc75c55028f')
");
        }

        public override void Down()
        {
            Sql(@"
DELETE FROM [dbo].[AspNetUserRoles] WHERE [UserId] = N'a4d52949-a706-4933-bb7b-356cea878c8a'
DELETE FROM [dbo].[AspNetUserRoles] WHERE [UserId] = N'e226575f-8059-4b47-b162-107357c93de7'
DELETE FROM [dbo].[AspNetRoles] WHERE [Id] = N'bfb167aa-a905-4786-966a-bcc75c55028f'
DELETE FROM [dbo].[AspNetUsers] WHERE [Id] = N'a4d52949-a706-4933-bb7b-356cea878c8a'
");
        }
    }
}
