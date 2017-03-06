﻿using System;
using System.Threading.Tasks;
using ArkBot.Data;
using System.Collections.Generic;

namespace ArkBot
{
    public interface IArkContext: IDisposable
    {
        IProgress<string> Progress { get; }
        TimeSpan? ApproxTimeUntilNextUpdate { get; }
        ArkSpeciesStatsData ArkSpeciesStatsData { get; set; }
        CreatureClass[] Classes { get; }
        Cluster Cluster { get; }
        Creature[] Creatures { get; }
        IEnumerable<Creature> CreaturesNoRaft { get; }
        Creature[] Wild { get; }
        DateTime LastUpdate { get; }
        Player[] Players { get; }
        ArkSpeciesAliases SpeciesAliases { get; set; }
        Tribe[] Tribes { get; }
        Task Initialize(ArkSpeciesAliases aliases = null);
        double? CalculateMaxStat(ArkSpeciesStatsData.Stat stat, string speciesNameOrClass, int? wildLevelStat, int? tamedLevelStat, decimal? imprintingQuality, decimal? tamedIneffectivenessModifier);
        string GetElevationAsText(decimal z);
        event ArkContext.ContextUpdated Updated;
        void DebugTriggerOnChange();
    }
}