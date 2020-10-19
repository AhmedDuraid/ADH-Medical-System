using ADHApi.CoustomProvider;
using ADHDataManager.Library.DataAccess;
using ADHDataManager.Library.DataAccess.AuthDataAccess;
using ADHDataManager.Library.Internal.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace ADHApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddDefaultTokenProviders();
            services.AddTransient<IUserStore<ApplicationUser>, CustomUserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, CustomRoleStore>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.User.RequireUniqueEmail = true;
            });

            // Personal Services

            services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            services.AddTransient<IRoleData, RoleData>();
            services.AddTransient<IUserRoleData, UserRoleData>();
            services.AddTransient<IAccountData, AccountData>();
            services.AddTransient<IUserData, UserData>();
            services.AddTransient<IArticleData, ArticleData>();
            services.AddTransient<IAssignedMedicineData, AssignedMedicineData>();
            services.AddTransient<IAssignedPlanData, AssignedPlanData>();
            services.AddTransient<IFeedbackData, FeedbackData>();
            services.AddTransient<ILabTestData, LabTestData>();
            services.AddTransient<ILabTestRequestsData, LabTestRequestsData>();
            services.AddTransient<IMedicineData, MedicineData>();
            services.AddTransient<IPatientData, PatientData>();
            services.AddTransient<IPatientNoteData, PatientNoteData>();
            services.AddTransient<IPatientProgressData, PatientProgressData>();
            services.AddTransient<IPlanData, PlanData>();



            //token services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", jwtoptions =>
            {

                jwtoptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Secrets:SecurityKey"))),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };

            });

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "ADH Api",
                        Version = "v1"
                    }
                    );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "ADH Api v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
