namespace MaxonEventManagement.Extensions
{
    public static class Policies
    {
        public static WebApplicationBuilder AddAdminPolicy(this WebApplicationBuilder builder)
        {

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", options =>
                {
                    options.RequireAuthenticatedUser();
                    options.RequireClaim("Roles", "Admin");
                });
            });

            return builder;
        }
    }
}
