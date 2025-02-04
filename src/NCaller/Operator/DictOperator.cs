﻿using NCaller.Builder;
using System;


namespace NCaller
{

    public class DictOperator
    {
        public static DictBase Create(Type type) => DictBuilder.Ctor(type);
    }




    public static class DictOperator<T>
    {

        public readonly static Func<DictBase> Create;

        static DictOperator() => Create = DictBuilder.InitType(typeof(T)); 

    }

}
