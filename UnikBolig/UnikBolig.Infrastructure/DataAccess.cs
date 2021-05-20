using System;
using Microsoft.EntityFrameworkCore;
using UnikBolig.Models;

namespace UnikBolig.DataAccess
{
    public class DataAccess : DbContext, IDataAccess
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TokenModel> Tokens { get; set; }
        public DbSet<EstateModel> Estates { get; set; }
        public DbSet<EstateRulesetModel> Rulesets { get; set; }

        public DbSet<UserDetailModel> UserDetails { get; set; }
        public DbSet<WaitingList> WaitingList { get; set; }

        public DataAccess(DbContextOptions<DataAccess> access) : base(access)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UnikBolig;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        void IDataAccess.SaveChanges()
        {
            try
            {
                this.SaveChanges();
            }catch(DbUpdateConcurrencyException)
            {
                throw new Exception("Values were updated elsewhere, please reload and try again");
            }
        }
    }
}
