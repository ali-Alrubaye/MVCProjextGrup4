using System.Data.Entity;
using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1
{
    public class TestContext : DbContext
    {
        public TestContext():base("TestContext")
        {
            //SetInitializer<TestContext>(new DropCreateDatabaseIfModelChanges<TestContext>());
        }
        public DbSet<OrderApart> OrderDataModels { get; set; }
        public DbSet<ApartmentData> AppartmentDataModels { get; set; }
        public DbSet<ApartmentPhotoData> ApartmentPhotoDataModels { get; set; }
        public DbSet<AreaData> AreaDataModels { get; set; }
        public DbSet<FeaturesData> FeatuersDataModels { get; set; }
        public DbSet<FormHousingData> FormHousingDataModels { get; set; }
        public DbSet<SizeData> SizeDataModels { get; set; }
        public DbSet<UserData> UserDatagDataModels { get; set; }
        

        //protected void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    CreateMap<ApartmentData, AdressData>()
        //        .ForMember(dto => dto.ApartmentId, opt => opt.MapFrom(src => src.ApartmentAdressM));

        //    //modelBuilder.Entity<ApartmentData>()
        //    //    .HasMany(s => s.ApartmentFeatureM)
        //    //    .WithMany(c => c.FeatureApartmentM)
        //    //    .Map(cs =>
        //    //    {
        //    //        cs.MapLeftKey("ApartmentRefId");
        //    //        cs.MapRightKey("FeatureRefId");
        //    //        cs.ToTable("ApartmentFeature");
        //    //    });
        //}
    }

   
}
