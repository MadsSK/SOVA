using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DomainModel;

namespace DataAccessLayer
{
    public interface IRepository 
    {
        // Annotation
        bool IsPostAQuestion(int? postId);
        Annotation FindAnnotation(int id);
        int GetNumberOfAnnotations();
        int GetNumberOfAnnotationsWithPostIdSearchUserId(int postId, int searchUserId);      
        int GetNumberOfAnnotationsWithCommentIdSearchUserId(int commentId, int searchUserId);
        IEnumerable<Annotation> GetAnnotationsWithPaging(int limit, int offset);
        IEnumerable<Annotation> GetAnnotations(string searchString);
        IEnumerable<Annotation> GetAllAnnotations();
        IEnumerable<Annotation> GetAnnotationsWithPostIdSearchUserId(int postId, int searchUserId, int limit, int offset);
        IEnumerable<Annotation> GetAnnotationsWithCommentIdSearchUserId(int commentId, int searchUserId, int limit, int offset);
        
        // Annotation - CRUD
        void Insert(Annotation annotation);
        bool Update(Annotation annotation);
        bool DeleteAnnotation(int id);
      
        // Answer
        Answer GetAnswer(int id);
        int GetNumberOfAnswers();
        int GetNumberOfAnswersWithQuestionId(int questionId);
        int GetNumberOfCommentsWithAnswerId(int answerId);
        IEnumerable<Comment> GetCommentsWithAnswerId(int answerId, int limit, int offset);
        IEnumerable<Answer> GetAnswers(string searchString);
        IEnumerable<Answer> GetAnswersWithPaging(int limit, int offset);
        IEnumerable<Answer> GetAnswersWithPaging(int Id, int limit, int offset);
        IEnumerable<Answer> GetAnswersWithQuestionId(int questionId, int limit, int offset);
        IEnumerable<Answer> GetAnswersWithLinkedPostId(int linkedPostId, int limit, int offset);

        // Comment
        Comment FindComment(int id);
        int GetNumberOfComments();
        int GetNumberOfCommentsWithQuestionId(int questionId);
        int GetNumberOfCommentsWithQuestionIdAnswerId(int questionId, int answerId);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetComments(string searchString);
        IEnumerable<Comment> GetCommentsWithPaging(int limit, int offset);
        IEnumerable<Comment> GetCommentsWithQuestionId(int questionId, int limit, int offset);
        IEnumerable<Comment> GetCommentsWithQuestionIdAnswerId(int questionId, int answerId, int limit, int offset);

        //Post
        int GetNumberOfPosts(int questionId);

        // Question
        Question GetQuestion(int id);
        int GetNumberOfQuestionsWithTagId(int tagId);
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> SearchQuestions(string searchString);
        IEnumerable<Question> GetQuestionsWithPaging(int limit, int offset);
        IEnumerable<Question> GetQuestionsWithPaging(int Id, int limit, int offset);
        IEnumerable<Question> SearchQuestionsWithPaging(string searchString, int limit, int offset);
        IEnumerable<Question> GetQuestionsWithLinkPostId(int linkedPostId, int limit, int offset);
        IEnumerable<Question> GetQuestionsWithTagId(int tagId, int limit, int offset);
        int GetNumberOfQuestions();
        int GetNumberOfQuestionsSearchResults(string searchString);

        // Search
        Search FindSearch(int id);
        IEnumerable<Search> GetSearchsWithPaging(int limit, int offset);
        int GetNumberOfSearchs();

        // Search User
        int GetNumberOfSearchUsers();
        int GetNumberOfAnnotationsWithSearchUserId(int searchUserId);
        SearchUser FindSearchUser(int id);
        int GetNumberOfFavoritesWithSearchUserId(int searchUserId);
        IEnumerable<SearchUser> GetAllSearchUsers(int limit, int offset);
        IEnumerable<Annotation> GetAnnotationsWithSearchUserId(int searchUserId, int limit, int offset);
        
        // Search User - CRUD
        void Insert(SearchUser searchUser);
        bool Update(SearchUser searchUser);
        bool DeleteSearchUser(int id);
        
        // Tag
        Tag FindTag(int id);
        int GetNumberOfTags();
        int GetNumbersOfTagsWithQuestionId(int questionId);
        IEnumerable<Tag> GetTags(int limit, int offset);
        IEnumerable<Tag> GetTagsWithQuestionId(int questionId, int limit, int offset);
        

        // User
        User FindUser(int id);
        int GetNumbersOfUsers();
        IEnumerable<User> GetUsers(int limit, int offset);
        // User - NOT used
        IEnumerable<User> SearchUsersWithPaging(string searchString, int limit, int offset);
        int GetNumberOfUsersSearchResults(string searchString);


        
    }
}