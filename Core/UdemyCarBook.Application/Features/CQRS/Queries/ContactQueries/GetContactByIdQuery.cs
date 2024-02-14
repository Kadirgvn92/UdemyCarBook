﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;
public class GetContactByIdQuery
{
    public GetContactByIdQuery(int id)
    {
        this.id = id;
    }

    public int id { get; set; }
}
