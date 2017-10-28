namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id,Name) VALUES (1,'Action')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (2,'Adventure')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (3,'Comedy')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (4,'Drama')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (5,'Historical')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (6,'Horror')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (7,'Science-Fiction')");
            Sql("INSERT INTO Genres (Id,Name) VALUES (8,'Westerns')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id = 8");
            Sql("DELETE FROM Genres WHERE Id = 7");
            Sql("DELETE FROM Genres WHERE Id = 6");
            Sql("DELETE FROM Genres WHERE Id = 5");
            Sql("DELETE FROM Genres WHERE Id = 4");
            Sql("DELETE FROM Genres WHERE Id = 3");
            Sql("DELETE FROM Genres WHERE Id = 2");
            Sql("DELETE FROM Genres WHERE Id = 1");
        }
    }
}
