using System.Collections.Generic;
using System.Linq;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model;

namespace ProjectR.Model
{
    public class Party : IParty
    {
        private const int FrontRowLimit = 4;
        private const int BackSeatLimit = 8;
        private readonly Dictionary<ICharacter, IList<ICharacter>> _charMap;

        private readonly IModel _model;
        private int _averagePartyLvl;
        private bool _cached;

        public Party(IModel model)
        {
            _model = model;
            _charMap = new Dictionary<ICharacter, IList<ICharacter>>();
            FrontRow = new List<ICharacter>();
            BackSeat = new List<ICharacter>();
            Reserve = new List<ICharacter>();
        }

        public IList<ICharacter> FrontRow { get; private set; }
        public IList<ICharacter> BackSeat { get; private set; }
        public IList<ICharacter> Reserve { get; private set; }
        public int Experience { get; private set; }

        public int AveragePartyLvl
        {
            get
            {
                if (_cached)
                {
                    return _averagePartyLvl;
                }

                var charCount = _charMap.Keys.Count;
                double lvlSum = _charMap.Keys.Sum(character => character.CurrentLevel);

                _cached = true;
                if (charCount == 0)
                {
                    return 0;
                }

                _averagePartyLvl = (int) (lvlSum / charCount);
                return _averagePartyLvl;
            }
        }


        public void Reset()
        {
            Experience = 0;
            FrontRow.Clear();
            BackSeat.Clear();
            Reserve.Clear();
            _charMap.Clear();
            ResetCache();
        }

        public void ResetCache()
        {
            _cached = false;
        }

        public void AddExperience(int amount)
        {
            ResetCache();
            Experience += amount;

            foreach (var character in _charMap.Keys)
            {
                character.LvlUp(Experience);
            }
        }

        public void SwitchCharacters(ICharacter char1, ICharacter char2)
        {
            if (char1 == null)
            {
                // We are replacing a dead frontrow member!
                FrontRow.Add(char2);
                _charMap[char2] = FrontRow;
                BackSeat.Remove(char2);
                return;
            }

            var originList = _charMap[char1];
            var targetList = _charMap[char2];
            _charMap[char1] = targetList;
            _charMap[char2] = originList;

            var char1Pos = originList.IndexOf(char1);
            var char2Pos = targetList.IndexOf(char2);

            originList[char1Pos] = char2;
            targetList[char2Pos] = char1;
        }

        public void AddCharacter(ICharacter character, PartySlot slot)
        {
            var relevantList = slot == PartySlot.FrontRow
                ? FrontRow
                : slot == PartySlot.BackSeat ? BackSeat : Reserve;
            var limit = slot == PartySlot.FrontRow ? FrontRowLimit : slot == PartySlot.BackSeat ? BackSeatLimit : -1;

            if (relevantList.Count == limit)
            {
                ExitHelper.Exit(
                    slot == PartySlot.FrontRow
                        ? ErrorCodes.ErrorCharLimitReachedFrontrow
                        : slot == PartySlot.BackSeat
                            ? ErrorCodes.ErrorCharLimitReachedBackseat
                            : ErrorCodes.ErrorCharLimitReachedReserve,
                    "Attempted to add Character to party depsite being full");
            }

            relevantList.Add(character);
            _charMap[character] = relevantList;

            var currentHighestPartyCount = _model.Statistics[Statistic.HighestPartyCount];
            var currentPartyCount = (ulong) _charMap.Count;

            if (currentPartyCount > currentHighestPartyCount)
            {
                _model.Statistics.AddToStatistic(Statistic.HighestPartyCount,
                    (uint) (currentPartyCount - currentHighestPartyCount));
            }

            character.LvlUp(Experience);
            ResetCache();
        }

        public void AddCharacter(ICharacter character)
        {
            if (FrontRow.Count != FrontRowLimit)
            {
                AddCharacter(character, PartySlot.FrontRow);
            }
            else if (BackSeat.Count != BackSeatLimit)
            {
                AddCharacter(character, PartySlot.BackSeat);
            }
            else
            {
                AddCharacter(character, PartySlot.Reserve);
            }
        }

        public void RemoveCharacter(ICharacter character)
        {
            var list = _charMap[character];
            list.Remove(character);

            _charMap.Remove(character);
            ResetCache();
        }
    }
}