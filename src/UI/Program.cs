using Auth0.AspNetCore.Authentication;

using UI.Components;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

static bool HasConfiguredAuth0Value(string? value)
{
    return !string.IsNullOrWhiteSpace(value)
           && !value.Trim().StartsWith("YOUR_", StringComparison.OrdinalIgnoreCase);
}

var auth0Domain = builder.Configuration["Auth0:Domain"];
var auth0ClientId = builder.Configuration["Auth0:ClientId"];
var isAuth0Configured = HasConfiguredAuth0Value(auth0Domain) && HasConfiguredAuth0Value(auth0ClientId);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

if (isAuth0Configured)
{
    builder.Services
        .AddAuth0WebAppAuthentication(options =>
        {
            options.Domain = auth0Domain!;
            options.ClientId = auth0ClientId!;
        });
}

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

if (isAuth0Configured)
{
    app.UseAuthentication();
    app.UseAuthorization();
}

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
