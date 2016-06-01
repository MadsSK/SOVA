using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DomainModel;

namespace DataAccessLayer
{
    public interface IRepository 
    {
        // Annotation
        Annotation FindQuestionAnnotation(int id);
        Annotation FindAnswerAnnotation(int id);
        Annotation FindCommentAnnotation(int id);
        int GetNumberOfAnnotations();
        int GetNumberOfAnnotationsWithCommentIdSearchUserId(int commentId, int searchUserId);
        IEnumerable<Annotation> GetAnnotations(string searchString);
        IEnumerable<Annotation> GetAnnotationsWithCommentIdSearchUserId(int commentId, int searchUserId, int limit, int offset);
        IEnumerable<Annotation> GetAnnotationsWithPaging(int limit, int offset);
        
        // Annotation - CRUD
        void Insert(Annotation annotation);
        bool Update(Annotation annotation);
        bool DeleteAnnotation(int id);
      
        // Answer
        Answer GetAnswer(int id);
        int GetNumberOfAnswers();
        int GetNumberOfAnswersWithQuestionId(int questionId);
        int GetNumberOfCommentsWithAnswerId(int answerId);
        int GetNumberOfAnnotationsWithAnswerIdSearchUserId(int answerId, int searchUserId);
        IEnumerable<Comment> GetCommentsWithAnswerId(int answerId, int limit, int offset);
        IEnumerable<Answer> GetAnswers(string searchString);
        IEnumerable<Answer> GetAnswersWithPaging(int limit, int offset);
        IEnumerable<Answer> GetAnswersWithQuestionId(int questionId, int limit, int offset);
        IEnumerable<Answer> GetAnswersWithLinkedPostId(int linkedPostId, int limit, int offset);
        IEnumerable<Annotation> GetAnnotationsWithAnswerIdSearchUserId(int answerId, int searchUserId, int limit, int offset);

        // Comment
        Comment FindComment(int id);
        Comment FindCommentOnQuestion(int commentId);
        Comment FindCommentOnAnswer(int answerId);
        int GetNumberOfComments();
        int GetNumberOfCommentsWithQuestionId(int questionId);
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetComments(string searchString);
        IEnumerable<Comment> GetCommentsWithPaging(int limit, int offset);
        IEnumerable<Comment> GetCommentsWithQuestionId(int questionId, int limit, int offset);
        
        // LinkedPost
        int GetNumberOfLinkedPosts(int questionId);

        // Question
        Question GetQuestion(int id);
        int GetNumberOfQuestions();
        int GetNumberOfQuestionsWithTagId(int tagId);
        int GetNumberOfQuestionsSearchResults(string searchString);
        int GetNumberOfAnnotationsOnQuestionWithQuestionIdSearchUserId(int questionId, int searchUserId);
        IEnumerable<Question> GetAllQuestions();
        IEnumerable<Question> SearchQuestions(string searchString);
        IEnumerable<Question> GetQuestionsWithPaging(int limit, int offset);
        IEnumerable<Question> SearchQuestionsWithPaging(string searchString, int limit, int offset);
        IEnumerable<Question> GetQuestionsWithLinkPostId(int linkedPostId, int limit, int offset);
        IEnumerable<Question> GetQuestionsWithTagId(int tagId, int limit, int offset);
        IEnumerable<Annotation> GetAnnotationsOnQuestionWithQuestionIdSearchUserId(int questionId, int searchUserId, int limit, int offset);

        //Search results
        SearchRes SearchQuestionsRes(string searchString);

        // Search
        Search FindSearch(int id);
        IEnumerable<Search> GetSearchsWithPaging(int limit, int offset);
        int GetNumberOfSearchs();

        // Search User
        int GetNumberOfSearchUsers();
        int GetNumberOfAnnotationsWithSearchUserId(int searchUserId);
        SearchUser FindSearchUser(int id);
        int GetNumberOfSearchsWithSearchUserId(int searchUserId);
        IEnumerable<SearchUser> GetAllSearchUsers(int limit, int offset);
        IEnumerable<Search> GetSearchsWithSearchUserId(int searchUserId, int limit, int offset);
        IEnumerable<Annotation> GetAnnotationsWithSearchUserId(int searchUserId, int limit, int offset);
        IEnumerable<Question> GetQuestionsWithSearchUserId(int searchUserId, int limit, int offset);

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
        int GetNumbersOfAnswersWithUserId(int userId);
        int GetNumbersOfQuestionsWithUserId(int userId);
        int GetNumbersOfCommentsWithUserId(int userId);
        int GetNumberOfFavoritesWithSearchUserId(int searchUserId);
        IEnumerable<User> GetUsers(int limit, int offset);
        IEnumerable<Answer> GetAnswersWithUserId(int userId, int limit, int offset);
        IEnumerable<Question> GetQuestionsWithUserId(int userId, int limit, int offset);
        IEnumerable<Comment> GetCommentsWithUserId(int userId, int limit, int offset);
        
    }
}