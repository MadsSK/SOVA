using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using AutoMapper;
using DomainModel;
using Web.Util;

namespace Web.Models
{
    public static class ModelFactory
    {
        private static readonly IMapper PostMapper;
        private static readonly IMapper CommentMapper;

        static ModelFactory()
        {
            var postCfg = new MapperConfiguration(cfg => cfg.CreateMap<Post, PostModel>());
            PostMapper = postCfg.CreateMapper();

            var commentCfg = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentModel>());
            CommentMapper = commentCfg.CreateMapper();
        }

        public static PostModel Map(Post post, UrlHelper urlHelper)
        {
            if (post == null) return null;

            var postModel = PostMapper.Map<PostModel>(post);
            postModel.Url = urlHelper.Link(Config.PostsRoute, new {post.Id});

            return postModel;
        }

        public static CommentModel Map(Comment comment, UrlHelper urlHelper)
        {
            if (comment == null) return null;

            var commentModel = CommentMapper.Map<CommentModel>(comment);
            commentModel.Url = urlHelper.Link(Config.CommentsRoute, new { comment.Id });

            return commentModel;
        }
    }
}