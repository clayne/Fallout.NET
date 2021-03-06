using Fallout.NET.Core;
using Fallout.NET.TES4.SubRecords;

namespace Fallout.NET.TES4.Records
{
	public class ACHRRecord : Record
	{
        public STRSubRecord EDID { get; private set; }
        public FormID NAME { get; private set; }
        public FormID XEZN { get; private set; }
        public FormID INAM { get; private set; }
        public FormID TNAM { get; private set; }
        public FormID XMRC { get; private set; }
        public FormID XLKR { get; private set; }
        public FormID XEMI { get; private set; }
        public FormID XMBR { get; private set; }
        public PosAndRotSubRecord DATA { get; private set; }


        protected override void ExtractSubRecords(BetterReader reader, GameID gameID, uint size)
        {
            var bytes = reader.ReadBytes((int)size);
            var name = string.Empty;

            using (var stream = new BetterMemoryReader(bytes))
            {
                var end = stream.Length;

                while (stream.Position < end)
                {
                    name = stream.ReadString(4);

                    switch (name)
                    {
                        case "EDID":
                            EDID = new STRSubRecord();
                            EDID.Deserialize(stream, name);
                            break;
                        case "NAME":
                            NAME = new FormID();
                            NAME.Deserialize(stream, name);
                            break;
                        case "XEZN":
                            XEZN = new FormID();
                            XEZN.Deserialize(stream, name);
                            break;
                        case "INAM":
                            INAM = new FormID();
                            INAM.Deserialize(stream, name);
                            break;
                        case "TNAM":
                            TNAM = new FormID();
                            TNAM.Deserialize(stream, name);
                            break;
                        case "XMRC":
                            XMRC = new FormID();
                            XMRC.Deserialize(stream, name);
                            break;
                        case "XLKR":
                            XLKR = new FormID();
                            XLKR.Deserialize(stream, name);
                            break;
                        case "XEMI":
                            XEMI = new FormID();
                            XEMI.Deserialize(stream, name);
                            break;
                        case "XMBR":
                            XMBR = new FormID();
                            XMBR.Deserialize(stream, name);
                            break;
                        case "DATA":
                            DATA = new PosAndRotSubRecord();
                            DATA.Deserialize(stream, name);
                            break;
                        default:
                            var rest = stream.ReadUInt16();
                            stream.ReadBytes(rest);
                            break;
                    }
                }
            }
        }
	}
}