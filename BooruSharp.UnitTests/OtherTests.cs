﻿using BooruSharp.Booru;
using System.Threading.Tasks;
using Xunit;

namespace BooruSharp.UnitTests
{
    // TODO: Find a way to check if commands are available on website or not

    public class OtherTests
    {
        [Fact]
        public async Task GelbooruTagCharacter()
        {
            Assert.Equal(Search.Tag.TagType.Character, (await (await Boorus.GetAsync<Gelbooru>()).GetTagAsync("cirno")).Type);
        }

        [Fact]
        public async Task GelbooruTagCopyright()
        {
            Assert.Equal(Search.Tag.TagType.Copyright, (await (await Boorus.GetAsync<Gelbooru>()).GetTagAsync("kantai_collection")).Type);
        }

        [Fact]
        public async Task GelbooruTagArtist()
        {
            Assert.Equal(Search.Tag.TagType.Artist, (await (await Boorus.GetAsync<Gelbooru>()).GetTagAsync("mtu_(orewamuzituda)")).Type);
        }

        [Fact]
        public async Task GelbooruTagMetadata()
        {
            Assert.Equal(Search.Tag.TagType.Metadata, (await (await Boorus.GetAsync<Gelbooru>()).GetTagAsync("uncensored")).Type);
        }

        [Fact]
        public async Task GelbooruTagTrivia()
        {
            Assert.Equal(Search.Tag.TagType.Trivia, (await (await Boorus.GetAsync<Gelbooru>()).GetTagAsync("futanari")).Type);
        }
    }
}
