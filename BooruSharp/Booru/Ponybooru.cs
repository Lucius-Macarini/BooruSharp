﻿using BooruSharp.Booru.Template;

namespace BooruSharp.Booru
{
    public class Ponybooru : PhilomenaV1
    {
        public Ponybooru() : base("ponybooru.org")
        { }

        public override bool IsSafe => false;
    }
}
