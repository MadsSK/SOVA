using System;

using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Schema;
using DomainModel;
using MySql.Data.MySqlClient;
using MySqlDatabase;

namespace DataAccessLayer
{

    public class MySqlRepository : IRepository
    {
        /**************************************
            Annotation
        **************************************/
        public Annotation FindQuestionAnnotation(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(a => db.Questions.Any(q => q.Id == a.PostId))
                    .FirstOrDefault(a => a.Id == id);
            }
        }

        public Annotation FindAnswerAnnotation(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(an => db.Answers.Any(a => a.Id == an.PostId))
                    .FirstOrDefault(an => an.Id == id);
            }
        }

        public Annotation FindCommentAnnotation(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(a => db.Comments.Any(c => c.Id == id))
                    .FirstOrDefault(a => a.Id == id);
            }
        }

        public int GetNumberOfAnnotationsOnQuestions()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Count(a => db.Questions.Any(an => an.Id == a.PostId));
            }
        }

        public int GetNumberOfAnnotationsWithCommentIdSearchUserId(int commentId, int searchUserId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(a => a.SearchUserId == searchUserId)
                    .Count(a => a.CommentId == commentId);
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
                    .OrderBy(a => a.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Annotation> GetAnnotationsWithCommentIdSearchUserId(int commentId, int searchUserId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(a => a.SearchUserId == searchUserId)
                    .Where(c => c.CommentId == commentId)
                    .OrderBy(c => c.Id)
                    .Skip(offset)
                    .Take(limit)
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

        public bool Update(int id, Annotation annotation)
        {
            using (var db = new StackOverflowDbContext())
            {
                var dbAnnotation = db.Annotations.FirstOrDefault(a => a.Id == id);
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
                    .Count(a => a.QuestionId == questionId);
            }
        }

        public int GetNumberOfCommentsWithAnswerId(int answerId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments
                    .Count(c => c.PostId == answerId);
            }
        }

        public int GetNumberOfAnnotationsWithAnswerIdSearchUserId(int answerId, int searchUserId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations.Where(a => a.SearchUserId == searchUserId).Count(a => a.PostId == answerId);
            }
        }

        public IEnumerable<Comment> GetCommentsWithAnswerId(int answerId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments
                    .Where(c => c.PostId == answerId)
                    .OrderBy(c => c.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
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

        public IEnumerable<Annotation> GetAnnotationsWithAnswerIdSearchUserId(int answerId, int searchUserId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(a => a.SearchUserId == searchUserId)
                    .Where(a => a.PostId == answerId)
                    .OrderBy(a => a.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public Comment FindCommentOnQuestion(int commentId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments
                    .FirstOrDefault(c => c.Id == commentId);
            }
        }

        public Comment FindCommentOnAnswer(int commentId)
        {
            return FindCommentOnQuestion(commentId);
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
                    .OrderBy(c => c.Id)
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

        public int GetNumberOfLinkedPosts(int questionId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Include(q => q.LinkedPosts)
                    .FirstOrDefault(q => q.Id == questionId).LinkedPosts.Count();
            }
        }


        /**************************************
            Question
        **************************************/
        public Question GetQuestion(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .FirstOrDefault(q => q.Id == id);
            }
        }

       public int GetNumberOfQuestionsWithTagId(int tagId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Posts
                    .Count(p => p.Tags.Any(t => t.Id == tagId));
            }
        }

        public int GetNumberOfAnnotationsOnQuestionWithQuestionIdSearchUserId(int questionId, int searchUserId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(a => a.SearchUserId == searchUserId)
                    .Count(a => a.PostId == questionId);
            }
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .OrderBy(q => q.Id)
                    .ToList();
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

        public IEnumerable<Question> GetQuestionsWithTagId(int tagId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Where(p => p.Tags.Any(t => t.Id == tagId))
                    .OrderBy(t => t.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Annotation> GetAnnotationsOnQuestionWithQuestionIdSearchUserId(int questionId, int searchUserId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(a => a.SearchUserId == searchUserId)
                    .Where(a => a.PostId == questionId)
                    .OrderBy(t => t.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<SearchRes> SearchWithPaging(string searchString, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                var s = new MySqlParameter("@s", MySqlDbType.String) { Value = searchString};
                var o = new MySqlParameter("@o", MySqlDbType.Int32) { Value = limit };
                var l = new MySqlParameter("@l", MySqlDbType.Int32) { Value = offset};
                var searchResults = db.Database.SqlQuery<SearchRes>("Call split(@s, @o, @l)", s, o, l);
                var result = searchResults.ToList();
                return result;
            }
        }

        public int GetNumberOfSeachResult(string searchString)
        {
            using (var db = new StackOverflowDbContext())
            {
                var s = new MySqlParameter("@s", MySqlDbType.String) { Value = searchString };
                var result = db.Database.SqlQuery<Int32>("Call splitCount(@s)", s);
                int count = result.FirstOrDefault();
                return count;
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
        public int GetNumberOfSearchUsers()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.SearchUsers.Count();
            }
        }

        public int GetNumberOfAnnotationsWithSearchUserId(int searchUserId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Count(a => a.SearchUserId == searchUserId);
            }
        }

        public SearchUser FindSearchUser(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.SearchUsers.FirstOrDefault(su => su.Id == id);
            }
        }

        public int GetNumberOfSearchsWithSearchUserId(int searchUserId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Searchs.Count(s => s.SearchUserId == searchUserId);
            }
        }

        public int GetNumberOfFavoritesWithSearchUserId(int searchUserId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.SearchUsers
                    .FirstOrDefault(su => su.Id == searchUserId)
                    .Favorites
                    .Count();
            }
        }

        public IEnumerable<SearchUser> GetAllSearchUsers(int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.SearchUsers
                    .OrderBy(su => su.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Annotation> GetAnnotationsWithSearchUserId(int searchUserId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Annotations
                    .Where(a => a.SearchUserId == searchUserId)
                    .OrderBy(a => a.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Search> GetSearchsWithSearchUserId(int searchUserId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Searchs
                    .Where(s => s.SearchUserId == searchUserId)
                    .OrderBy(s => s.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }
        
        public IEnumerable<Question> GetQuestionsWithSearchUserId(int searchUserId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Where(q => q.Favorites.Any(f => f.Id == searchUserId))
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }
        
        public IEnumerable<Answer> GetAnswerssWithSearchUserId(int searchUserId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers
                    .Where(a => db.SearchUsers
                    .Include(su => su.Favorites)
                    .FirstOrDefault(su => su.Id == searchUserId)
                    .Favorites.Any(f => a.Id == f.Id))
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public void Insert(SearchUser searchUser)
        {
            using (var db = new StackOverflowDbContext())
            {
                searchUser.Id = db.SearchUsers.Max(a => a.Id) + 1;
                db.SearchUsers.Add(searchUser);
                db.SaveChanges();
            }
        }

        public bool Update(SearchUser searchUser)
        {
            using (var db = new StackOverflowDbContext())
            {
                var dbSearchUser = db.SearchUsers.FirstOrDefault(a => a.Id == searchUser.Id);
                if (dbSearchUser == null) return false;

                dbSearchUser.MacAdresse = searchUser.MacAdresse;

                db.SaveChanges();
                return true;
            }
        }
        
        public bool DeleteSearchUser(int id)
        {
            using (var db = new StackOverflowDbContext())
            {
                var searchUser = db.SearchUsers.FirstOrDefault(a => a.Id == id);
                if (searchUser == null) return false;

                db.SearchUsers.Remove(searchUser);
                db.SaveChanges();

                return true;
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

        public int GetNumberOfTags()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Tags.Count();
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

        public IEnumerable<Tag> GetTags(int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Tags
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
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

        public int GetNumbersOfUsers()
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Users.Count();
            }
        }

        public int GetNumbersOfAnswersWithUserId(int userId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers
                    .Count(a => a.UserId == userId);
            }
        }

        public int GetNumbersOfQuestionsWithUserId(int userId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Count(q => q.UserId == userId);
            }
        }

        public int GetNumbersOfCommentsWithUserId(int userId)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments
                    .Count(q => q.UserId == userId);
            }
        }

        public IEnumerable<User> GetUsers(int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Users
                    .OrderBy(u => u.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Answer> GetAnswersWithUserId(int userId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Answers
                    .Where(a => a.UserId == userId)
                    .OrderBy(a => a.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Question> GetQuestionsWithUserId(int userId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Questions
                    .Where(q => q.UserId == userId)
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }

        public IEnumerable<Comment> GetCommentsWithUserId(int userId, int limit, int offset)
        {
            using (var db = new StackOverflowDbContext())
            {
                return db.Comments
                    .Where(q => q.UserId == userId)
                    .OrderBy(q => q.Id)
                    .Skip(offset)
                    .Take(limit)
                    .ToList();
            }
        }
    }
}