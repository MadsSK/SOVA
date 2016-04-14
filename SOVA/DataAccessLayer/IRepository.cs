using System.Collections.Generic;
using DomainModel;

namespace DataAccessLayer
{
    public interface IRepository 
    {
        //Answer
        Answer GetAnswer(int id);
        IEnumerable<Answer> GetAnswers(string searchString);

        //Question
        Question GetQuestion(int id);
        IEnumerable<Question> GetQuestions(string searchString);

        //Comment
        Comment FindComment(int id);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetComments(string searchString);

        //Tag
        Tag FindTag(int id);
        IEnumerable<Tag> GetTags(string searchString);

        //User
        User FindUser(int id);
        IEnumerable<User> GetUsers(string searchString);

        //Search User
        SearchUser FindSearchUser(int id);

        //Annotation
        Annotation FindAnnotation(int id);
        IEnumerable<Annotation> GetAnnotations(string searchString);
    }
}