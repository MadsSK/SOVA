using System.Collections.Generic;
using DomainModel;

namespace DataAccessLayer
{
    public interface IRepository 
    {
        //Post
        Post GetPost(int id);
        IEnumerable<Post> GetPosts(string searchString);

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

        //Annotation
        Annotation GetAnnotation(int id);
        IEnumerable<Annotation> GetAnnotations(string searchString);
    }
}