using System.Collections.Generic;
using System.Linq;

namespace Plugins.Aseprite2Unity.Editor.AseReader
{
    public class AsePaletteChunk : AseChunk
    {
        public override ChunkType ChunkType => ChunkType.Palette;

        public int PaletteSize { get; private set; }
        public int FirstIndex { get; private set; }
        public int LastIndex { get; private set; }

        public List<AsePaletteEntry> Entries { get; private set; }

        public AsePaletteChunk(AseFrame frame, AseReader reader)
            : base(frame)
        {
            PaletteSize = (int)reader.ReadDWORD();
            FirstIndex = (int)reader.ReadDWORD();
            LastIndex = (int)reader.ReadDWORD();

            // Next 8 bytes are ignored
            reader.ReadBYTEs(8);

            Entries = Enumerable.Repeat<AsePaletteEntry>(null, LastIndex + 1).ToList();
            for (int i = FirstIndex; i <= LastIndex; i++)
            {
                Entries[i] = new AsePaletteEntry(reader);
            }
        }

        public override void Visit(IAseVisitor visitor)
        {
            visitor.VisitPaletteChunk(this);
        }
    }
}
