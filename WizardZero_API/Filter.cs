﻿using System.Collections.Generic;
using System.Linq;
using WizardZero_API.Models;

namespace WizardZero_API
{
    public static class Filter
    {
        private static readonly List<Rig> Rigs = Data.Rigs;

        public static Rig GetRig(Config config)
        {
            return Rigs.FirstOrDefault(x =>
                x.Price > config.price[0] && x.Price < config.price[1]
                && (int)x.Use == config.use
                && x.Tags.ContainsAllItems(config.tags)
                );
        }

        public static bool ContainsAllItems<T>(this List<T> a, List<T> b)
        {
            return !b.Except(a).Any();
        }
    }
}