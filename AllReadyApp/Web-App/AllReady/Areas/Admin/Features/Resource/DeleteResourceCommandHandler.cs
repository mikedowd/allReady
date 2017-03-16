﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllReady.Areas.Admin.Features.Events;
using AllReady.Extensions;
using AllReady.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AllReady.Areas.Admin.Features.Resource
{
    public class DeleteResourceCommandHandler : AsyncRequestHandler<DeleteResourceCommand>
    {
        private AllReadyContext _context;

        public DeleteResourceCommandHandler(AllReadyContext context)
        {
            _context = context;
        }

        protected override async Task HandleCore(DeleteResourceCommand message)
        {
            var resource = _context.Resources.Single(r => r.Id == message.ResourceId);
            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();
        }
    }
}
