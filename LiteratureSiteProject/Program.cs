using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// =====================
// Services
// =====================

// MVC
builder.Services.AddControllersWithViews();

// Database Context (InMemory veya SQL Server)
// Geçici olarak InMemory kullanıyoruz - DB bağlantısı olmadan çalışması için
builder.Services.AddDbContext<Context>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (!string.IsNullOrEmpty(connectionString))
    {
        options.UseSqlServer(connectionString);
    }
    else
    {
        // Connection string yoksa InMemory kullan
        options.UseInMemoryDatabase("LiteratureSiteDb");
    }
});

// Identity Configuration
builder.Services.AddIdentity<EntityLayer.Concrete.AppUser, EntityLayer.Concrete.AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddDefaultTokenProviders();

// =====================
// Dependency Injection - Data Access Layer
// =====================
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IBlogDal, EfBlogDal>();
builder.Services.AddScoped<IBookDal, EfBookDal>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();

// =====================
// Dependency Injection - Business Layer
// =====================
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IBlogService, BlogManager>();
builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();

var app = builder.Build();

// =====================
// Seed sample data (for portfolio/demo)
// =====================
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Context>();

    if (!context.Books.Any())
    {
        context.Books.AddRange(
            // Best Sellers
            new Book
            {
                Name = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Genre = "classics",
                Category = "best-sellers",
                Image = "https://images-na.ssl-images-amazon.com/images/I/81af+MCATTL.jpg",
                Description = "A classic novel of the Jazz Age, exploring wealth, love, and the American Dream.",
                Details = "Hardcover · 1925 · 180 pages",
                Editions = "Hardcover, Paperback, eBook, Audio",
                Price = 19.99,
                Rating = 4.7,
                Review = 1523,
                Status = true
            },
            new Book
            {
                Name = "1984",
                Author = "George Orwell",
                Genre = "science-fiction",
                Category = "best-sellers",
                Image = "https://images-na.ssl-images-amazon.com/images/I/71kxa1-0mfL.jpg",
                Description = "A dystopian vision of a totalitarian future, where Big Brother is always watching.",
                Details = "Paperback · 1949 · 328 pages",
                Editions = "Paperback, eBook, Audio",
                Price = 14.50,
                Rating = 4.8,
                Review = 2874,
                Status = true
            },
            new Book
            {
                Name = "Atomic Habits",
                Author = "James Clear",
                Genre = "psychology",
                Category = "best-sellers",
                Image = "https://images-na.ssl-images-amazon.com/images/I/91bYsX41DVL.jpg",
                Description = "An easy and proven way to build good habits and break bad ones.",
                Details = "Hardcover · 2018 · 320 pages",
                Editions = "Hardcover, Paperback, eBook, Audio",
                Price = 16.90,
                Rating = 4.8,
                Review = 4310,
                Status = true
            },
            new Book
            {
                Name = "Thinking, Fast and Slow",
                Author = "Daniel Kahneman",
                Genre = "psychology",
                Category = "best-sellers",
                Image = "https://images-na.ssl-images-amazon.com/images/I/71pJ2G+cS9L.jpg",
                Description = "Nobel laureate Daniel Kahneman explores the two systems that drive the way we think.",
                Details = "Paperback · 2011 · 512 pages",
                Editions = "Paperback, eBook, Audio",
                Price = 18.75,
                Rating = 4.6,
                Review = 2104,
                Status = true
            },

            // New Releases
            new Book
            {
                Name = "The Midnight Library",
                Author = "Matt Haig",
                Genre = "fiction",
                Category = "new-releases",
                Image = "https://images-na.ssl-images-amazon.com/images/I/81eJg5HhI-L.jpg",
                Description = "Between life and death there is a library, and within that library the shelves go on forever.",
                Details = "Hardcover · 2020 · 304 pages",
                Editions = "Hardcover, Paperback, eBook, Audio",
                Price = 21.00,
                Rating = 4.5,
                Review = 942,
                Status = true
            },
            new Book
            {
                Name = "The Silent Patient",
                Author = "Alex Michaelides",
                Genre = "horror",
                Category = "new-releases",
                Image = "https://images-na.ssl-images-amazon.com/images/I/71y7fUviGML.jpg",
                Description = "A shocking psychological thriller of a woman’s act of violence against her husband.",
                Details = "Paperback · 2019 · 336 pages",
                Editions = "Paperback, eBook, Audio",
                Price = 16.40,
                Rating = 4.4,
                Review = 1630,
                Status = true
            },
            new Book
            {
                Name = "Project Hail Mary",
                Author = "Andy Weir",
                Genre = "science-fiction",
                Category = "new-releases",
                Image = "https://images-na.ssl-images-amazon.com/images/I/91vFK9Tlb8S.jpg",
                Description = "A lone astronaut must save the earth from disaster in this gripping sci‑fi adventure.",
                Details = "Hardcover · 2021 · 496 pages",
                Editions = "Hardcover, Paperback, eBook, Audio",
                Price = 22.50,
                Rating = 4.7,
                Review = 1890,
                Status = true
            },

            // Genres (used in Best Collections - Genres slider)
            new Book
            {
                Name = "The Name of the Wind",
                Author = "Patrick Rothfuss",
                Genre = "fantasy",
                Category = "genres",
                Image = "https://images-na.ssl-images-amazon.com/images/I/91b2hY1kz1L.jpg",
                Description = "The tale of the magically gifted young man who grows to be the most notorious wizard his world has ever seen.",
                Details = "Paperback · 2007 · 662 pages",
                Editions = "Paperback, eBook, Audio",
                Price = 17.20,
                Rating = 4.7,
                Review = 1340,
                Status = true
            },
            new Book
            {
                Name = "The Body Keeps the Score",
                Author = "Bessel van der Kolk",
                Genre = "psychology",
                Category = "genres",
                Image = "https://images-na.ssl-images-amazon.com/images/I/81r+LN9BSSL.jpg",
                Description = "A pioneering work on how trauma reshapes the body and brain and how recovery is possible.",
                Details = "Paperback · 2014 · 464 pages",
                Editions = "Paperback, eBook, Audio",
                Price = 18.30,
                Rating = 4.8,
                Review = 2560,
                Status = true
            },
            new Book
            {
                Name = "The Poetry of Pablo Neruda",
                Author = "Pablo Neruda",
                Genre = "poetry",
                Category = "genres",
                Image = "https://images-na.ssl-images-amazon.com/images/I/71i7qDpiKqL.jpg",
                Description = "A definitive collection from one of the most important poets of the 20th century.",
                Details = "Paperback · 2004 · 1024 pages",
                Editions = "Paperback, eBook",
                Price = 24.00,
                Rating = 4.6,
                Review = 740,
                Status = true
            }
        );

        context.SaveChanges();
    }

    if (!context.Blogs.Any())
    {
        context.Blogs.AddRange(
            new Blog
            {
                Name = "10 Classics That Defined the Last Decade",
                Author = "LiteratureSite Editorial",
                Image = "https://images-na.ssl-images-amazon.com/images/I/81iqZ2HHD-L.jpg",
                Description = "From modern masterpieces to rediscovered gems, these ten novels shaped the 2010s.",
                Content = "Longform article about the most influential novels of the decade...",
                Date = "2019",
                Status = true
            },
            new Blog
            {
                Name = "The Rise of Psychological Thrillers",
                Author = "Sarah Collins",
                Image = "https://images-na.ssl-images-amazon.com/images/I/91MqFJ2tRXL.jpg",
                Description = "Why readers can’t stop turning the pages of dark, twisty stories.",
                Content = "Analysis of the boom in psychological suspense and thriller titles...",
                Date = "2020",
                Status = true
            },
            new Blog
            {
                Name = "Sci‑Fi Stories That Predicted Our Future",
                Author = "James Howard",
                Image = "https://images-na.ssl-images-amazon.com/images/I/81h2gWPTYJL.jpg",
                Description = "A look at science‑fiction novels that came eerily close to reality.",
                Content = "From space exploration to artificial intelligence, these books were ahead of their time...",
                Date = "2018",
                Status = true
            },
            new Blog
            {
                Name = "Poetry in the Digital Age",
                Author = "Maya Rivera",
                Image = "https://images-na.ssl-images-amazon.com/images/I/81WcnNQ-TBL.jpg",
                Description = "How social media revived interest in poetry for a new generation.",
                Content = "An exploration of Insta‑poets, online literary magazines, and spoken‑word platforms...",
                Date = "2021",
                Status = true
            }
        );

        context.SaveChanges();
    }
}

// =====================
// Middleware
// =====================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Identity için Authentication ve Authorization middleware'leri
app.UseAuthentication();
app.UseAuthorization();

// =====================
// Routing
// =====================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

// =====================
// Run
// =====================

app.Run();