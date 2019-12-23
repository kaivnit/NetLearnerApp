﻿using Microsoft.EntityFrameworkCore;
using NetLearner.SharedLib.Data;
using NetLearner.SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetLearner.SharedLib.Services
{
    public class LearningResourceService : ILearningResourceService
    {
        private readonly LibDbContext _context;

        public LearningResourceService(LibDbContext context)
        {
            _context = context;
        }

        public async Task<LearningResource> Add(LearningResource learningResource)
        {
            _context.LearningResources.Add(learningResource);
            await _context.SaveChangesAsync();
            return learningResource;
        }

        public async Task<LearningResource> Delete(int id)
        {
            var learningResource = await _context.LearningResources.FindAsync(id);
            _context.LearningResources.Remove(learningResource);
            await _context.SaveChangesAsync();
            return learningResource;
        }

        public async Task<List<LearningResource>> Get()
        {
            return await _context.LearningResources.ToListAsync();
        }

        public async Task<LearningResource> Get(int id)
        {
            var learningResource = await _context.LearningResources.FindAsync(id);
            return learningResource;
        }

        public async Task<LearningResource> Update(LearningResource learningResource)
        {
            _context.Entry(learningResource).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return learningResource;
        }
    }
}