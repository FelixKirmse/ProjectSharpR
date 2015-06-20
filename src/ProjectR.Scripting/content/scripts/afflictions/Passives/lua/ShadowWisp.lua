function GetName()
  return "Shadow Wisp"
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
  if hookPoint == Attacking and param2:GetSpellType() == Magical and Roll(0, 99) < 10 then
    local wisp = SummonMinionCopy(char, "Shadow Wisp")
    wisp:ClearSpells()
    wisp:AddSpell(param2:GetName())
    wisp:ApplyAffliction("Clearcasting")
    wisp:ApplyAffliction("Certain Death")
    wisp:SetVar("death_counter", 3)
  end
end
