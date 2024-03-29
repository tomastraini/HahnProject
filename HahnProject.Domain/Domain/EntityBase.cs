﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EntityBase.cs" company="contentedcoder.com">
//   contentedcoder.com
// </copyright>
// <summary>
//   The base class for domain entities.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HahnProject.Infrastructure;
using System;

namespace BB.SmsQuiz.Infrastructure.Domain
{
    public abstract class EntityBase 
    {
        public readonly Context ctx = new Context();
    }
}