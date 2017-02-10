using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Logic
{
    public class TargetInfo : ITargetInfo
    {
        public ICharacter Target { get; set; }
        public ISpell Spell { get; set; }
    }
}