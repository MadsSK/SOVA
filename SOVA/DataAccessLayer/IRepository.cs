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
        Comment GetComment(int id);
        IEnumerable<Comment> GetComments(string searchString);

        //Tag
        Tag GetTag(int id);
        IEnumerable<Tag> GetTags(string searchString);

        //User
        User GetUser(int id);
        IEnumerable<User> GetUsers(string searchString);

        //Search User
        SearchUser GetSearchUser(int id);
        IEnumerable<SearchUser> GetSearchUsers(string searchString);

        //Annotation
        Annotation GetAnnotation(int id);
        IEnumerable<Annotation> GetAnnotations(string searchString);
    }
}