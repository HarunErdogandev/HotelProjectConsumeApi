using FluentValidation;
using FluentValidation.AspNetCore;
using Hotel.ProjectDataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;


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
            //builder.Services.AddMvc(config =>
            //{
            //    // Yetkilendirme politikasý oluþturuyoruz ,   kimlik doðrulamasý gerekir, inþa et
            //    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //    config.Filters.Add(new AuthorizeFilter(policy));

            //});
            //builder.Services.ConfigureApplicationCookie(opt =>
            //{
            //    opt.Cookie.HttpOnly = true;
            //    opt.ExpireTimeSpan = TimeSpan.FromMinutes(1);
            //    opt.LoginPath = "/Login/Index";
            //});


            builder.Services.AddControllersWithViews().AddFluentValidation();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index}/{id?}");

            app.Run();
        }
    }
}