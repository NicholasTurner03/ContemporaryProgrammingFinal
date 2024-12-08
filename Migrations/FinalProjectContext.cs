using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext(DbContextOptions<FinalProjectContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for FavoriteBooks
            modelBuilder.Entity<Book>().HasData(
     new Book { Id = 1, Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling", Pages = 309, PublishedDate = new DateTime(1997, 6, 26) },
     new Book { Id = 2, Title = "The Hobbit", Author = "J.R.R. Tolkien", Pages = 310, PublishedDate = new DateTime(1937, 9, 21) },
     new Book { Id = 3, Title = "1984", Author = "George Orwell", Pages = 328, PublishedDate = new DateTime(1949, 6, 8) },
     new Book { Id = 4, Title = "To Kill a Mockingbird", Author = "Harper Lee", Pages = 281, PublishedDate = new DateTime(1960, 7, 11) },
     new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Pages = 277, PublishedDate = new DateTime(1951, 7, 16) }
 );

            // Seed data for Hobby
            modelBuilder.Entity<Hobby>().HasData(
     new Hobby { Id = 1, Name = "Reading", Description = "Reading books of various genres", HoursPerWeek = 5 },
     new Hobby { Id = 2, Name = "Cycling", Description = "Outdoor cycling for fitness", HoursPerWeek = 3 },
     new Hobby { Id = 3, Name = "Photography", Description = "Taking photos of landscapes and events", HoursPerWeek = 4 },
     new Hobby { Id = 4, Name = "Cooking", Description = "Experimenting with new recipes", HoursPerWeek = 6 },
     new Hobby { Id = 5, Name = "Gaming", Description = "Playing video games for relaxation", HoursPerWeek = 8 }
 );

            // Seed data for TeamMember
            modelBuilder.Entity<TeamMember>().HasData(
     new TeamMember { Id = 1, FullName = "John Doe", Birthdate = new DateTime(1999, 5, 14), CollegeProgram = "Computer Science", YearInProgram = "Sophomore" },
     new TeamMember { Id = 2, FullName = "Jane Smith", Birthdate = new DateTime(2000, 8, 22), CollegeProgram = "Software Engineering", YearInProgram = "Junior" },
     new TeamMember { Id = 3, FullName = "Alice Johnson", Birthdate = new DateTime(1998, 3, 10), CollegeProgram = "Information Technology", YearInProgram = "Senior" },
     new TeamMember { Id = 4, FullName = "Bob Brown", Birthdate = new DateTime(2001, 12, 5), CollegeProgram = "Computer Science", YearInProgram = "Freshman" },
     new TeamMember { Id = 5, FullName = "Eve White", Birthdate = new DateTime(1997, 11, 30), CollegeProgram = "Cybersecurity", YearInProgram = "Senior" }
 );

            // Seed data for FavoriteFood
            modelBuilder.Entity<FavoriteFood>().HasData(
      new FavoriteFood { Id = 1, FoodName = "Pizza", IsVegetarian = false, CuisineType = "Italian" },
      new FavoriteFood { Id = 2, FoodName = "Sushi", IsVegetarian = false, CuisineType = "Japanese" },
      new FavoriteFood { Id = 3, FoodName = "Vegetable Stir Fry", IsVegetarian = true, CuisineType = "Chinese" },
      new FavoriteFood { Id = 4, FoodName = "Pasta", IsVegetarian = true, CuisineType = "Italian" },
      new FavoriteFood { Id = 5, FoodName = "Burger", IsVegetarian = false, CuisineType = "American" }
  );
        }

        // DbSet properties for each model
        public DbSet<Book> Books { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<FavoriteFood> FavoriteFoods { get; set; }
    }
}