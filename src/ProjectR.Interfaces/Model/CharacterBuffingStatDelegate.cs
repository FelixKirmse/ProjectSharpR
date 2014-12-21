using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Interfaces.Model
{
    public delegate void CharacterBuffingStatDelegate(ICharacter character, ref Stat stat, ref double multiplier);
}