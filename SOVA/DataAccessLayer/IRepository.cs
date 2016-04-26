using System.Collections.Generic;
using DomainModel;

namespace DataAccessLayer
{
    public interface IRepository 
    {
        //Annotation
        Annotation FindAnnotation(int id);
        IEnumerable<Annotation> GetAnnotations(string searchString);

        //Answer
        Answer GetAnswer(int id);
        IEnumerable<Answer> GetAnswers(string searchString);

        //Comment
        Comment FindComment(int id);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetComments(string searchString);

        //Question
        Question GetQuestion(int id);
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> SearchQuestions(string searchString);
        IEnumerable<Question> GetQuestions(int limit, int offset);
        IEnumerable<Question> SearchQuestionsWithPaging(string searchString, int limit, int offset);
        int GetNumbersOfQuestions();

        //Search
        Search FindSearch(int id);

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