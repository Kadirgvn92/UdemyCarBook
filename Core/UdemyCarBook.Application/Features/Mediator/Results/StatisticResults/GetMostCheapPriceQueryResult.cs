﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
public class GetMostCheapPriceQueryResult 
{
    public int Price { get; set; }
}