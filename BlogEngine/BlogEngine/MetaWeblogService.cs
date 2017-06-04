using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;
using BlogEngine.XmlRpcContracts;
using System.Diagnostics;

namespace BlogEngine
{
    [XmlRpcService(Name = "metaWeblog",
                     Description = "Content Engine",
                     AutoDocVersion = true,
                     AutoDocumentation = true),
                     XmlRpcUrl("http://www.my-xml-rpc.org")]
    public abstract class MetaWeblogService : XmlRpcService, XmlRpcContracts.IMetaWeblog, XmlRpcContracts.IBlogger
    {
        private static bool AuthenticateUser(string username, string password)
        {
            return true;
        }

        public bool deletePost(string appKey, string postid, string username, string password, bool publish)
        {
            // TODO: Implement blogger.deletepost
            throw new NotImplementedException();
        }

        public UserInfo getUserInfo(string appKey, string username, string password)
        {
            UserInfo info;

            info = new UserInfo()
            {
                email = "some@mail.com",
                firstname = "some",
                lastname = "user"
            };

            return info;
        }

        public abstract BlogInfo[] getUsersBlogs(string appKey, string username, string password);

        public CategoryInfo[] getCategories(string blogid, string username, string password)
        {
            return new CategoryInfo[] { };
        }

        public Post getPost(string postid, string username, string password)
        {
            return new Post();
        }

        public Post[] getRecentPosts(string blogid, string username, string password, int numberOfPosts)
        {
            return null;
        }

        public string newPost(string blogid, string username, string password, Post post, bool publish)
        {
            BlogEngine.PublishPost(post.title, post.description, username);

            return "0";
        }

        public bool editPost(string postid, string username, string password, Post post, bool publish)
        {
            throw new NotImplementedException();
        }

        public UrlData newMediaObject(string blogid, string username, string password, FileData file)
        {
            string fileName = file.name;
            string fileExtension = System.IO.Path.GetExtension(fileName);

            var uri = UploadMediaObject(fileExtension, file.type, file.bits);

            return new UrlData()
            {
                url = uri.ToString()
            };
        }

        protected abstract Uri UploadMediaObject(string fileExtension, string contentType, byte[] data);
    }
}
