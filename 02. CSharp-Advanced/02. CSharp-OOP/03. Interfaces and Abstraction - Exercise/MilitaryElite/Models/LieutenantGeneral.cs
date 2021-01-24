﻿using MilitaryElite.Interfaces;
using System.Collections.Generic;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary, ICollection<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public ICollection<IPrivate> Privates { get; }
    }
}
