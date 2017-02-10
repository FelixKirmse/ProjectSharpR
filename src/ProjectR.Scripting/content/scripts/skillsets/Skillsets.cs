namespace ProjectR.Scripting.Skillsets
{
    public class BruiserSkillset : Skillset
    {
        public override string Name { get { return "Bruiser"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Beastly Smash", "Frozen Blood", "Night Stalker"
                };
            }
        }
    }

    public class TankSkillset : Skillset
    {
        public override string Name { get { return "Tank"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Demonic Strike", "Optical Camouflage X69", "Untouchable"
                };
            }
        }
    }

    public class MageSkillset : Skillset
    {
        public override string Name { get { return "Mage"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Distortion Field", "Empowering Laser", "Fractured Laser Barrage"
                };
            }
        }
    }

    public class AggressiveSupporterSkillset : Skillset
    {
        public override string Name { get { return "Aggressive Supporter"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Crippling Aura", "Cataclysmic Barrier", "Freeze Them To Death!"
                };
            }
        }
    }

    public class DefensiveSupporterSkillset : Skillset
    {
        public override string Name { get { return "Defensive Supporter"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Support Technique: Shield", "Support Technique: Sword", "Support Technique: Wand"
                };
            }
        }
    }

    public class HealerSkillset : Skillset
    {
        public override string Name { get { return "Healer"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Blessed Ground", "Dark Fog (Ally)", "Divine Restoration"
                };
            }
        }
    }

    public class BerserkerSkillset : Skillset
    {
        public override string Name { get { return "Berserker"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Alpha Slash", "Omnislash", "True Form"
                };
            }
        }
    }

    public class MinionMasterSkillset : Skillset
    {
        public override string Name { get { return "Minion Master"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Summon: Ghostly Priest", "Summon: Imp", "Summon: Trickster"
                };
            }
        }
    }

    public class PurePunisherSkillset : Skillset
    {
        public override string Name { get { return "Pure Punisher"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Dark Fog (Enemy)", "Darkness Comes From Within", "Piercing Flames"
                };
            }
        }
    }

    public class CompositeCarnageSkillset : Skillset
    {
        public override string Name { get { return "Composite Carnage"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Explosive Fist", "Fire Wheel", "Vengeful Spirit"
                };
            }
        }
    }

    public class MagicalMastermindSkillset : Skillset
    {
        public override string Name { get { return "Magical Mastermind"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Extinction", "Nuclear Meltdown", "Tsunami"
                };
            }
        }
    }

    public class PhysicalPowerhouseSkillset : Skillset
    {
        public override string Name { get { return "Physical Powerhouse"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Reckless Swing", "One At A Time", "Fiery Fury Fist"
                };
            }
        }
    }

    public class DemonicAcolyteSkillset : Skillset
    {
        public override string Name { get { return "Demonic Acolyte"; } }

        protected override string[] SpellNames
        {
            get
            {
                return new[]
                {
                    "Curse of the Han'yo", "Embrace of the Demon", "Blood for Power"
                };
            }
        }
    }
}