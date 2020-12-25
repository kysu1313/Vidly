namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthToViewCustomers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLiscense], [UserPhoneNumber]) VALUES (N'50c2aad3-bdd7-44b9-b7ed-fd8ef84dffd5', N'ksups111@gmail.com', 0, N'AMk2DNNPI4vj7IGvvSOWdqkUW3wAqLthZvfOybLGqpEvvNh38OUhMPxJavcV/i3Hgg==', N'51aca633-300e-4271-9f8a-412cfde65e32', NULL, 0, 0, NULL, 1, 0, N'ksups111@gmail.com', N'', N'')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLiscense], [UserPhoneNumber]) VALUES (N'80e66a13-0431-47c1-938c-5170852e203d', N'admin@vidly.com', 0, N'AKzen0/E6xTWDMaEK5k11whV9pw/6MkH8ERECcUZpNWQ5DqJDBjHhOqpywOEFtl+wQ==', N'da80a46a-be09-400b-baeb-eb3a912d6abe', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com', N'', N'')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLiscense], [UserPhoneNumber]) VALUES (N'ed65b405-eaa3-4b4b-9c83-189fdf9048ed', N'kysu3376@colorado.edu', 0, NULL, N'a7c1a17b-6f58-435c-9135-63cecfa8aef1', NULL, 0, 0, NULL, 1, 0, N'kysu3376@colorado.edu', N'1234567', N'')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f8f57f6b-ff7b-421e-8f7d-9b200fbed9ea', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'80e66a13-0431-47c1-938c-5170852e203d', N'f8f57f6b-ff7b-421e-8f7d-9b200fbed9ea')

");
        }
        
        public override void Down()
        {
        }
    }
}
