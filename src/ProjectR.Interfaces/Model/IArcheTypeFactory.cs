using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface IArcheTypeFactory
    {
        IList<IArcheType> ArcheTypes { get; }

        void LoadArcheTypes();
        IArcheType GetArcheType(string name);
    }
}