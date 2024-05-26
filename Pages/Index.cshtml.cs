using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        [BindProperty]
        public SearchParameters? SearchParams { get; set; }

        public void OnGet(string? keyword = "", string? searchBy = "", string? sortBy = null, string? sortAsc = "true", int pageSize = 5, int pageIndex = 1)
        {
            if (SearchParams == null)
            {
                SearchParams = new SearchParameters()
                {
                    SortBy = sortBy,
                    SortAsc = sortAsc == "true",
                    SearchBy = searchBy,
                    Keyword = keyword,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }

            List<Post> posts = new List<Post>()
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

            if (!string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                if (SearchParams.SearchBy.ToLower() == "title")
                {
                    posts = posts.Where(p => p.Title != null && p.Title.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "author")
                {
                    posts = posts.Where(p => p.Author != null && p.Author.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "content")
                {
                    posts = posts.Where(p => p.Content != null && p.Content.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }
                else if (SearchParams.SearchBy.ToLower() == "postdate")
                {
                    posts = posts.Where(p => p.PostDate.ToString().Contains(SearchParams.Keyword)).ToList();
                }
            }

            else if ((string.IsNullOrEmpty(SearchParams.SearchBy) || SearchParams.SearchBy == "") && !string.IsNullOrEmpty(SearchParams.Keyword))
            {
                posts = posts.Where(a => a.Title != null && a.Title.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
            }

            if (SearchParams.SortBy == null || SearchParams.SortAsc == null)
            {
                this.Posts = posts;
                return;
            }

            if (SearchParams.SortBy.ToLower() == "title" && SearchParams.SortAsc == true)
            {
                this.Posts = posts.OrderBy(p => p.Title).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "title" && SearchParams.SortAsc == false)
            {
                this.Posts = posts.OrderByDescending(p => p.Title).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "author" && SearchParams.SortAsc == true)
            {
                this.Posts = posts.OrderBy(p => p.Author).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "author" && SearchParams.SortAsc == false)
            {
                this.Posts = posts.OrderByDescending(p => p.Author).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "postdate" && SearchParams.SortAsc == true)
            {
                this.Posts = posts.OrderBy(p => p.PostDate).ToList();
            }
            else if (SearchParams.SortBy.ToLower() == "postdate" && SearchParams.SortAsc == false)
            {
                this.Posts = posts.OrderByDescending(p => p.PostDate).ToList();
            }
            else
            {
                this.Posts = posts;
            }
            int totalCount = this.Posts.Count;
            int totalPages = (int)Math.Ceiling((double)totalCount / SearchParams.PageSize);
            int skip = (SearchParams.PageIndex - 1) * SearchParams.PageSize;
            this.Posts = this.Posts.Skip(skip).Take(SearchParams.PageSize).ToList();

            SearchParams.SearchCount = totalCount;
            SearchParams.PageCount = totalPages;
        }

        public class Post
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
            public DateTime PostDate { get; set; }
        }

        public class SearchParameters
        {
            public string? SearchBy { get; set; }
            public string? Keyword { get; set; }
            public string? SortBy { get; set; }
            public bool? SortAsc { get; set; }
            public int PageSize { get; set; }
            public int PageIndex { get; set; }
            public int PageCount { get; set; }
            public int SearchCount { get; set; }
        }
    }
}