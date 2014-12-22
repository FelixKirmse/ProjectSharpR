function GetName()
  return "Minion"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return {  }
end

function OnAttachment(char)
  local stats = GetStats(char)
  local hpStat = stats:GetSingleStat(HP)
  local baseHP = hpStat:Get(Base)
  baseHP = baseHP * 0.3
  hpStat:Set(Base, baseHP)

  for i = AD, MR do
    local stat = stats:GetSingleStat(i)
    local baseStat = stat:Get(Base)
    baseStat = baseStat * 0.5
    stat:Set(Base, baseStat)
  end

  char:Heal(char:GetMaxHP())
end

function OnRemoval(char)
  local stats = GetStats(char)
  local hpStat = stats:GetSingleStat(HP)
  local baseHP = hpStat:Get(Base)
  baseHP = baseHP / 0.3
  hpStat:Set(Base, baseHP)

  for i = AD, MR do
    local stat = stats:GetSingleStat(i)
    local baseStat = stat:Get(Base)
    baseStat = baseStat / 0.5
    stat:Set(Base, baseStat)
  end
end

function Trigger(hookPoint, char)
end
