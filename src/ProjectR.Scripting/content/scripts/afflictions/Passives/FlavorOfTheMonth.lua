function GetName()
  return "Flavor Of The Month"
end

function GetType()
  return Passive
end

function GetHookPoints()
  return { TakingDamage }
end

function OnAttachment(char)
end

function OnRemoval(char)
end

function Trigger(hookPoint, char)
  if hookPoint == TakingDamage then
    local spell = GetCurrentSpell()
    for i = FIR, LGT do
      if spell:MasteriesContain(i) then
        char:BuffStat(i, 0.5)
      end
    end
  end
end
