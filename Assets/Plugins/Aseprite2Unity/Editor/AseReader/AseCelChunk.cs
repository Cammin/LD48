using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Plugins.Aseprite2Unity.Editor.AseReader
{
    public class AseCelChunk : AseChunk
    {
        public override ChunkType ChunkType => ChunkType.Cel;

        public ushort LayerIndex { get; private set; }
        public short PositionX { get; private set; }
        public short PositionY { get; private set; }
        public byte Opacity { get; private set; }
        public CelType CelType { get; private set; }

        public ushort Width { get; private set; }
        public ushort Height { get; private set; }
        public ushort FramePositionLink { get; private set; }
        public byte[] PixelBytes { get; private set; }

        public AseCelChunk LinkedCel { get; private set; }

        public AseCelChunk(AseFrame frame, AseReader reader, int size)
            : base(frame)
        {
            // Keep track of read position
            var pos = reader.Position;

            LayerIndex = reader.ReadWORD();
            PositionX = reader.ReadSHORT();
            PositionY = reader.ReadSHORT();
            Opacity = reader.ReadBYTE();
            CelType = (CelType)reader.ReadWORD();

            // Ignore next 7 bytes
            reader.ReadBYTEs(7);

            if (CelType == CelType.Raw)
            {
                Width = reader.ReadWORD();
                Height = reader.ReadWORD();

                var bytesRead = reader.Position - pos;
                PixelBytes = reader.ReadBYTEs(size - bytesRead);
            }
            else if (CelType == CelType.Linked)
            {
                FramePositionLink = reader.ReadWORD();

                // Get a reference to our linked cell. It should be in a previous frame with a matching layer index.
                Debug.Assert(Frame.AseFile.Frames.Count > FramePositionLink);
                LinkedCel = Frame.AseFile.Frames[FramePositionLink].Chunks.OfType<AseCelChunk>().FirstOrDefault(c => c.LayerIndex == LayerIndex);
                Debug.Assert(LinkedCel != null);
            }
            else if (CelType == CelType.CompressedImage)
            {
                Width = reader.ReadWORD();
                Height = reader.ReadWORD();

                var bytesRead = reader.Position - pos;
                var compressed = reader.ReadBYTEs(size - bytesRead);
                PixelBytes = ZlibDeflate(compressed);
            }
        }

        public override void Visit(IAseVisitor visitor)
        {
            visitor.VisitCelChunk(this);
        }

        private static byte[] ZlibDeflate(byte[] bytesCompressed)
        {
            var streamCompressed = new MemoryStream(bytesCompressed);

            // Nasty trick: Have to read past the zlib stream header
            streamCompressed.ReadByte();
            streamCompressed.ReadByte();

            // Now, decompress the bytes
            using (MemoryStream streamDecompressed = new MemoryStream())
            using (DeflateStream deflateStream = new DeflateStream(streamCompressed, CompressionMode.Decompress))
            {
                deflateStream.CopyTo(streamDecompressed);
                return streamDecompressed.ToArray();
            }
        }
    }
}
