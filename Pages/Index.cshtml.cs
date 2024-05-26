using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tanwebapp.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public List<Post> Posts { get; set; }

        public void OnGet(string? sortBy = null, string? sortAsc = "true")
        {
            List<Post>? posts = new List<Post>()
            {
                new Post {
                    Title = "ASP.NET Core Overview",
                    Content = "ASP.NET Core is a cross-platform, high-performance framework for building modern, cloud-based, Internet-connected applications.",
                    Author = "John Doe",
                    PostDate = new DateTime(2023, 1, 1)
                },
                new Post {
                    Title = "Understanding Razor Pages",
                    Content = "Razor Pages is a page-based programming model that makes building web UI easier and more productive.",
                    Author = "Jane Smith",
                    PostDate = new DateTime(2023, 2, 15)
                },
                new Post {
                    Title = "Entity Framework Core",
                    Content = "Entity Framework Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations.",
                    Author = "John Doe",
                    PostDate = new DateTime(2023, 3, 10)
                },
                new Post {
                    Title = "Dependency Injection in ASP.NET Core",
                    Content = "ASP.NET Core has built-in support for dependency injection (DI), which is a technique for achieving Inversion of Control (IoC) between classes and their dependencies.",
                    Author = "Emily Davis",
                    PostDate = new DateTime(2023, 4, 5)
                },
                new Post {
                    Title = "Blazor WebAssembly",
                    Content = "Blazor WebAssembly is a single-page app framework for building interactive web apps with .NET. It runs .NET code in the browser via WebAssembly.",
                    Author = "Michael Brown",
                    PostDate = new DateTime(2023, 5, 20)
                },
                new Post {
                    Title = "SignalR for Real-time Web Applications",
                    Content = "ASP.NET Core SignalR is a library for adding real-time web functionality to applications.",
                    Author = "Jane Smith",
                    PostDate = new DateTime(2023, 6, 30)
                },
                new Post {
                    Title = "Authentication and Authorization",
                    Content = "ASP.NET Core provides a flexible set of features for building authentication and authorization into web applications.",
                    Author = "Emily Davis",
                    PostDate = new DateTime(2023, 7, 15)
                },
                new Post {
                    Title = "Introduction to gRPC",
                    Content = "gRPC is a high-performance, open-source universal remote procedure call (RPC) framework that can run in any environment.",
                    Author = "John Doe",
                    PostDate = new DateTime(2023, 8, 25)
                },
                new Post {
                    Title = "Building Microservices with ASP.NET Core",
                    Content = "ASP.NET Core is well-suited for building microservices and container-based applications.",
                    Author = "Michael Brown",
                    PostDate = new DateTime(2023, 9, 10)
                },
                new Post {
                    Title = "Azure DevOps for Continuous Integration",
                    Content = "Azure DevOps provides developer services for support teams to plan work, collaborate on code development, and build and deploy applications.",
                    Author = "Jane Smith",
                    PostDate = new DateTime(2023, 10, 5)
                },
                new Post {
                    Title = "Kubernetes with ASP.NET Core",
                    Content = "Kubernetes is an open-source system for automating deployment, scaling, and management of containerized applications.",
                    Author = "Emily Davis",
                    PostDate = new DateTime(2023, 11, 20)
                },
                new Post {
                    Title = "What's New in C# 10",
                    Content = "C# 10 introduces a number of new language features that simplify common coding patterns.",
                    Author = "John Doe",
                    PostDate = new DateTime(2023, 12, 15)
                },
                new Post {
                    Title = "Exploring MAUI for Cross-platform Development",
                    Content = "MAUI (Multi-platform App UI) is a framework for creating cross-platform applications with a single codebase.",
                    Author = "Michael Brown",
                    PostDate = new DateTime(2024, 1, 5)
                },
                new Post {
                    Title = "Performance Tuning in .NET",
                    Content = "Learn various techniques and best practices for improving the performance of .NET applications.",
                    Author = "Jane Smith",
                    PostDate = new DateTime(2024, 2, 10)
                },
                new Post {
                    Title = "Understanding Middleware in ASP.NET Core",
                    Content = "Middleware are software components that are assembled into an application pipeline to handle requests and responses.",
                    Author = "Emily Davis",
                    PostDate = new DateTime(2024, 3, 25)
                }
            };

            if (sortBy == null || sortAsc == null)
            {
                this.Posts = posts;
                return;
            }

            bool ascending = sortAsc.ToLower() == "true";

            this.Posts = sortBy.ToLower() switch
            {
                "title" => ascending ? posts.OrderBy(p => p.Title).ToList() : posts.OrderByDescending(p => p.Title).ToList(),
                "author" => ascending ? posts.OrderBy(p => p.Author).ToList() : posts.OrderByDescending(p => p.Author).ToList(),
                "postdate" => ascending ? posts.OrderBy(p => p.PostDate).ToList() : posts.OrderByDescending(p => p.PostDate).ToList(),
                _ => posts
            };
        }

        public class Post
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
            public DateTime PostDate { get; set; }
        }
    }
}
