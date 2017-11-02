using System;
using System.Collections.Generic;

namespace Mushare.Mushages
{
    public abstract class Mushage
    {
        public abstract int ConstructorCode { get; }

        public abstract byte[] Encode();
        public abstract void Decode(byte[] encoded);


        public static readonly Dictionary<int, Type> Constructors = new Dictionary<int, Type>()
        {
            { -1464188667, typeof(TextMushage) },
            { 00741144341, typeof(ChangeSongMushage) }
        };
    }
}
