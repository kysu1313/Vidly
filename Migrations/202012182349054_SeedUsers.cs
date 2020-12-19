namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'50c2aad3-bdd7-44b9-b7ed-fd8ef84dffd5', N'ksups111@gmail.com', 0, N'AMk2DNNPI4vj7IGvvSOWdqkUW3wAqLthZvfOybLGqpEvvNh38OUhMPxJavcV/i3Hgg==', N'51aca633-300e-4271-9f8a-412cfde65e32', NULL, 0, 0, NULL, 1, 0, N'ksups111@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54e0db1c-c8de-4cf3-a961-fa05d12257e5', N'guest@vidly.com', 0, N'AAY6XC9U9sY/JvZUP0J8k4P/6F3nFH0WmRCAFGn5Wfd3RS2HiI1bN9jrw9j9fE0IIA==', N'878e3271-1538-41ef-a47e-0f12735274a3', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'80e66a13-0431-47c1-938c-5170852e203d', N'admin@vidly.com', 0, N'AKzen0/E6xTWDMaEK5k11whV9pw/6MkH8ERECcUZpNWQ5DqJDBjHhOqpywOEFtl+wQ==', N'da80a46a-be09-400b-baeb-eb3a912d6abe', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f8f57f6b-ff7b-421e-8f7d-9b200fbed9ea', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'80e66a13-0431-47c1-938c-5170852e203d', N'f8f57f6b-ff7b-421e-8f7d-9b200fbed9ea')

");
        }
        
        public override void Down()
        {
        }
    }
}
