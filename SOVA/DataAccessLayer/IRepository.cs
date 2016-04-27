using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DomainModel;

namespace DataAccessLayer
{
    public interface IRepository 
    {
        //Annotation
        Annotation FindAnnotation(int id);
        IEnumerable<Annotation> GetAnnotationsWithPaging(int limit, int offset);
        IEnumerable<Annotation> GetAnnotations(string searchString);
        IEnumerable<Annotation> GetAllAnnotations();
        int GetNumberOfAnnotations();

        //Answer
        Answer GetAnswer(int id);
        int GetNumberOfAnswers();
        IEnumerable<Answer> GetAnswers(string searchString);
        IEnumerable<Answer> GetAnswersWithPaging(int limit, int offset);

        //Comment
        Comment FindComment(int id);
        int GetNumberOfComments();
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetComments(string searchString);
        IEnumerable<Comment> GetCommentsWithPaging(int limit, int offset);

        //Question
        Question GetQuestion(int id);
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> SearchQuestions(string searchString);
        IEnumerable<Question> GetQuestionsWithPaging(int limit, int offset);
        IEnumerable<Question> SearchQuestionsWithPaging(string searchString, int limit, int offset);
        int GetNumberOfQuestions();
        int GetNumberOfQuestionsWithSearch(string searchString);

        //Search
        Search FindSearch(int id);
        IEnumerable<Search> GetSearchsWithPaging(int limit, int offset);
        int GetNumberOfSearchs();

        //Search User
        SearchUser FindSearchUser(int id);

        //Tag
        Tag FindTag(int id);
        IEnumerable<Tag> GetTags(string searchString);

        //User
        User FindUser(int id);
        IEnumerable<User> GetUsers(string searchString);
    }
}