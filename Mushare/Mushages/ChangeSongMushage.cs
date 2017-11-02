using System;
using System.IO;

namespace Mushare.Mushages
{
    public class ChangeSongMushage : Mushage
    {
        public override int ConstructorCode => 741144341; // "ChangeSongMushage".GetHashCode();

        public override void Decode(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            using (var br = new BinaryReader(ms))
            {
                br.ReadInt32(); // contructor code
            }
        }

        public override byte[] Encode()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write(ConstructorCode);

                return ms.ToArray();
            }
        }
    }
}
