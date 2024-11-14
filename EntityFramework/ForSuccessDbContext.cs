using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    public class ForSuccessDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ForSuccessDbContext(DbContextOptions options) : base(options)
        {
        }

        // 데이터베이스와 매핑되는 엔티티의 구성을 정의, 데이터베이스 스키마 설정 등에 사용
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
