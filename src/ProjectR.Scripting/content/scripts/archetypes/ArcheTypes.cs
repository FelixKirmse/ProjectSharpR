using System.Collections.Generic;
using ProjectR.Interfaces.Helper;
using ProjectR.Interfaces.Model.Stats;

namespace ProjectR.Scripting.Archetypes
{
    public class FragileSpeedsterArcheType : ArcheType
    {
        public override string Name { get { return "Fragile Speedster"; } }

        public override bool Block { get { return false; } }

        protected override IDictionary<Stat, double> Resistances { get { return _resistances; } }

        protected override IDictionary<Stat, Pair<double, double>> Stats { get { return _stats; } }

        private readonly IDictionary<Stat, Pair<double, double>> _stats = new Dictionary<Stat, Pair<double, double>>
        {
            { Stat.HP, new Pair<double, double>(100, 10) },
            { Stat.MP, new Pair<double, double>(200, 0) },
            { Stat.AD, new Pair<double, double>(60, 10) },
            { Stat.MD, new Pair<double, double>(60, 10) },
            { Stat.DEF, new Pair<double, double>(25, 5) },
            { Stat.MR, new Pair<double, double>(25, 5) },
            { Stat.EVA, new Pair<double, double>(2, 8) },
            { Stat.SPD, new Pair<double, double>(100, 10) },
            { Stat.CHA, new Pair<double, double>(60, 15) },
        };

        private readonly IDictionary<Stat, double> _resistances = new Dictionary<Stat, double>
        {
            { Stat.PSN, 3 },
            { Stat.PAR, 3 },
            { Stat.SIL, 3 },
            { Stat.DTH, 3 },
        };
    }

    public class StoneWallArcheType : ArcheType
    {
        public override string Name { get { return "Stone Wall"; } }

        public override bool Block { get { return true; } }

        protected override IDictionary<Stat, double> Resistances { get { return _resistances; } }

        protected override IDictionary<Stat, Pair<double, double>> Stats { get { return _stats; } }

        private readonly IDictionary<Stat, Pair<double, double>> _stats = new Dictionary<Stat, Pair<double, double>>
        {
            { Stat.HP, new Pair<double, double>(200, 25) },
            { Stat.MP, new Pair<double, double>(200, 0) },
            { Stat.AD, new Pair<double, double>(20, 1) },
            { Stat.MD, new Pair<double, double>(20, 1) },
            { Stat.DEF, new Pair<double, double>(80, 20) },
            { Stat.MR, new Pair<double, double>(80, 20) },
            { Stat.EVA, new Pair<double, double>(20, 1) },
            { Stat.SPD, new Pair<double, double>(100, 5) },
            { Stat.CHA, new Pair<double, double>(50, 5) },
        };

        private readonly IDictionary<Stat, double> _resistances = new Dictionary<Stat, double>
        {
            { Stat.PSN, 35 },
            { Stat.PAR, 35 },
            { Stat.SIL, 35 },
            { Stat.DTH, 35 },
        };
    }

    public class MightyGlacierArcheType : ArcheType
    {
        public override string Name { get { return "Mighty Glacier"; } }

        public override bool Block { get { return true; } }

        protected override IDictionary<Stat, double> Resistances { get { return _resistances; } }

        protected override IDictionary<Stat, Pair<double, double>> Stats { get { return _stats; } }

        private readonly IDictionary<Stat, Pair<double, double>> _stats = new Dictionary<Stat, Pair<double, double>>
        {
            { Stat.HP, new Pair<double, double>(180, 20) },
            { Stat.MP, new Pair<double, double>(200, 0) },
            { Stat.AD, new Pair<double, double>(80, 20) },
            { Stat.MD, new Pair<double, double>(80, 20) },
            { Stat.DEF, new Pair<double, double>(80, 15) },
            { Stat.MR, new Pair<double, double>(80, 15) },
            { Stat.EVA, new Pair<double, double>(20, 1) },
            { Stat.SPD, new Pair<double, double>(100, 2) },
            { Stat.CHA, new Pair<double, double>(55, 15) },
        };

        private readonly IDictionary<Stat, double> _resistances = new Dictionary<Stat, double>
        {
            { Stat.PSN, 30 },
            { Stat.PAR, 30 },
            { Stat.SIL, 30 },
            { Stat.DTH, 30 },
        };
    }

    public class GlassCanonArcheType : ArcheType
    {
        public override string Name { get { return "Glass Cannon"; } }

        public override bool Block { get { return false; } }

        protected override IDictionary<Stat, double> Resistances { get { return _resistances; } }

        protected override IDictionary<Stat, Pair<double, double>> Stats { get { return _stats; } }

        private readonly IDictionary<Stat, Pair<double, double>> _stats = new Dictionary<Stat, Pair<double, double>>
        {
            { Stat.HP, new Pair<double, double>(75, 5) },
            { Stat.MP, new Pair<double, double>(200, 0) },
            { Stat.AD, new Pair<double, double>(80, 20) },
            { Stat.MD, new Pair<double, double>(80, 20) },
            { Stat.DEF, new Pair<double, double>(20, 1) },
            { Stat.MR, new Pair<double, double>(20, 1) },
            { Stat.EVA, new Pair<double, double>(20, 1) },
            { Stat.SPD, new Pair<double, double>(100, 6) },
            { Stat.CHA, new Pair<double, double>(65, 20) },
        };

        private readonly IDictionary<Stat, double> _resistances = new Dictionary<Stat, double>
        {
            { Stat.PSN, 0 },
            { Stat.PAR, 0 },
            { Stat.SIL, 0 },
            { Stat.DTH, 0 },
        };
    }

    public class JackOfAllStatsArcheType : ArcheType
    {
        public override string Name { get { return "Jack Of All Stats"; } }

        public override bool Block { get { return false; } }

        protected override IDictionary<Stat, double> Resistances { get { return _resistances; } }

        protected override IDictionary<Stat, Pair<double, double>> Stats { get { return _stats; } }

        private readonly IDictionary<Stat, Pair<double, double>> _stats = new Dictionary<Stat, Pair<double, double>>
        {
            { Stat.HP, new Pair<double, double>(138, 15) },
            { Stat.MP, new Pair<double, double>(200, 0) },
            { Stat.AD, new Pair<double, double>(50, 10) },
            { Stat.MD, new Pair<double, double>(50, 10) },
            { Stat.DEF, new Pair<double, double>(50, 10) },
            { Stat.MR, new Pair<double, double>(50, 10) },
            { Stat.EVA, new Pair<double, double>(2, 4) },
            { Stat.SPD, new Pair<double, double>(100, 7) },
            { Stat.CHA, new Pair<double, double>(50, 10) },
        };

        private readonly IDictionary<Stat, double> _resistances = new Dictionary<Stat, double>
        {
            { Stat.PSN, 15 },
            { Stat.PAR, 15 },
            { Stat.SIL, 15 },
            { Stat.DTH, 15 },
        };
    }

    public class BruiserArcheType : ArcheType
    {
        public override string Name { get { return "Bruiser"; } }

        public override bool Block { get { return true; } }

        protected override IDictionary<Stat, double> Resistances { get { return _resistances; } }

        protected override IDictionary<Stat, Pair<double, double>> Stats { get { return _stats; } }

        private readonly IDictionary<Stat, Pair<double, double>> _stats = new Dictionary<Stat, Pair<double, double>>
        {
            { Stat.HP, new Pair<double, double>(170, 18) },
            { Stat.MP, new Pair<double, double>(200, 0) },
            { Stat.AD, new Pair<double, double>(70, 18) },
            { Stat.MD, new Pair<double, double>(70, 18) },
            { Stat.DEF, new Pair<double, double>(70, 12) },
            { Stat.MR, new Pair<double, double>(70, 12) },
            { Stat.EVA, new Pair<double, double>(20, 1) },
            { Stat.SPD, new Pair<double, double>(100, 7) },
            { Stat.CHA, new Pair<double, double>(40, 10) },
        };

        private readonly IDictionary<Stat, double> _resistances = new Dictionary<Stat, double>
        {
            { Stat.PSN, 12 },
            { Stat.PAR, 12 },
            { Stat.SIL, 12 },
            { Stat.DTH, 12 },
        };
    }

    public class MageArcheType : ArcheType
    {
        public override string Name { get { return "Mage"; } }

        public override bool Block { get { return false; } }

        protected override IDictionary<Stat, double> Resistances { get { return _resistances; } }

        protected override IDictionary<Stat, Pair<double, double>> Stats { get { return _stats; } }

        private readonly IDictionary<Stat, Pair<double, double>> _stats = new Dictionary<Stat, Pair<double, double>>
        {
            { Stat.HP, new Pair<double, double>(95, 10) },
            { Stat.MP, new Pair<double, double>(200, 0) },
            { Stat.AD, new Pair<double, double>(20, 5) },
            { Stat.MD, new Pair<double, double>(70, 18) },
            { Stat.DEF, new Pair<double, double>(16, 7) },
            { Stat.MR, new Pair<double, double>(60, 16) },
            { Stat.EVA, new Pair<double, double>(2, 1) },
            { Stat.SPD, new Pair<double, double>(100, 5) },
            { Stat.CHA, new Pair<double, double>(50, 10) },
        };

        private readonly IDictionary<Stat, double> _resistances = new Dictionary<Stat, double>
        {
            { Stat.PSN, 8 },
            { Stat.PAR, 8 },
            { Stat.SIL, 8 },
            { Stat.DTH, 8 },
        };
    }

    public class AggressiveSupporterArcheType : ArcheType
    {
        public override string Name { get { return "Aggressive Supporter"; } }

        public override bool Block { get { return false; } }

        protected override IDictionary<Stat, double> Resistances { get { return _resistances; } }

        protected override IDictionary<Stat, Pair<double, double>> Stats { get { return _stats; } }

        private readonly IDictionary<Stat, Pair<double, double>> _stats = new Dictionary<Stat, Pair<double, double>>
        {
            { Stat.HP, new Pair<double, double>(86, 12) },
            { Stat.MP, new Pair<double, double>(200, 0) },
            { Stat.AD, new Pair<double, double>(60, 11) },
            { Stat.MD, new Pair<double, double>(60, 11) },
            { Stat.DEF, new Pair<double, double>(30, 5) },
            { Stat.MR, new Pair<double, double>(30, 5) },
            { Stat.EVA, new Pair<double, double>(2, 1) },
            { Stat.SPD, new Pair<double, double>(100, 7) },
            { Stat.CHA, new Pair<double, double>(50, 10) },
        };

        private readonly IDictionary<Stat, double> _resistances = new Dictionary<Stat, double>
        {
            { Stat.PSN, 0 },
            { Stat.PAR, 12 },
            { Stat.SIL, 35 },
            { Stat.DTH, 35 },
        };
    }

    public class DefensiveSupporterArcheType : ArcheType
    {
        public override string Name { get { return "Defensive Supporter"; } }

        public override bool Block { get { return false; } }

        protected override IDictionary<Stat, double> Resistances { get { return _resistances; } }

        protected override IDictionary<Stat, Pair<double, double>> Stats { get { return _stats; } }

        private readonly IDictionary<Stat, Pair<double, double>> _stats = new Dictionary<Stat, Pair<double, double>>
        {
            { Stat.HP, new Pair<double, double>(160, 16) },
            { Stat.MP, new Pair<double, double>(200, 0) },
            { Stat.AD, new Pair<double, double>(40, 8) },
            { Stat.MD, new Pair<double, double>(40, 8) },
            { Stat.DEF, new Pair<double, double>(70, 12) },
            { Stat.MR, new Pair<double, double>(70, 12) },
            { Stat.EVA, new Pair<double, double>(2, 1) },
            { Stat.SPD, new Pair<double, double>(100, 10) },
            { Stat.CHA, new Pair<double, double>(80, 20) },
        };

        private readonly IDictionary<Stat, double> _resistances = new Dictionary<Stat, double>
        {
            { Stat.PSN, 16 },
            { Stat.PAR, 16 },
            { Stat.SIL, 16 },
            { Stat.DTH, 16 },
        };
    }
}