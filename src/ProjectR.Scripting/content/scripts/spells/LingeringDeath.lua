function GetTargetType()
    return Allies
end

function GetName()
  return "Lingering Death"
end

function GetDescription()
    return "Spread a deadly disease to your allies.\nReduces EVA, DEF, MR & SPD.\nCan also inflict PAR, PSN and DTH."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 0
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Magical
end

function GetMasteries()
  return { DRK }
end

function SpellEffect()
  d:ApplyDebuff(DTH, 30)

  d:ApplyDebuff(PSN, 45)
  d:ApplyDebuff(PAR, 30)

  d:BuffStat(EVA, -.25)
  d:BuffStat(DEF, -.25)
  d:BuffStat(MR, -.25)
  d:BuffStat(SPD, -.25)
end
