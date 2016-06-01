namespace Web.Util
{
    public class Config
    {
        public const string AnnotationsRoute = "AnnotationApi";

        // Answers
        public const string AnswersRoute = "AnswerApi";
        public const string AnswersAnnotationsRoute = "AnswerAnnotationApi";
        public const string AnswersCommentsRoute = "AnswerCommentApi";
        
        // Comments
        public const string CommentsRoute = "CommentApi";
        public const string CommentsAnnotationsRoute = "CommentAnnotationApi";

        // Questions
        public const string QuestionsRoute = "QuestionApi";
        public const string QuestionsSearchUserRoute = "QuestionSearchUserApi";
        public const string QuestionsAnnotationsRoute = "QuestionAnnotationApi";
        public const string QuestionsAnswersRoute = "QuestionAnswerApi";
        public const string QuestionsCommentsRoute = "QuestionCommentApi";
        public const string QuestionsLinkedPostsRoute = "QuestionLinkedPostApi";
        public const string QuestionsTagsRoute = "QuestionTagApi";
        public const string QuestionsSearchRoute = "QuestionSeachApi";

        //Search results
        public const string SearchAllRoute = "SearchAllApi";
        public const string SearchQuestionsRoute = "SearchQuestionsApi";
        public const string SearchAnnotationsRoute = "SearchAnnotationApi";
        public const string SearchCommentsRoute = "SearchCommentsApi";
        public const string SearchFavoritesRoute = "SearchFavoritesApi";
        
        // Searches
        public const string SearchesRoute = "SearchApi";

        // Search Users
        public const string SearchUsersRoute = "SearchUserApi";
        public const string SearchUsersAnnotationsRoute = "SearchUserAnnotationApi";
        public const string SearchUsersFavoritesRoute = "SearchUsersFavoritesRoute";
        public const string SearchUsersSearchsRoute = "SearchUserSearchApi";

        // Tags
        public const string TagsRoute = "TagApi";
        public const string TagsQuestionsRoute = "TagQuestionApi";

        // Users
        public const string UsersRoute = "UserApi";
        public const string UsersAnswersRoute = "UserAnswerApi";
        public const string UsersQuestionsRoute = "UserQuestionApi";
        public const string UsersCommentsRoute = "UserCommentApi";

        public const int DefaultPageSize = 10;
        
    }
}