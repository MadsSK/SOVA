using System.Collections.Generic;
using DomainModel;

namespace DataAccessLayer
{
    public interface IRepository 
    {
        //Post
        Post FindPost(int id);
        IEnumerable<Post> GetPosts(string searchString);

        //Comment
        Comment FindComment(int id);
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