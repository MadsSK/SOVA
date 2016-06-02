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
        private static readonly IMapper SearchResMapper;

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

            var searchCfg = new MapperConfiguration(cfg => cfg.CreateMap<Search, SearchResModel>());
            SearchMapper = searchCfg.CreateMapper();

            var searchUserCfg = new MapperConfiguration(cfg => cfg.CreateMap<SearchUser, SearchUserModel>());
            SearchUserMapper = searchUserCfg.CreateMapper();

            var tagCfg = new MapperConfiguration(cfg => cfg.CreateMap<Tag, TagModel>());
            TagMapper = tagCfg.CreateMapper();
            
            var userCfg = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());
            UserMapper = userCfg.CreateMapper();

            var searchResCfg = new MapperConfiguration(cfg => cfg.CreateMap<SearchRes, SearchResModel>());
            SearchResMapper = searchResCfg.CreateMapper();

        }

        public static AnnotationModel Map(Annotation annotation, bool question, UrlHelper urlHelper)
        {
            if (annotation == null) return null;

            var annotationModel = AnnotationMapper.Map<AnnotationModel>(annotation);
            annotationModel.Url = urlHelper.Link(Config.AnnotationsRoute, new {annotation.Id});
            if (question && annotation.PostId != null)
            {
                annotationModel.QuestionUrl = urlHelper.Link(Config.QuestionsRoute, new { Id = annotation.PostId });
                annotationModel.AnswerUrl = null;
            }
            else if (!question && annotation.PostId != null)
            {
                annotationModel.QuestionUrl = null;
                annotationModel.AnswerUrl = urlHelper.Link(Config.AnswersRoute, new { Id = annotation.PostId });
            }
            if (annotation.CommentId != null)
            {
                annotationModel.CommentUrl = urlHelper.Link(Config.CommentsRoute, new {Id = annotation.CommentId});
            }
            annotationModel.SearchUserUrl = urlHelper.Link(Config.SearchUsersRoute, new {Id = annotation.SearchUserId});

            return annotationModel;
        }

        public static AnswerModel Map(Answer answer, UrlHelper urlHelper)
        {
            if (answer == null) return null;

            var answerModel = AnswerMapper.Map<AnswerModel>(answer);
            answerModel.Url = urlHelper.Link(Config.AnswersRoute, new { answer.Id });
            answerModel.UserUrl = urlHelper.Link(Config.UsersRoute, new { Id = answer.UserId });
            answerModel.QuestionUrl = urlHelper.Link(Config.QuestionsRoute, new { Id = answer.QuestionId });
            answerModel.CommentsUrl = urlHelper.Link(Config.AnswersCommentsRoute, new {answerId = answer.Id});

            return answerModel;
        }

        public static CommentModel Map(Comment comment, bool question, UrlHelper urlHelper)
        {
            if (comment == null) return null;

            var commentModel = CommentMapper.Map<CommentModel>(comment);
            commentModel.Url = urlHelper.Link(Config.CommentsRoute, new { comment.Id });
            if (question)
            {
                commentModel.QuestionUrl = urlHelper.Link(Config.QuestionsRoute, new { Id = comment.PostId });
                commentModel.AnswerUrl = null;
            }
            if (!question)
            {
                commentModel.QuestionUrl = null;
                commentModel.AnswerUrl = urlHelper.Link(Config.AnswersRoute, new { Id = comment.PostId });
            }
            commentModel.UserUrl = urlHelper.Link(Config.UsersRoute, new { Id = comment.UserId });

            return commentModel;
        }

        public static QuestionModel Map(Question question, UrlHelper urlHelper)
        {
            if (question == null) return null;

            var questionModel = QuestionMapper.Map<QuestionModel>(question);

            questionModel.Url = urlHelper.Link(Config.QuestionsRoute, new {question.Id});
            questionModel.UserUrl = urlHelper.Link(Config.UsersRoute, new { id = question.UserId });
            questionModel.TagsUrl = urlHelper.Link(Config.QuestionsTagsRoute, new { questionId = question.Id });
            questionModel.CommentsUrl = urlHelper.Link(Config.QuestionsCommentsRoute, new { questionId = question.Id });
            questionModel.LinkedPostsUrl = urlHelper.Link(Config.QuestionsLinkedPostsRoute, new { questionId = question.Id });
            questionModel.AnswersUrl = urlHelper.Link(Config.QuestionsAnswersRoute, new { questionId = question.Id });
            
            return questionModel;
        }

        public static SearchModel Map(Search search, UrlHelper urlHelper)
        {
            if (search == null) return null;

            var searchModel = SearchMapper.Map<SearchModel>(search);
            searchModel.Url = urlHelper.Link(Config.SearchesRoute, new { search.Id });
            searchModel.SearchUserUrl = urlHelper.Link(Config.SearchUsersRoute, new {search.SearchUserId});

            return searchModel;
        }

        public static SearchUserModel Map(SearchUser searchUser, UrlHelper urlHelper)
        {
            if (searchUser == null) return null;

            var searchUserModel = SearchUserMapper.Map<SearchUserModel>(searchUser);
            searchUserModel.Url = urlHelper.Link(Config.SearchUsersRoute, new { searchUser.Id });
            searchUserModel.AnnotationsUrl = urlHelper.Link(Config.SearchUsersAnnotationsRoute, new { searchUserId = searchUser.Id });
            searchUserModel.FavoritesUrl = urlHelper.Link(Config.SearchUsersFavoritesRoute,
                new {searchUserId = searchUser.Id});
            searchUserModel.SearchsUrl = urlHelper.Link(Config.SearchUsersSearchsRoute,
                new {searchUserId = searchUser.Id});

            return searchUserModel;
        }

        public static TagModel Map(Tag tag, UrlHelper urlHelper)
        {
            if (tag == null) return null;

            var tagModel = TagMapper.Map<TagModel>(tag);
            tagModel.Url = urlHelper.Link(Config.TagsRoute, new { tag.Id });
            tagModel.QuestionsUrl = urlHelper.Link(Config.TagsQuestionsRoute, new {tagId = tag.Id});
            
            return tagModel;
        }

        public static UserModel Map(User user, UrlHelper urlHelper)
        {
            if (user == null) return null;

            var userModel = UserMapper.Map<UserModel>(user);
            userModel.Url = urlHelper.Link(Config.UsersRoute, new { user.Id });

            return userModel;
        }

        public static SearchResModel Map(SearchRes searchRes, UrlHelper urlHelper)
        {
            if (searchRes == null) return null;

            var searchResModel = SearchResMapper.Map<SearchResModel>(searchRes);
            searchResModel.Url = urlHelper.Link(Config.QuestionsRoute, new { id = searchRes.Id });

            return searchResModel;
        }
    }
}