using System.Collections.Generic;
using System.Linq;

namespace Plugins.Aseprite2Unity.Editor.AseReader
{
    public class AseSliceChunk : AseChunk
    {
        public override ChunkType ChunkType => ChunkType.Slice;

        public uint NumSliceKeys { get; private set; }
        public SliceFlags Flags { get; private set; }
        public string Name { get; private set; }

        public List<AseSliceEntry> Entries { get; private set; }

        public AseSliceChunk(AseFrame frame, AseReader reader)
            : base(frame)
        {
            NumSliceKeys = reader.ReadDWORD();
            Flags = (SliceFlags)reader.ReadDWORD();

            // Ignore next dword
            reader.ReadDWORD();

            Name = reader.ReadSTRING();

            Entries = Enumerable.Repeat<AseSliceEntry>(null, (int)NumSliceKeys).ToList();
            for (int i = 0; i < (int)NumSliceKeys; i++)
            {
                Entries[i] = new AseSliceEntry(reader, Flags);
            }
        }

        public override void Visit(IAseVisitor visitor)
        {
            visitor.VisitSliceChunk(this);
        }
    }
}
