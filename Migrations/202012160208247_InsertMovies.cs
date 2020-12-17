namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Kids')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Romance')");

            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) Values ('Shrek', 1, 10-3-2020, 2-4-2002, 4)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) Values ('Lord of the Rings pt. 1', 2, 12-3-2020, 2-4-2009, 8)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) Values ('IT', 4, 7-16-2020, 2-9-1992, 3)");
            Sql("INSERT INTO Movies (Name, GenreId, DateAdded, ReleaseDate, NumberInStock) Values ('Harry Potter and the Chamber of Secrets', 2, 10-3-2020, 2-4-2002, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
