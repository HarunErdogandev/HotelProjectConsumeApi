using FluentValidation;
using FluentValidation.AspNetCore;
using Hotel.ProjectDataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;


namespace HotelProject.WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();
            
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddHttpClient();
            builder.Services.AddTransient<IValidator<CreateGuestDto>, GuestCreateValidator>();
            builder.Services.AddTransient<IValidator<UpdateGuestDto>, UpdateGuestValidator>();



            builder.Services.AddControllersWithViews().AddFluentValidation();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}