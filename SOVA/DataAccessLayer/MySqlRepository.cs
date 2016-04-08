using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using MySqlDatabase;

namespace DataAccessLayer
{
    public class MySqlRepository : IRepository
    {
        /**************************************
            Post
        **************************************/
        public Post GetPost(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.Posts.FirstOrDefault(p => p.Id == id);
            }
        }

        public IEnumerable<Post> GetPosts(string searchString)
        {
            using (var db = new SovaDBContext())
            {
                return db.Posts
                    .Where(p => p.Body.Contains(searchString))
                    .ToList();
            }
        }

        /**************************************
            Comment
        **************************************/
        public Comment GetComment(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.Comments.FirstOrDefault(c => c.Id == id);
            }
        }

        public IEnumerable<Comment> GetComments(string searchString)
        {
            using (var db = new SovaDBContext())
            {
                return db.Comments
                    .Where(c => c.Text.Contains(searchString))
                    .ToList();
            }
        }

        /**************************************
            Tag
        **************************************/
        public Tag GetTag(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.Tags.FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<Tag> GetTags(string searchString)
        {
            using (var db = new SovaDBContext())
            {
                return db.Tags
                    .Where(t => t.Body.Contains(searchString))
                    .ToList();
            }
        }

        /**************************************
            User
        **************************************/
        public User GetUser(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public IEnumerable<User> GetUsers(string searchString)
        {
            using (var db = new SovaDBContext())
            {
                return db.Users
                    .Where(u => u.DisplayName.Contains(searchString))
                    .ToList();
            }
        }

        /**************************************
            SearchUser
        **************************************/
        public SearchUser GetSearchUser(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.SearchUsers.FirstOrDefault(su => su.Id == id);
            }
        }

        public IEnumerable<SearchUser> GetSearchUsers(string searchString)
        {
            using (var db = new SovaDBContext())
            {
                return db.SearchUsers
                    .Where(su => su.Id)
                    .ToList();
            }
        }

        /**************************************
            Annotation
        **************************************/
        public Annotation GetAnnotation(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.Annotations.FirstOrDefault(a => a.Id == id);
            }
        }

        public IEnumerable<Annotation> GetAnnotations(string searchString)
        {
            using (var db = new SovaDBContext())
            {
                return db.Annotations
                    .Where(a => a.Body.Contains(searchString))
                    .ToList();
            }
        }
    }
}