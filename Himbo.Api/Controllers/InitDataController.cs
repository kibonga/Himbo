using Himbo.DataAccess;
using Himbo.Domain;
using Himbo.Domain.Entities;
using Himbo.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Himbo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class InitDataController : ControllerBase
    {
        private readonly HimboDbContext _context;

        public InitDataController(HimboDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult InitData()
        {

            #region UseCases and Groups
            // Start

            #region Legacy
            /* var useCases = new List<UseCase>()
       {
           #region Auth UseCases
           new UseCase()
           {
               Id = 1,
               Name = "Register User (EF)",
               Description = "Use case for registering new User using EF"
           },
           #endregion

           #region Tag UseCases
           new UseCase()
           {
               Id = 2,
               Name = "Create Tag (EF)",
               Description = "Use case for creating new Tag using EF"
           },
           new UseCase()
           {
               Id = 3,
               Name = "Update Tag (EF)",
               Description = "Use case for updating existing Tag using EF"
           },
           new UseCase()
           {
               Id = 4,
               Name = "Delete Tag (EF)",
               Description = "Use case for deleting existing Tag using EF"
           },
           new UseCase()
           {
               Id = 5,
               Name = "Query all Tags (EF)",
               Description = "Use case for querying all Tags using EF"
           },
           new UseCase()
           {
               Id = 6,
               Name = "Query single Tag (EF)",
               Description = "Use case for querying single Tag using EF"
           },
           new UseCase()
           {
               Id = 7,
               Name = "Deactivate Tag (EF)",
               Description = "Use case for deactivating existing Tag using EF"
           },
           new UseCase()
           {
               Id = 8,
               Name = "Activate Tag (EF)",
               Description = "Use case for activating existing Tag using EF"
           },
           #endregion

           #region Category UseCases
           new UseCase()
           {
               Id = 9,
               Name = "Create Category (EF)",
               Description = "Use case for creating new Category using EF"
           },
           new UseCase()
           {
               Id = 10,
               Name = "Update Category (EF)",
               Description = "Use case for updating existing Category using EF"
           },
           new UseCase()
           {
               Id = 11,
               Name = "Deactivate Category (EF)",
               Description = "Use case for deactivating existing Category using EF"
           },
           new UseCase()
           {
               Id = 12,
               Name = "Activate Category (EF)",
               Description = "Use case for activating existing Category using EF"
           },
           new UseCase()
           {
               Id = 13,
               Name = "Query all Categories (EF)",
               Description = "Use case for querying all Categories using EF"
           },
           new UseCase()
           {
               Id = 14,
               Name = "Query single Category (EF)",
               Description = "Use case for querying single Category using EF"
           },
           new UseCase()
           {
               Id = 15,
               Name = "Delete Category (EF)",
               Description = "Use case for deleting existing Category using EF"
           },
           #endregion

           #region Post UseCases
           new UseCase()
           {
               Id = 16,
               Name = "Create Post (EF)",
               Description = "Use case for creating new Post using EF"
           },
           new UseCase()
           {
               Id = 17,
               Name = "Update Post (EF)",
               Description = "Use case for updating existing Post using EF"
           },
           new UseCase()
           {
               Id = 18,
               Name = "Deactivate Category (EF)",
               Description = "Use case for deactivating existing Post using EF"
           },
           new UseCase()
           {
               Id = 19,
               Name = "Activate Post (EF)",
               Description = "Use case for activating existing Post using EF"
           },
           new UseCase()
           {
               Id = 20,
               Name = "Delete Post (EF)",
               Description = "Use case for deleting existing Post using EF"
           },
           new UseCase()
           {
               Id = 21,
               Name = "Query all Posts (EF)",
               Description = "Use case for querying all Posts using EF"
           },
           new UseCase()
           {
               Id = 22,
               Name = "Query single Post (EF)",
               Description = "Use case for querying single Post using EF"
           },
       #endregion

           #region Comment UseCases
           new UseCase()
           {
               Id = 23,
               Name = "Create Comment (EF)",
               Description = "Use case for creating new Comment using EF"
           },
           new UseCase()
           {
               Id = 24,
               Name = "Update Comment (EF)",
               Description = "Use case for updating existing Comment using EF"
           },
           new UseCase()
           {
               Id = 25,
               Name = "Deactivate Comment (EF)",
               Description = "Use case for deactivating existing Comment using EF"
           },
           new UseCase()
           {
               Id = 26,
               Name = "Activate Comment (EF)",
               Description = "Use case for activating existing Comment using EF"
           },
           new UseCase()
           {
               Id = 27,
               Name = "Delete Comment (EF)",
               Description = "Use case for deleting existing Comment using EF"
           },
           new UseCase()
           {
               Id = 28,
               Name = "Query all Comments (EF)",
               Description = "Use case for querying all Comments using EF"
           },
           #endregion

           #region Comment UseCases
           new UseCase()
           {
               Id = 29,
               Name = "Create Post Like (EF)",
               Description = "Use case for creating new Post Like using EF"
           },
           new UseCase()
           {
               Id = 30,
               Name = "Delete Post Like (EF)",
               Description = "Use case for deleting existing Post Like using EF"
           },
           new UseCase()
           {
               Id = 31,
               Name = "Create Comment Like (EF)",
               Description = "Use case for creating new Comment Like using EF"
           },
           new UseCase()
           {
               Id = 32,
               Name = "Delete Comment Like (EF)",
               Description = "Use case for deleting existing Comment Like using EF"
           },
           #endregion

           #region Rating UseCases
           new UseCase()
           {
               Id = 33,
               Name = "Create Post Rating (EF)",
               Description = "Use case for creating new Post Rating using EF"
           },
           new UseCase()
           {
               Id = 34,
               Name = "Update Post Rating (EF)",
               Description = "Use case for updating existing Post Rating using EF"
           },
           #endregion

           #region Group UseCases
           new UseCase()
           {
               Id = 35,
               Name = "Create Group (EF)",
               Description = "Use case for creating new Group using EF"
           },
           new UseCase()
           {
               Id = 36,
               Name = "Add UseCases to Group (EF)",
               Description = "Add UseCases to existing Group using EF"
           },
           new UseCase()
           {
               Id = 37,
               Name = "Remove UseCases from Group (EF)",
               Description = "Remove UseCases from existing Group using EF"
           },
           new UseCase()
           {
               Id = 38,
               Name = "Deactivate Group (EF)",
               Description = "Use case for deactivating existing Group using EF"
           }
           ,new UseCase()
           {
               Id = 39,
               Name = "Activate Group (EF)",
               Description = "Use case for activating existing Group using EF"
           }
           ,new UseCase()
           {
               Id = 40,
               Name = "Query all Groups (EF)",
               Description = "Use case for querying all Groups using EF"
           }
           ,new UseCase()
           {
               Id = 41,
               Name = "Query single Group (EF)",
               Description = "Use case for querying single Group using EF"
           },
           #endregion

           #region UseCase UseCases
           new UseCase()
           {
               Id = 42,
               Name = "Create UseCase (EF)",
               Description = "Use case for creating new UseCase using EF"
           }
           #endregion
       };

       var groups = new List<Group>()
       {
           #region Regular User
           new Group()
           {
               Id = 1,
               Name = "Regular User"
           },
           #endregion

           #region Moderator
           new Group()
           {
               Id = 2,
               Name = "Moderator"
           },
           #endregion

           #region Admin
           new Group()
           {
               Id = 3,
               Name = "Admin"
           }
           #endregion
       };*/
            #endregion

            var groups = _context.Groups.ToList();
            var useCases = _context.UseCases.ToList();

            #region Regular User UseCases
            groups[0].UseCases = new List<UseCase>()
            {
                #region Auth
		        useCases[0], // Register User (EF)
	            #endregion

                #region Tag
		        useCases[4], // Use case for querying all Tags using EF
                useCases[5], // Use case for querying single Tag using EF
	            #endregion

                #region Category
		        useCases[12], // Use case for querying all Categories using EF
                useCases[13], // Use case for querying single Category using EF
	            #endregion

                #region Post
		        useCases[15], // Use case for creating new Category using EF
                useCases[16], // Use case for updating existing Post using EF
                useCases[17], // Use case for deactivating existing Post using EF
                useCases[20], // Use case for querying all Posts using EF
                useCases[21], // Use case for querying single Post using EF
	            #endregion

                #region Comment
                useCases[22], // Use case for creating new Comment using EF
                useCases[23], // Use case for updating existing Comment using EF
                useCases[24], // Use case for deactivating existing Comment using EF
                useCases[27], // Use case for querying all Comments for  single Post using EF
	            #endregion

                #region Like
                useCases[28], // Use case for creating new Post Like using EF
                useCases[29], // Use case for deleting existing Post Like using EF
                useCases[30], // Use case for creating new Comment Like using EF
                useCases[31], // Use case for deleting existing Comment Like using EF
	            #endregion

                #region Rating
                useCases[32], // Use case for creating new Post Rating using EF
                useCases[33], // Use case for updating existing Post Rating using EF
	            #endregion
            };
            #endregion

            #region Moderator UseCases
            groups[1].UseCases = new List<UseCase>()
            {
                #region Auth
		        useCases[0], // Register User (EF)
	            #endregion

                #region Tag
		        useCases[1], // Use case for creating new Tag using EF
                useCases[2], // Use case for updating existing Tag using EF
                useCases[4], // Use case for querying all Tags using EF
                useCases[5], // Use case for querying single Tag using EF
                useCases[6], // Use case for deactivating existing Tag using EF
                useCases[7], // Use case for activating existing Tag using EF
	            #endregion

                #region Category
		        useCases[8], // Use case for creating new Category using EF
                useCases[9], // Use case for updating existing Category using EF
                useCases[10], // Use case for deactivating existing Category using EF
                useCases[11], // Use case for activating existing Category using EF
                useCases[12], // Use case for querying all Categories using EF
                useCases[13], // Use case for querying single Category using EF
	            #endregion

                #region Post
		        useCases[15], // Use case for creating new Post using EF
                useCases[16], // Use case for updating existing Post using EF
                useCases[17], // Use case for deactivating existing Post using EF
                useCases[18], // Use case for activating existing Post using EF
                useCases[20], // Use case for querying all Posts using EF
                useCases[21], // Use case for querying single Post using EF
	            #endregion

                #region Comment
                useCases[22], // Use case for creating new Comment using EF
                useCases[23], // Use case for updating existing Comment using EF
                useCases[24], // Use case for deactivating existing Comment using EF
                useCases[25], // Use case for activating existing Comment using EF
                useCases[27], // Use case for querying all Comments for  single Post using EF
	            #endregion

                #region Like
                useCases[28], // Use case for creating new Post Like using EF
                useCases[29], // Use case for deleting existing Post Like using EF
                useCases[30], // Use case for creating new Comment Like using EF
                useCases[31], // Use case for deleting existing Comment Like using EF
	            #endregion

                #region Rating
                useCases[32], // Use case for creating new Post Rating using EF
                useCases[33], // Use case for updating existing Post Rating using EF
	            #endregion
            };
            #endregion

            #region Admin UseCases
            groups[2].UseCases = new List<UseCase>()
            {
                #region Auth
		        useCases[0], 
	            #endregion

                #region Tag
		        useCases[1],
                useCases[2],
                useCases[3], // Delete
                useCases[4],
                useCases[5],
                useCases[6],
                useCases[7], 
	            #endregion

                #region Category
		        useCases[8],
                useCases[9],
                useCases[10],
                useCases[11],
                useCases[12],
                useCases[13],
                useCases[14], // Delete 
	            #endregion

                #region Post
		        useCases[15],
                useCases[16],
                useCases[17],
                useCases[18],
                useCases[19], // Delete
                useCases[20],
                useCases[21], 
	            #endregion

                #region Comment
                useCases[22],
                useCases[23],
                useCases[24],
                useCases[25],
                useCases[26], // Delete
                useCases[27], 
	            #endregion

                #region Like
                useCases[28],
                useCases[29],
                useCases[30],
                useCases[31],
	            #endregion

                #region Rating
                useCases[32],
                useCases[33],
	            #endregion

                #region Group
                useCases[34],
                useCases[35],
                useCases[36],
                useCases[37],
                useCases[38],
                useCases[39],
                useCases[40],
	            #endregion

                #region UseCase
                useCases[41],
                useCases[42],
                useCases[43],
                useCases[44],
                useCases[45],
                useCases[46],
                useCases[47],
                useCases[48],
                useCases[49],
                useCases[50],
                useCases[51],
	            #endregion
            };
            #endregion


            // End
            #endregion


            #region Users
            var users = new List<User>();
            // Regular User
            users.Add(new User { FirstName = "Pavle", LastName = "Djurdjic", PasswordHash = "$2a$11$ccZm6YIZ5GA7mv/USJTBv.MuwuVsOaWyo9NxLHRBlH.LzpYMgNNs6", Email = "pavle@gmail.com", Group = groups[0] });
            users.Add(new User { FirstName = "Charles", LastName = "Oliviera", PasswordHash = "$2a$11$ccZm6YIZ5GA7mv/USJTBv.MuwuVsOaWyo9NxLHRBlH.LzpYMgNNs6", Email = "charles@gmail.com", Group = groups[0] });
            users.Add(new User { FirstName = "Valentina", LastName = "Schevchenko", PasswordHash = "$2a$11$ccZm6YIZ5GA7mv/USJTBv.MuwuVsOaWyo9NxLHRBlH.LzpYMgNNs6", Email = "valentina@gmail.com", Group = groups[0] });
            users.Add(new User { FirstName = "Chael", LastName = "Sonnen", PasswordHash = "$2a$11$ccZm6YIZ5GA7mv/USJTBv.MuwuVsOaWyo9NxLHRBlH.LzpYMgNNs6", Email = "chael@gmail.com", Group = groups[0] });
            users.Add(new User { FirstName = "Glover", LastName = "Texeira", PasswordHash = "$2a$11$ccZm6YIZ5GA7mv/USJTBv.MuwuVsOaWyo9NxLHRBlH.LzpYMgNNs6", Email = "glover@gmail.com", Group = groups[0] });
            // Moderators
            users.Add(new User { FirstName = "Kimur", LastName = "Kimur", PasswordHash = "$2a$11$ccZm6YIZ5GA7mv/USJTBv.MuwuVsOaWyo9NxLHRBlH.LzpYMgNNs6", Email = "kimur@gmail.com", Group = groups[1] });
            // Admin
            users.Add(new User { FirstName = "Kibonga", LastName = "Kibonga", PasswordHash = "$2a$11$ccZm6YIZ5GA7mv/USJTBv.MuwuVsOaWyo9NxLHRBlH.LzpYMgNNs6", Email = "kibonga@gmail.com", Group = groups[2] });
            #endregion

            #region Categories
            var categories = new List<Category>();
            // Sports

            //0
            categories.Add(new Category { Title = "Sports", MetaTitle = "Meta Sports", MetaDescription = "Meta Sports Description", Slug = "sports-category", });
            //1
            categories.Add(new Category { Title = "Basketball", MetaTitle = "Meta Basketball", MetaDescription = "Meta Basketball Description", Slug = "basketball-category", Parent = categories[0] });
            //2
            categories.Add(new Category { Title = "Nba", MetaTitle = "Meta NBA", MetaDescription = "Meta NBA Description", Slug = "nba-category", Parent = categories[1] });
            //3
            categories.Add(new Category { Title = "Euroleague", MetaTitle = "Meta Euroleague", MetaDescription = "Meta Euroleague Description", Slug = "euroleague-category", Parent = categories[1] });
            //4
            categories.Add(new Category { Title = "ABA", MetaTitle = "Meta ABA", MetaDescription = "Meta ABA Description", Slug = "aba-category", Parent = categories[1] });
            // Music
            //5
            categories.Add(new Category { Title = "Music", MetaTitle = "Meta Music", MetaDescription = "Meta Music Description", Slug = "music-category", });
            //6
            categories.Add(new Category { Title = "Pop", MetaTitle = "Meta Pop music", MetaDescription = "Meta Pop Description", Slug = "pop-category", Parent = categories[4] });
            //7
            categories.Add(new Category { Title = "Rap", MetaTitle = "Meta Rap music", MetaDescription = "Meta Rap Description", Slug = "rap-category", Parent = categories[4] });
            // Science
            //8
            categories.Add(new Category { Title = "Science", MetaTitle = "Meta Science", MetaDescription = "Meta Science Description", Slug = "science-category" });
            //9
            categories.Add(new Category { Title = "Biology", MetaTitle = "Meta Biology", MetaDescription = "Meta Biology Description", Slug = "biology-category", Parent = categories[7] });
            //10
            categories.Add(new Category { Title = "Physics", MetaTitle = "Meta Physics", MetaDescription = "Meta Physics Description", Slug = "physics-category", Parent = categories[7] });
            #endregion

            #region Tags
            var tags = new List<Tag>();
            // Sports tags
            //0
            tags.Add(new Tag { Title = "Sports", MetaTitle = "Sports Meta", MetaDescription = "Sports Meta Description", Slug = "sports-tag" });
            //1
            tags.Add(new Tag { Title = "Baskteball", MetaTitle = "Basketball Meta", MetaDescription = "Basketball Meta Description", Slug = "basketball-tag" });
            //2
            tags.Add(new Tag { Title = "NBA", MetaTitle = "NBA Meta", MetaDescription = "NBA Meta Description", Slug = "nba-tag" });
            //3
            tags.Add(new Tag { Title = "Euroleague", MetaTitle = "Euro Meta", MetaDescription = "Euro Meta Description", Slug = "euroleague-tag" });
            //4
            tags.Add(new Tag { Title = "ABA", MetaTitle = "ABA Meta", MetaDescription = "ABA Meta Description", Slug = "aba-tag" });
            // Music tags
            //5
            tags.Add(new Tag { Title = "Music", MetaTitle = "Music Meta", MetaDescription = "Music Meta Description", Slug = "music-tag" });
            // Science tags
            //6
            tags.Add(new Tag { Title = "Science", MetaTitle = "Science Meta", MetaDescription = "Science Meta Description", Slug = "science-tag" });
            #endregion

            #region Posts
            var posts = new List<Post>();
            // Basketball - NBA - GSW Post
            posts.Add(new Post { 
                Title = "Golden State Takes Game 4", 
                MetaTitle = "Meta GSW win", 
                Summary = "Meta GSW win", 
                MetaDescription = "Meta GSW win Description", 
                Slug = "gsw-win-slug", 
                Content = "Golden State Warriors have won game 4 in NBA Finals against Boston Celtics", 
                Author = users[0], 
                Category = categories[2], 
                Tags = new List<Tag> 
                { 
                    tags[1], 
                    tags[2] 
                } 
                });
            // Basketball - Euroleague - Efes Post
            posts.Add(new Post { 
                Title = "Efes Takes it All", 
                MetaTitle = "Meta Efes winner", 
                Summary = "Meta Efes winner", 
                MetaDescription = "Meta Efes winner Description", 
                Slug = "efes-slug", 
                Content = "Anadolu Efes has won Euroleague second time in a row, and Serbian PG Vasa Micic was named Finals Most Valuable Player", 
                Author = users[1], 
                Category = categories[3], 
                Tags = new List<Tag> 
                { 
                    tags[1], 
                    tags[3] 
                } 
                });
            // Basketball - Euroleague - Efes Post
            posts.Add(new Post { 
                Title = "Red Star Wins the Series", 
                MetaTitle = "Meta Red Star winner", 
                Summary = "Meta Red Star winner", 
                MetaDescription = "Meta Red Star winner Description", 
                Slug = "red-star-slug", 
                Content = "Red Star has beaten their biggest rival Partizan BC in an Epic clash for the ages. The game 5 was indecisive until the very end, after which Red Star came on top.", 
                Author = users[1], 
                Category = categories[4], 
                Tags = new List<Tag> 
                { 
                    tags[1], 
                    tags[4] 
                } 
                });
            // Science - Biology Post
            posts.Add(new Post
            {
                Title = "Lab grown meat",
                MetaTitle = "Meta lab meat",
                Summary = "Meta lab meat",
                MetaDescription = "Meta Lab Grown meat Description",
                Slug = "lab-meat-slug",
                Content = "Lab grown meat is nowadays more and more common thing. Experts suggest that it will completely replace our traditional way of eating in not too distant future.",
                Author = users[2],
                Category = categories[9],
                Tags = new List<Tag>
                {
                    tags[6],
                }
            });
            // Music - Vlatko Stefanovski
            posts.Add(new Post
            {
                Title = "Arlemm Fest",
                MetaTitle = "Meta Arlemm",
                Summary = "Meta Arlemm Fest summary",
                MetaDescription = "Meta Arlemm Fest Description",
                Slug = "arlemm-slug",
                Content = "Arlemm is a Music caravan that takes place in small town of Arilje in Western Serbia. It's idilic atmosphere combined with top performers give this event somewhat epic feel. Last years main attraction our one and only Vlatko Stefanovski.",
                Author = users[4],
                Category = categories[5],
                Tags = new List<Tag>
                {
                    tags[5],
                }
            });
            #endregion

            #region Comments
            var comments = new List<Comment>();
            // Basketball - NBA - GSW Post - Comments
            //0
            comments.Add(new Comment { User = users[0], Post = posts[0], Content = "Steph is the real deal, best PG in the game man!" });
            //1
            comments.Add(new Comment { User = users[2], Post = posts[0], Content = "Bjelica got game, man lowkey stopped Tatum by himself!" });
            //2
            comments.Add(new Comment { User = users[3], Post = posts[0], Content = "Don't forget Klay, he's been a sleep through regular season, but on fire in Playoffs.", Parent = comments[0] });
            //3
            comments.Add(new Comment { User = users[4], Post = posts[0], Content = "Yeah, Beli got game, been an X factor this series", Parent = comments[1] });
            //4
            comments.Add(new Comment { User = users[2], Post = posts[0], Content = "White man can't jump, but for sure he got game!", Parent = comments[3] });
            #endregion

            #region Likes On Post
            posts[0].UsersWhoLiked.Add(users[0]);
            posts[0].UsersWhoLiked.Add(users[1]);
            posts[0].UsersWhoLiked.Add(users[3]);
            posts[0].UsersWhoLiked.Add(users[4]);
            posts[0].UsersWhoLiked.Add(users[5]);
            posts[0].UsersWhoLiked.Add(users[6]);
            #endregion

            #region Likes On Comment
            // First Comment
            comments[0].UsersWhoLiked.Add(users[3]);
            comments[0].UsersWhoLiked.Add(users[4]);
            comments[0].UsersWhoLiked.Add(users[2]);
            // Second Comment
            comments[1].UsersWhoLiked.Add(users[2]); // Own like :D
            comments[1].UsersWhoLiked.Add(users[4]);
            // Third Comment
            comments[2].UsersWhoLiked.Add(users[0]);
            comments[2].UsersWhoLiked.Add(users[0]);
            // Fourth Comment
            comments[3].UsersWhoLiked.Add(users[2]);
            comments[3].UsersWhoLiked.Add(users[1]);
            #endregion

            #region Ratings
            var ratings = new List<Rating>();
            ratings.Add(new Rating()
            {
                User = users[0],
                Post = posts[0],
                NumberOfStars = 5
            });
            ratings.Add(new Rating()
            {
                User = users[1],
                Post = posts[0],
                NumberOfStars = 4
            });
            ratings.Add(new Rating()
            {
                User = users[2],
                Post = posts[0],
                NumberOfStars = 3
            });
            ratings.Add(new Rating()
            {
                User = users[3],
                Post = posts[0],
                NumberOfStars = 4
            });
            ratings.Add(new Rating()
            {
                User = users[4],
                Post = posts[0],
                NumberOfStars = 5
            });
            #endregion

            #region Save
            _context.Categories.AddRange(categories);
            _context.Tags.AddRange(tags);
            _context.Users.AddRange(users);
            _context.Posts.AddRange(posts);
            _context.Comments.AddRange(comments);
            _context.PostsRatings.AddRange(ratings);
            _context.SaveChanges();
            #endregion

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
