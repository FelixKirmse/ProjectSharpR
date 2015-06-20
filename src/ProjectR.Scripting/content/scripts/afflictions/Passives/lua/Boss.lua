function GetName()
  return "Boss"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { UsingMP }
end

function OnAttachment(char)
  local stats = GetStats(char)
  local hpStat = stats:GetSingleStat(HP)
  local baseHP = hpStat:Get(Base)
  baseHP = baseHP * 20
  hpStat:Set(Base, baseHP)

  for i = AD, MR do
    local stat = stats:GetSingleStat(i)
    local baseStat = stat:Get(Base)
    baseStat = baseStat * 0.8
    stat:Set(Base, baseStat)
  end

  local dthStat = stats:GetSingleStat(DTH)
  local baseDTH = dthStat:Get(Base)
  baseDTH = baseDTH + 500
  dthStat:Set(Base, baseDTH)

  char:Heal(char:GetMaxHP())
end

function OnRemoval(char)
  local stats = GetStats(char)
  local hpStat = stats:GetSingleStat(HP)
  local baseHP = hpStat:Get(Base)
  baseHP = baseHP / 20
  hpStat:Set(Base, baseHP)

  for i = AD, MR do
    local stat = stats:GetSingleStat(i)
    local baseStat = stat:Get(Base)
    baseStat = baseStat / 0.8
    stat:Set(Base, baseStat)
  end

  local dthStat = stats:GetSingleStat(DTH)
  local baseDTH = dthStat:Get(Base)
  baseDTH = baseDTH - 500
  dthStat:Set(Base, baseDTH)
end

function Trigger(hookPoint, char)
  if hookPoint == UsingMP then
    param1 = 0
  end
end
