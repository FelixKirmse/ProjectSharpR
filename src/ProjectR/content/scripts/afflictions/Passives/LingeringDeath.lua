function GetName()
  return "Lingering Death"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { Attacking }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == Attacking and param2:GetSpellType() == Physical and Roll(0, 99) < 10 then
    local wisp = SummonMinionCopyAmongEnemy(char, "Lingering Death")
    wisp:ClearSpells()
    wisp:AddSpell("Lingering Death")
    wisp:ApplyAffliction("Clearcasting")
    wisp:ApplyAffliction("Certain Death")
    wisp:SetVar("death_counter", 3)
  end
end
