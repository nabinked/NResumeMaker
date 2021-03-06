﻿using DbPortal;
using ResumeMaker.Data.Models.Core;

namespace ResumeMaker.Data
{
    public class DbContext
    {
        public DbTransactions<User> User = new DbTransactions<User>();
        public DbTransactions<Education> Education = new DbTransactions<Education>();
        public DbTransactions<Experience> Experience = new DbTransactions<Experience>();
        public DbTransactions<JobDescription> JobDescription = new DbTransactions<JobDescription>();
        public DbTransactions<KeyAccomplishment> KeyAccomplishment = new DbTransactions<KeyAccomplishment>();
        public DbTransactions<ContactDetail> ContactDetail = new DbTransactions<ContactDetail>();
        public DbTransactions<Summary> Summary = new DbTransactions<Summary>();
        public DbTransactions<Objective> Objective = new DbTransactions<Objective>();
        public DbTransactions<PersonalDetail> PersonalDetail = new DbTransactions<PersonalDetail>();
        public DbTransactions<Role> Role = new DbTransactions<Role>();
        public DbTransactions<Skill> Skill = new DbTransactions<Skill>();
    }
}
