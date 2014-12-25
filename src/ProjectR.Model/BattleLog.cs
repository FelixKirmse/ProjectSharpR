using System.Collections.Generic;
using ProjectR.Interfaces;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class BattleLog : IBattleLog
    {
        private readonly IBattleModel _battleModel;
        private readonly List<LogEntry> _log = new List<LogEntry>();

        public BattleLog(IBattleModel battleModel)
        {
            _battleModel = battleModel;
        }

        public void LogAction(ICharacter caster, ICharacter receiver, ISpell spell)
        {
            var entry = new LogEntry
            {
                CasterName = caster.Name,
                CasterIsEnemy = _battleModel.CharacterIsEnemy(caster),
                SpellName = spell.Name,
                SelfCast = spell.TargetType == TargetType.Myself,
                ReceiverName = receiver.Name,
                ReceiverIsEnemy = _battleModel.CharacterIsEnemy(receiver),
                AttackDodged = receiver.DodgedAttack,
                WasHealed = receiver.WasHealed,
                Value = receiver.DamageTaken,
                AttackBlocked = receiver.BlockedDamage,
                WasAfflicted = receiver.WasAfflicted,
                AfflictedBy = receiver.AfflictedBy,
                Fatal = receiver.IsDead,
                IsCustomMessage = false
            };

            _log.Add(entry);
        }

        public void Log(string message)
        {
            var entry = new LogEntry
            {
                IsCustomMessage = true,
                CustomMessage = message
            };
            _log.Add(entry);
        }

        public IList<LogEntry> GetLastEntries(int count)
        {
            var result = new List<LogEntry>(_log.GetRange(0, count));
            return result;
        }

        public void ClearLog()
        {
            _log.Clear();
        }

        public IList<LogEntry> GetLog()
        {
            return _log;
        }
    }
}