﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace BlogEngine.XmlRpcContracts
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Enclosure
    {
        public int length;
        public string type;
        public string url;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Source
    {
        public string name;
        public string url;
    }

    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Post
    {
        [XmlRpcMissingMapping(MappingAction.Error)]
        [XmlRpcMember(Description = "Required when posting.")]
        public DateTime dateCreated;
        [XmlRpcMissingMapping(MappingAction.Error)]
        [XmlRpcMember(Description = "Required when posting.")]
        public string description;
        [XmlRpcMissingMapping(MappingAction.Error)]
        [XmlRpcMember(Description = "Required when posting.")]
        public string title;

        public string[] categories;
        public Enclosure enclosure;
        public string link;
        public string permalink;

        public int postid;
        public Source source;
        public string userid;

        public string mt_excerpt;
    }

    public struct CategoryInfo
    {
        public string description;
        public string htmlUrl;
        public string rssUrl;
        public string title;
        public string categoryid;
    }

    public struct Category
    {
        public string categoryId;
        public string categoryName;
    }

    public struct FileData
    {
        public byte[] bits;
        public string name;
        public string type;
    }

    public struct UrlData
    {
        public string url;
    }

    public struct UserInfo
    {
        public string userid;
        public string nickname;
        public string firstname;
        public string lastname;
        public string email;
        public string url;
    }

    public struct BlogInfo
    {
        public string blogid;
        public string url;
        public string blogName;
    }

    public interface IBlogger
    {
        [XmlRpcMethod("blogger.deletePost",
           Description = "Deletes a post.")]
        [return: XmlRpcReturnValue(Description = "Always returns true.")]
        bool deletePost(
          string appKey,
          string postid,
          string username,
          string password,
          [XmlRpcParameter(
             Description = "Where applicable, this specifies whether the blog "
             + "should be republished after the post has been deleted.")]
      bool publish);

        [XmlRpcMethod("blogger.getUserInfo",
           Description = "Authenticates a user and returns basic user info "
           + "(name, email, userid, etc.).")]
        UserInfo getUserInfo(
          string appKey,
          string username,
          string password);

        [XmlRpcMethod("blogger.getUsersBlogs",
           Description = "Returns information on all the blogs a given user "
           + "is a member.")]
        BlogInfo[] getUsersBlogs(
          string appKey,
          string username,
          string password);

    }

    public interface IMetaWeblog
    {
        [XmlRpcMethod("metaWeblog.editPost",
           Description = "Updates and existing post to a designated blog "
           + "using the metaWeblog API. Returns true if completed.")]
        bool editPost(
          string postid,
          string username,
          string password,
          Post post,
          bool publish);

        [XmlRpcMethod("metaWeblog.getCategories",
           Description = "Retrieves a list of valid categories for a post "
           + "using the metaWeblog API. Returns the metaWeblog categories "
           + "struct collection.")]
        CategoryInfo[] getCategories(
          string blogid,
          string username,
          string password);

        [XmlRpcMethod("metaWeblog.getPost",
           Description = "Retrieves an existing post using the metaWeblog "
           + "API. Returns the metaWeblog struct.")]
        Post getPost(
          string postid,
          string username,
          string password);

        [XmlRpcMethod("metaWeblog.getRecentPosts",
           Description = "Retrieves a list of the most recent existing post "
           + "using the metaWeblog API. Returns the metaWeblog struct collection.")]
        Post[] getRecentPosts(
          string blogid,
          string username,
          string password,
          int numberOfPosts);

        [XmlRpcMethod("metaWeblog.newPost",
           Description = "Makes a new post to a designated blog using the "
           + "metaWeblog API. Returns postid as a string.")]
        string newPost(
          string blogid,
          string username,
          string password,
          Post post,
          bool publish);

        [XmlRpcMethod("metaWeblog.newMediaObject",
      Description = "Makes a new file to a designated blog using the "
      + "metaWeblog API. Returns url as a string of a struct.")]
        UrlData newMediaObject(
          string blogid,
          string username,
          string password,
          FileData file);
    }
}
