using System;
using System.IO;

namespace Mushare.Mushages
{
    public  class TextMushage : Mushage
    {
        public override int ConstructorCode => -1464188667; // "TextMushage".GetHashCode();

        public string Sender { get; private set; }
        public DateTime Sent { get; private set; }
        public string Text { get; private set; }

        public override void Decode(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            using (var br = new BinaryReader(ms))
            {
                br.ReadInt32(); // contructor code

                Sender = br.ReadString();
                Sent = Utils.GetDateTimeFromUnix(br.ReadInt64());
                Text = br.ReadString();
            }
        }

        public override byte[] Encode()
        {
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write(ConstructorCode);

                bw.Write(Sender);
                bw.Write(Utils.GetUnixTimeNow());
                bw.Write(Text);

                return ms.ToArray();
            }
        }
    }
}
