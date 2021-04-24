namespace Plugins.Aseprite2Unity.Editor.AseReader
{
    public abstract class AseChunk
    {
        public abstract ChunkType ChunkType { get; }

        public AseFrame Frame { get; private set; }
        public string UserText { get; set; }
        public byte[] UserColor { get; set; }

        protected AseChunk(AseFrame frame)
        {
            Frame = frame;
        }

        public abstract void Visit(IAseVisitor visitor);
    }
}
