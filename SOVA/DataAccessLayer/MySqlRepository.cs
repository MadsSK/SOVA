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

        IEnumerable<Answer> IRepository.GetAnswers(string searchString)
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
                return db.Questions.FirstOrDefault(q => q.Id == id);
            }
        }

        public IEnumerable<Question> SearchQuestions(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Where(q => q.Body.Contains(searchString))
                    .ToList();
            }
        }

        public IEnumerable<Question> GetQuestionsWithPaging(int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .OrderBy(q => q.Id)
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
                var result = db.Questions
                    .Where(q => q.Body.Contains(searchString));
                return result.Count();
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
    }
}