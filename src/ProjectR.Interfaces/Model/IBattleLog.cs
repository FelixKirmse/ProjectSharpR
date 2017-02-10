using System.Collections.Generic;

namespace ProjectR.Interfaces.Model
{
    public interface IBattleLog
    {
        void LogAction(ICharacter caster, ICharacter receiver, ISpell spell);
        void Log(string message);
        IList<LogEntry> GetLastEntries(int count);
        void ClearLog();
        IList<LogEntry> GetLog();
    }

    public class LogEntry
    {
        public string CasterName { get; set; }
        public bool CasterIsEnemy { get; set; }
        public string SpellName { get; set; }
        public bool SelfCast { get; set; }
        public string ReceiverName { get; set; }
        public bool ReceiverIsEnemy { get; set; }
        public bool AttackDodged { get; set; }
        public bool WasHealed { get; set; }
        public double Value { get; set; }
        public bool AttackBlocked { get; set; }
        public bool WasAfflicted { get; set; }
        public string AfflictedBy { get; set; }
        public bool Fatal { get; set; }
        public bool IsCustomMessage { get; set; }
        public string CustomMessage { get; set; }
    }
}