using System;

using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using MySqlDatabase;

/*
 * Issues right now:
 * - It seems that our data access layer is only used in the domain model test project, not the actual
 *   domain model.
 * - 
 */

namespace DataAccessLayer
{

    /// <summary>
    /// Uses a combination of object models from the domain layer and mapping from the database layer
    /// to define how data should be accessed by methods in the web layer.
    /// </summary>
    public class MySqlRepository : IRepository
    {
        /*************************************
            All - trying to make generic Find method
        *************************************/
        /*
        public Object FindObject(string _object, int id)
        {
            var type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == _object + "s");
            using (var db = new StackOverflowDbContext())
            {
                DbSet thisDbSet = db.Set(type);
                return db.thisDbSet.FirstOrDefault(a => a.Id == id);
            }
        }
        */

        /**************************************
            Annotation
        **************************************/
        public Annotation FindAnnotation(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations.FirstOrDefault(a => a.Id == id);
            }
        }

        public IEnumerable<Annotation> GetAllAnnotations()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .OrderBy(a => a.Id)
                    .ToList();
            }
        }

        public int GetNumberOfAnnotations()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations.Count();
            }
        }

        public void Insert(Annotation annotation)
        {
            using (var db = new StackOverflowDbContext())
            {
                annotation.Id = db.Annotations.Max(a => a.Id) + 1;
                db.Annotations.Add(annotation);
                db.SaveChanges();
            }
        }

        public bool Update(Annotation annotation)
        {
            using (var db = new StackOverflowDbContext())
            {
                var dbAnnotation = db.Annotations.FirstOrDefault(a => a.Id == annotation.Id);
                if (dbAnnotation == null) return false;

                dbAnnotation.Body = annotation.Body;
                dbAnnotation.MarkingStart = annotation.MarkingStart;
                dbAnnotation.MarkingEnd = annotation.MarkingEnd;
                dbAnnotation.PostId = annotation.PostId;
                dbAnnotation.CommentId = annotation.CommentId;
                dbAnnotation.SearchUserId = annotation.SearchUserId;

                db.SaveChanges();
                return true;
            }
        }

        public bool DeleteAnnotation(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                var annotation = db.Annotations.FirstOrDefault(a => a.Id == id);
                if (annotation == null) return false;

                db.Annotations.Remove(annotation);
                db.SaveChanges();

                return true;
            }
        }

        public IEnumerable<Annotation> GetAnnotations(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(a => a.Body.Contains(searchString))
                    .ToList();
            }
        }

        public IEnumerable<Annotation> GetAnnotationsWithPaging(int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        /**************************************
            Answer
        **************************************/
        public Answer GetAnswer(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers.FirstOrDefault(a => a.Id == id);
            }
        }

        public int GetNumberOfAnswers()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers.Count();
            }
        }

        public int GetNumberOfAnswersWithQuestionId(int questionId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers
                    .Count(c => c.QuestionId == questionId);
            }
        }

        public IEnumerable<Answer> GetAnswers(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers
                    .Where(a => a.Body.Contains(searchString))
                    .ToList();
            }
        }

        public IEnumerable<Answer> GetAnswersWithPaging(int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers
                    .OrderBy(p => p.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Answer> GetAnswersWithPaging(int Id, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers
                    .Where(p => p.Id == Id)
                    .OrderBy(p => p.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Answer> GetAnswersWithQuestionId(int questionId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers
                    .Where(c => c.QuestionId == questionId)
                    .OrderBy(c => c.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Answer> GetAnswersWithLinkedPostId(int linkedPostId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers
                    .Where(a => a.LinkedPosts.Any(lp => lp.Id == linkedPostId))
                    .OrderBy(p => p.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }
        /**************************************
            Comment
        **************************************/
        public Comment FindComment(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments.FirstOrDefault(c => c.Id == id);
            }
        }

        public int GetNumberOfComments()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments.Count();
            }
        }

        public int GetNumberOfCommentsWithQuestionId(int questionId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments
                    .Count(c => c.PostId == questionId);
            }
        }

        public IEnumerable<Comment> GetComments()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments.ToList();
            }
        }

        public IEnumerable<Comment> GetComments(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments
                    .Where(c => c.Body.Contains(searchString))
                    .ToList();
            }
        }

        public IEnumerable<Comment> GetCommentsWithPaging(int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Comment> GetCommentsWithQuestionId(int questionId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments
                    .Where(c => c.PostId == questionId)
                    .OrderBy(c => c.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        /**************************************
            Posts
        **************************************/
        public int GetNumberOfPosts(int postId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Posts
                    .Count(p => p.Id == postId);
            }
        }
        

        /**************************************
            Question
        **************************************/
        public IEnumerable<Question> GetAllQuestions()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .OrderBy(q => q.Id)
                    .ToList();
            }
        }

        public Question GetQuestion(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions.
                    Where(q => q.Id == id)
                    .Include(q => q.Tags)
                    .Include(q => q.Comments)
                    .Include(q => q.Annotations)
                    .Include(q => q.User)
                    .Include(q => q.Answers)
                    .Include(q => q.LinkedPosts)
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Question> SearchQuestions(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Where(q => q.Body.Contains(searchString))
                    .Include(q => q.Tags)
                    .ToList();
            }
        }

        public IEnumerable<Question> GetQuestionsWithPaging(int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .OrderBy(q => q.Id)
                    .Include(q => q.Tags)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Question> GetQuestionsWithPaging(int Id, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Where(p => p.Id == Id)
                    .OrderBy(p => p.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Question> SearchQuestionsWithPaging(string searchString, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Where(q => q.Body.Contains(searchString))
                    .OrderBy(q => q.Id)
                    .Include(q => q.Tags)
                    .Include(q => q.Comments)
                    .Include(q => q.Annotations)
                    .Include(q => q.User)
                    .Include(q => q.Answers)
                    .Include(q => q.LinkedPosts)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Question> GetQuestionsWithLinkPostId(int linkedPostId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Where(q => q.LinkedPosts.Any(lp => lp.Id == linkedPostId))
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumberOfQuestions()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions.Count();
            }
        }
        

        public int GetNumberOfQuestionsSearchResults(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Count(q => q.Body.Contains(searchString));
            }
        }
        
        /**************************************
            Search
        **************************************/
        public int GetNumberOfSearchs()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Searchs.Count();
            }
        }

        public Search FindSearch(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Searchs.FirstOrDefault(s => s.Id == id);
            }
        }

        public IEnumerable<Search> GetSearchsWithPaging(int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Searchs
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        /**************************************
            SearchUser
        **************************************/
        public SearchUser FindSearchUser(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.SearchUsers.FirstOrDefault(su => su.Id == id);
            }
        }

        public IEnumerable<SearchUser> GetSearchUsersByMacAdresse(string macAdresse)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.SearchUsers.Where(su => su.MacAdresse == macAdresse)
                    .ToList();
            }
        }

        /**************************************
            Tag
        **************************************/
        public Tag FindTag(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Tags.FirstOrDefault(t => t.Id == id);
            }
        }

        public IEnumerable<Tag> GetTags(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Tags
                    .Where(t => t.Body.Contains(searchString))
                    .ToList();
            }
        }

        public IEnumerable<Tag> GetTagsWithQuestionId(int questionId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Tags
                    .Where(t => t.Posts.Any(p => p.Id == questionId))
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumbersOfTagsWithQuestionId(int questionId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Tags
                    .Count(t => t.Posts.Any(p => p.Id == questionId));
            }
        }

        /**************************************
            User
        **************************************/
        public User FindUser(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Users.FirstOrDefault(u => u.Id == id);
            }
        }

        public IEnumerable<User> GetUsers(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Users
                    .Where(u => u.DisplayName.Contains(searchString))
                    .ToList();
            }
        }

        public IEnumerable<User> SearchUsersWithPaging(string searchString, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Users
                    .Where(q => q.DisplayName.Contains(searchString))
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumberOfUsersSearchResults(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                var result = db.Users
                    .Where(q => q.DisplayName.Contains(searchString));
                return result.Count();
            }
        }
    }
}