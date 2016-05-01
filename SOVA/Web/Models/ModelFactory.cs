using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Routing;
using AutoMapper;
using DomainModel;
using Web.Util;

namespace Web.Models
{
    public static class ModelFactory
    {
        private static readonly IMapper AnnotationMapper;
        private static readonly IMapper AnswerMapper;
        private static readonly IMapper CommentMapper;
        private static readonly IMapper QuestionMapper;
        private static readonly IMapper SearchMapper;
        private static readonly IMapper SearchUserMapper;
        private static readonly IMapper TagMapper;
        private static readonly IMapper UserMapper;
        
        static ModelFactory()
        {
            var annotationCfg = new MapperConfiguration(cfg => cfg.CreateMap<Annotation, AnnotationModel>());
            AnnotationMapper = annotationCfg.CreateMapper();

            var answerCfg = new MapperConfiguration(cfg => cfg.CreateMap<Answer, AnswerModel>());
            AnswerMapper = answerCfg.CreateMapper();
            
            var commentCfg = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentModel>());
            CommentMapper = commentCfg.CreateMapper();

            var questionCfg = new MapperConfiguration(cfg => cfg.CreateMap<Question, QuestionModel>());
            QuestionMapper = questionCfg.CreateMapper();

            var searchCfg = new MapperConfiguration(cfg => cfg.CreateMap<Search, SearchModel>());
            SearchMapper = searchCfg.CreateMapper();

            var searchUserCfg = new MapperConfiguration(cfg => cfg.CreateMap<SearchUser, SearchUserModel>());
            SearchUserMapper = searchUserCfg.CreateMapper();

            var tagCfg = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagModel>());
            TagMapper = tagCfg.CreateMapper();
            
            var userCfg = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            UserMapper = userCfg.CreateMapper();

        }

        public static AnnotationModel Map(Annotation annotation, bool question, UrlHelper urlHelper)
        {
            if (annotation == null) return null;

            var annotationModel = AnnotationMapper.Map<AnnotationModel>(annotation);
            annotationModel.Url = urlHelper.Link(Config.AnnotationsRoute, new {annotation.Id});
            if (question && annotation.PostId != null)
            {
                annotationModel.QuestionUri = urlHelper.Link(Config.QuestionsRoute, new { Id = annotation.PostId });
                annotationModel.AnswerUri = null;
            }
            else if (!question && annotation.PostId != null)
            {
                annotationModel.QuestionUri = null;
                annotationModel.AnswerUri = urlHelper.Link(Config.AnswersRoute, new { Id = annotation.PostId });
            }
            if (annotation.CommentId != null)
            {
                annotationModel.CommentUri = urlHelper.Link(Config.CommentsRoute, new {Id = annotation.CommentId});
            }
            annotationModel.SearchUserUri = urlHelper.Link(Config.SearchUsersRoute, new {Id = annotation.SearchUserId});

            return annotationModel;
        }

        public static AnswerModel Map(Answer answer, UrlHelper urlHelper)
        {
            if (answer == null) return null;

            var answerModel = AnswerMapper.Map<AnswerModel>(answer);
            answerModel.Url = urlHelper.Link(Config.AnswersRoute, new { answer.Id });
            answerModel.UserUri = urlHelper.Link(Config.UsersRoute, new { Id = answer.UserId });
            answerModel.QuestionUri = urlHelper.Link(Config.QuestionsRoute, new { Id = answer.QuestionId });
            answerModel.CommentsUri = urlHelper.Link(Config.AnswersCommentsRoute, new {answerId = answer.Id});

            return answerModel;
        }

        public static CommentModel Map(Comment comment, bool question, UrlHelper urlHelper)
        {
            if (comment == null) return null;

            var commentModel = CommentMapper.Map<CommentModel>(comment);
            commentModel.Url = urlHelper.Link(Config.CommentsRoute, new { comment.Id });
            if (question)
            {
                commentModel.QuestionUri = urlHelper.Link(Config.QuestionsRoute, new { Id = comment.PostId });
                commentModel.AnswerUri = null;
            }
            if (!question)
            {
                commentModel.QuestionUri = null;
                commentModel.AnswerUri = urlHelper.Link(Config.AnswersRoute, new { Id = comment.PostId });
            }
            commentModel.UserUri = urlHelper.Link(Config.UsersRoute, new { Id = comment.UserId });

            return commentModel;
        }

        public static QuestionModel Map(Question question, UrlHelper urlHelper)
        {
            if (question == null) return null;

            var questionModel = QuestionMapper.Map<QuestionModel>(question);

            questionModel.Url = urlHelper.Link(Config.QuestionsRoute, new {question.Id});
            questionModel.UserUri = urlHelper.Link(Config.UsersRoute, new { id = question.UserId });
            questionModel.TagsUri = urlHelper.Link(Config.QuestionsTagsRoute, new { questionId = question.Id });
            questionModel.CommentsUri = urlHelper.Link(Config.QuestionsCommentsRoute, new { questionId = question.Id });
            questionModel.LinkedPostsUri = urlHelper.Link(Config.QuestionsLinkedPostsRoute, new { questionId = question.Id });
            questionModel.AnswersUri = urlHelper.Link(Config.QuestionsAnswersRoute, new { questionId = question.Id });
            
            return questionModel;
        }

        public static SearchModel Map(Search search, UrlHelper urlHelper)
        {
            if (search == null) return null;

            var searchModel = SearchMapper.Map<SearchModel>(search);
            searchModel.Url = urlHelper.Link(Config.SearchesRoute, new { search.Id });
            searchModel.SearchUserUri = urlHelper.Link(Config.SearchUsersRoute, new {search.SearchUserId});

            return searchModel;
        }

        public static SearchUserModel Map(SearchUser searchUser, UrlHelper urlHelper)
        {
            if (searchUser == null) return null;

            var searchUserModel = SearchUserMapper.Map<SearchUserModel>(searchUser);
            searchUserModel.Url = urlHelper.Link(Config.SearchUsersRoute, new { searchUser.Id });
            searchUserModel.AnnotationsUri = urlHelper.Link(Config.SearchUsersAnnotationsRoute, new { searchUserId = searchUser.Id });

            return searchUserModel;
        }

        public static TagModel Map(Tag tag, UrlHelper urlHelper)
        {
            if (tag == null) return null;

            var tagModel = TagMapper.Map<TagModel>(tag);
            tagModel.Url = urlHelper.Link(Config.TagsRoute, new { tag.Id });
            tagModel.QuestionsUri = urlHelper.Link(Config.TagsQuestionsRoute, new {tagId = tag.Id});

            return tagModel;
        }

        public static UserModel Map(User user, UrlHelper urlHelper)
        {
            if (user == null) return null;

            var userModel = UserMapper.Map<UserModel>(user);
            userModel.Url = urlHelper.Link(Config.UsersRoute, new { user.Id });

            return userModel;
        }
    }
}