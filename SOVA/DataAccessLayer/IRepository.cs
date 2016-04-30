using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DomainModel;

namespace DataAccessLayer
{
    public interface IRepository 
    {
        //All
        //Object FindObject(string _object, int id);

        //Annotation
        Annotation FindAnnotation(int id);
        IEnumerable<Annotation> GetAnnotationsWithPaging(int limit, int offset);
        IEnumerable<Annotation> GetAnnotations(string searchString);
        IEnumerable<Annotation> GetAllAnnotations();
        int GetNumberOfAnnotations();

        void Insert(Annotation annotation);

        bool Update(Annotation annotation);

        bool DeleteAnnotation(int id);

        

        //Answer
        Answer GetAnswer(int id);
        int GetNumberOfAnswers();
        int GetNumberOfAnswersWithQuestionId(int questionId);
        IEnumerable<Answer> GetAnswers(string searchString);
        IEnumerable<Answer> GetAnswersWithPaging(int limit, int offset);
        IEnumerable<Answer> GetAnswersWithPaging(int Id, int limit, int offset);
        IEnumerable<Answer> GetAnswersWithQuestionId(int questionId, int limit, int offset);
        IEnumerable<Answer> GetAnswersWithLinkedPostId(int linkedPostId, int limit, int offset);

        //Comment
        Comment FindComment(int id);
        int GetNumberOfComments();
        int GetNumberOfCommentsWithQuestionId(int questionId);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetComments(string searchString);
        IEnumerable<Comment> GetCommentsWithPaging(int limit, int offset);
        IEnumerable<Comment> GetCommentsWithQuestionId(int questionId, int limit, int offset);

        //Post 
        int GetNumberOfPosts(int postId);

        //Question
        Question GetQuestion(int id);
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> SearchQuestions(string searchString);
        IEnumerable<Question> GetQuestionsWithPaging(int limit, int offset);
        IEnumerable<Question> GetQuestionsWithPaging(int Id, int limit, int offset);
        IEnumerable<Question> SearchQuestionsWithPaging(string searchString, int limit, int offset);
        IEnumerable<Question> GetQuestionsWithLinkPostId(int linkedPostId, int limit, int offset);
        int GetNumberOfQuestions();
        int GetNumberOfQuestionsSearchResults(string searchString);

        //Search
        Search FindSearch(int id);
        IEnumerable<Search> GetSearchsWithPaging(int limit, int offset);
        int GetNumberOfSearchs();

        //Search User
        SearchUser FindSearchUser(int id);

        //Tag
        Tag FindTag(int id);
        IEnumerable<Tag> GetTags(string searchString);
        IEnumerable<Tag> GetTagsWithQuestionId(int questionId, int limit, int offset);
        int GetNumbersOfTagsWithQuestionId(int questionId);

        //User
        User FindUser(int id);
        IEnumerable<User> GetUsers(string searchString);
        IEnumerable<User> SearchUsersWithPaging(string searchString, int limit, int offset);
        int GetNumberOfUsersSearchResults(string searchString);
    }
}