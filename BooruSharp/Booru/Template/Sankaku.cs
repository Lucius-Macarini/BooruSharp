﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooruSharp.Booru.Template
{
    public abstract class Sankaku : Booru
    {
        public Sankaku(string url, BooruAuth auth = null, params BooruOptions[] options) : base(url, auth, UrlFormat.sankaku, CombineArrays(options, new[] { BooruOptions.noRelated, BooruOptions.noPostByMd5 }))
        { }

        protected internal override Search.Post.SearchResult GetPostSearchResult(object json)
        {
            var elem = ((JArray)json).FirstOrDefault();
            if (elem == null)
                throw new Search.InvalidTags();
            List<string> tags = new List<string>();
            foreach (JObject tag in (JArray)elem["tags"])
                tags.Add(tag["name"].Value<string>());
            return new Search.Post.SearchResult(
                    new Uri(elem["file_url"].Value<string>()),
                    new Uri(elem["preview_url"].Value<string>()),
                    GetRating(elem["rating"].Value<string>()[0]),
                    tags.ToArray(),
                    elem["id"].Value<int>(),
                    elem["file_size"].Value<int>(),
                    elem["height"].Value<int>(),
                    elem["width"].Value<int>(),
                    elem["preview_height"].Value<int>(),
                    elem["preview_width"].Value<int>(),
                    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(elem["created_at"]["s"].Value<int>()),
                    elem["source"].Value<string>(),
                    elem["total_score"].Value<int>(),
                    elem["md5"].Value<string>()
                );
        }

        protected internal override Search.Comment.SearchResult GetCommentSearchResult(object json)
        {
            var elem = (JObject)json;
            return new Search.Comment.SearchResult(
                elem["id"].Value<int>(),
                elem["post_id"].Value<int>(),
                elem["author"]["id"].Value<int?>(),
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(elem["created_at"]["s"].Value<int>()),
                elem["author"]["name"].Value<string>(),
                elem["body"].Value<string>()
                );
        }

        protected internal override Search.Wiki.SearchResult GetWikiSearchResult(object json)
        {
            var elem = (JObject)json;
            return new Search.Wiki.SearchResult(
                elem["id"].Value<int>(),
                elem["title"].Value<string>(),
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(elem["created_at"]["s"].Value<int>()),
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(elem["updated_at"]["s"].Value<int>()),
                elem["body"].Value<string>()
                );
        }

        protected internal override Search.Tag.SearchResult GetTagSearchResult(object json) // TODO: Fix TagType values
        {
            var elem = (JObject)json;
            return new Search.Tag.SearchResult(
                elem["id"].Value<int>(),
                elem["name"].Value<string>(),
                (Search.Tag.TagType)elem["type"].Value<int>(),
                elem["count"].Value<int>()
                );
        }

        // GetRelatedSearchResult not available
    }
}
