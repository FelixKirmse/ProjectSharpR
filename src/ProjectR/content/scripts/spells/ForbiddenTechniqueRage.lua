function GetTargetType()
    return Enemies
end

function GetName()
return "Forbidden Technique: Rage"
end

function GetDescription()
return "Infuse your weapon with arcane and strike all enemies.\nDrops the wait gauge of allies by 15%% for each enemy hit."
end

function IsSupportSpell()
    return false
end

function GetMPCost()
    return 1
end

function GetDelay()
  return .5
end

function GetSpellType()
  return Composite
end

function GetMasteries()
  return { ARC }
end

function SpellEffect()
  local damage = ((3 * aAD + 3 * aMD) * (aARC/100) - (.75 * dDEF + .75 * dMR)) * (100/dARC)
  ForEachAttackerParty("TurnCounterReduce")  
  d:TakeDamage(damage);
end

function TurnCounterReduce(character)
  local turnCounter = character:GetTurnCounter()
  turnCounter = turnCounter * .85
  character:SetTurnCounter(turnCounter)
end
