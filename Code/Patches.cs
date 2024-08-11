﻿using ai;
using ai.behaviours;
using HarmonyLib;
using NeoModLoader.General;
using ReflectionUtility;
using System.Collections.Generic;
using UnityEngine;
//Harmony Patches
namespace GodsAndPantheons
{
    [HarmonyPatch(typeof(BaseSimObject), "canAttackTarget")]
    public class UpdateAttacking
    {
        static void Postfix(ref bool __result, BaseSimObject __instance, BaseSimObject pTarget)
        {
            if (__instance == pTarget)
            {
                __result = false;
            }
            if (__instance.isActor())
            {
                Actor a = __instance.a;
                if (a.hasTrait("Summoned One"))
                {
                    Actor Master = Traits.FindMaster(a);
                    if (Master != null)
                    {
                        if (!Master.canAttackTarget(pTarget))
                        {
                            __result = false;
                            return;
                        }
                    }
                }
            }
            if (pTarget.isActor())
            {
                Actor b = pTarget.a;
                if (b.hasTrait("Summoned One"))
                {
                    Actor Master = Traits.FindMaster(b);
                    if (Master != null)
                    {
                        if (!__instance.canAttackTarget(Master))
                            __result = false;
                    }
                }
            }
        }
    }
    [HarmonyPatch(typeof(ActorBase), "clearAttackTarget")]
    public class KEEPATTACKING
    {
        static bool Prefix(ActorBase __instance)
        {
            if (__instance.hasTrait("God Hunter") && Main.savedSettings.HunterAssasins)
            {
                BaseSimObject? a = Reflection.GetField(typeof(ActorBase), __instance, "attackTarget") as BaseSimObject;
                if (a != null)
                {
                    if (Traits.IsGod(a.a) && a.isAlive()) { return false; }
                }
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(Actor), "newKillAction")]
    public class isgodkiller
    {
        static void Prefix(Actor __instance, Actor pDeadUnit)
        {
            if (Traits.IsGod(pDeadUnit))
            {
                __instance.addTrait("God Killer");
            }
        }
    }
    [HarmonyPatch(typeof(CityBehProduceUnit), "checkGreatClan")]
    public class InheritGodTraits
    {
        static void Postfix(Actor pParent1, Actor pParent2)
        {
            if (HavingChild)
            {
                int parents = pParent2 != null ? 2 : 1;
                int godparents = Traits.IsGod(pParent1) ? 1 : 0;
                int demiparents = pParent1.data.traits.Contains("Demi God") ? 1 : 0;
                List<string> parentdata = new List<string>(Traits.getinheritedgodtraits(pParent1.data));
                List<string> godtraits = new List<string>(Traits.GetGodTraits(pParent1));
                if (parents == 2)
                {
                    godtraits.AddRange(Traits.GetGodTraits(pParent2));
                    parentdata.AddRange(Traits.getinheritedgodtraits(pParent2.data));
                    godparents += Traits.IsGod(pParent2) ? 1 : 0;
                    demiparents += pParent2.data.traits.Contains("Demi God") ? 1 : 0;
                }
                if (godparents > 0)
                {
                    if (parents == godparents)
                    {
                        Traits.inheritgodtraits(godtraits, ref Child);
                    }
                    else if (demiparents > 0 && Toolbox.randomChance(0.5f))
                    {
                       Traits.inheritgodtraits(godtraits, ref Child);
                    }
                    else
                    {
                       Traits.MakeDemiGod(godtraits, ref Child);
                    }
                }
                else if (demiparents > 0)
                {
                    if (parents == demiparents)
                    {
                        if (Toolbox.randomChance(0.25f))
                        {
                            Traits.inheritgodtraits(parentdata, ref Child);
                        }
                        else
                        {
                            Traits.MakeDemiGod(parentdata, ref Child);
                        }
                    }
                    else
                    {
                        Traits.AutoTrait(Child, parentdata, true);
                    }
                }
                HavingChild = false;
            }
        }
        public static bool HavingChild = false;
        public static ActorData Child;
    }
    [HarmonyPatch(typeof(ActorData), "inheritTraits")]
    public class ChildData
    {
        static void Postfix(ActorData __instance, List<string> pTraits)
        {
            if (!InheritGodTraits.HavingChild && Traits.GetGodTraits(pTraits, true).Count > 0)
            {
                InheritGodTraits.Child = __instance;
                InheritGodTraits.HavingChild = true;
            }
        }
    }
    [HarmonyPatch(typeof(ActorBase), "calculateFertility")]
    public class UseDemiStats
    {
        static void Postfix(ActorBase __instance)
        {
            if (__instance.hasTrait("Demi God"))
            {
                mergeStats(Traits.GetDemiStats(__instance.data), ref __instance.stats);
            }
        }
        static void mergeStats(List<KeyValuePair<string, float>> pStats, ref BaseStats __instance)
        {
            for (int i = 0; i < pStats.Count; i++)
            {
                __instance[pStats[i].Key] += pStats[i].Value;
            }
        }
    }
    [HarmonyPatch(typeof(Actor), "takeItems")]
    public class DontTakeScytheIfGod
    {
       static bool Prefix(Actor __instance, Actor pActor) => !(Traits.IsGod(__instance) && pActor.hasTrait("God Hunter"));
    }
}
