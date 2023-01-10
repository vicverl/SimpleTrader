﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services;

public interface IMajorIndexService
{
    Task<MajorIndex> GetMajorIndex(MajorIndexType indexType);
}