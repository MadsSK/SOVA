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

        /**************************************
            Answer
        **************************************/
        public Answer GetAnswer(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.Answers.FirstOrDefault(a => a.Id == id);
            }
        }

        IEnumerable<Answer> IRepository.GetAnswers(string searchString)
        {
            using (var db = new SovaDBContext())
            {
                return db.Answers
                    .Where(a => a.Body.Contains(searchString))
                    .ToList();
            }
        }


        /**************************************
            Comment
        **************************************/
        public Comment FindComment(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.Comments.FirstOrDefault(c => c.Id == id);
            }
        }

        public IEnumerable<Comment> GetComments()
        {
            using (var db = new SovaDBContext())
            {
                return db.Comments.ToList();
            }
        }

        public IEnumerable<Comment> GetComments(string searchString)
        {
            using (var db = new SovaDBContext())
            {
                return db.Comments
                    .Where(c => c.Body.Contains(searchString))
                    .ToList();
            }
        }

        /**************************************
            Question
        **************************************/
        public IEnumerable<Question> GetAllQuestions()
        {
            using (var db = new SovaDBContext())
            {
                return db.Questions
                    .OrderBy(q => q.Id)
                    .ToList();
            }
        }

        public Question GetQuestion(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.Questions.FirstOrDefault(q => q.Id == id);
            }
        }

        public IEnumerable<Question> SearchQuestions(string searchString)
        {
            using (var db = new SovaDBContext())
            {
                return db.Questions
                    .Where(q => q.Body.Contains(searchString))
                    .ToList();
            }
        }

        public IEnumerable<Question> GetQuestions(int limit, int offset)
        {
            using (var db = new SovaDBContext())
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
            using (var db = new SovaDBContext())
            {
                return db.Questions
                    .Where(q => q.Body.Contains(searchString))
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public int GetNumbersOfQuestions()
        {
            using (var db = new SovaDBContext())
            {
                return db.Questions.Count();
            }
        }

        /**************************************
            Search
        **************************************/
        public Search FindSearch(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.Searchs.FirstOrDefault(s => s.Id == id);
            }
        }


        /**************************************
            SearchUser
        **************************************/
        public SearchUser FindSearchUser(int id)
        {
            using (var db = new SovaDBContext())
            {
                return db.SearchUsers.FirstOrDefault(su => su.Id == id);
            }
        }

        public IEnumerable<SearchUser> GetSearchUsersByMacAdresse(string macAdresse)
        {
            using (var db = new SovaDBContext())
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
        public User FindUser(int id)
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
    }
}