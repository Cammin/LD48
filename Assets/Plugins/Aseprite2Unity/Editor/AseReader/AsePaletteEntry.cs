namespace Plugins.Aseprite2Unity.Editor.AseReader
{
    public class AsePaletteEntry
    {
        public ushort Flags { get; private set; }
        public byte Red { get; private set; }
        public byte Green { get; private set; }
        public byte Blue { get; private set; }
        public byte Alpha { get; private set; }
        public string Name { get; private set; }

        public bool HasName => (Flags & 0x0001) != 0;

        public AsePaletteEntry(AseReader reader)
        {
            Flags = reader.ReadWORD();
            Red = reader.ReadBYTE();
            Green = reader.ReadBYTE();
            Blue = reader.ReadBYTE();
            Alpha = reader.ReadBYTE();

            if (HasName)
            {
                Name = reader.ReadSTRING();
            }
        }
    }
}
