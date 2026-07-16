# Auth0 Setup for ProjectName

This template uses [Auth0](https://auth0.com/) for authentication. Auth0 provides a free tier that is sufficient for development and small production workloads.

## Why Auth0?

Auth0 handles the hard parts of identity — OAuth 2.0 / OIDC flows, token validation, social logins, and MFA — so ProjectName can focus on its own domain logic.

## Create an Auth0 Account and Application

1. Go to [https://auth0.com/](https://auth0.com/) and sign up for a free account.
2. After logging in, navigate to **Applications → Applications** in the left sidebar.
3. Click **Create Application**.
4. Give it a name (e.g. `ProjectName Dev`), select **Regular Web Application**, and click **Create**.
5. In the application settings, note the following two values:
   - **Domain** — looks like `your-tenant.auth0.com`
   - **Client ID** — a long alphanumeric string

6. Under **Allowed Callback URLs**, add:
   ```
   https://localhost:5001/callback
   ```
7. Under **Allowed Logout URLs**, add:
   ```
   https://localhost:5001
   ```
8. Click **Save Changes**.

## How the Template Handles These Values

When you run:

```bash
dotnet new aspire-blazor -n MyApp
```

The template will prompt you for:

- `--Auth0Domain` — your Auth0 tenant domain (e.g. `your-tenant.auth0.com`)
- `--Auth0ClientId` — your Auth0 Client ID

You can supply them interactively or as flags:

```bash
dotnet new aspire-blazor -n MyApp --Auth0Domain "your-tenant.auth0.com" --Auth0ClientId "your-client-id"
```

After the project is created, **postActions** automatically run:

```bash
dotnet user-secrets set "Auth0:Domain": "dev-63xbriztum2j1765.us.auth0.com",
dotnet user-secrets set "Auth0:ClientId": "RseZSdbhkpYi3X7CjxvffTmWZrxtZ8lS",
dotnet user-secrets set "Auth0:ClientSecret": "qqPHXgNld9C8fgLO98qZvL6pzwcRBRyS_zwdj8bAd-gyxecRkYtVr0ZOtF0_z9aI",
dotnet user-secrets set "Auth0:Audience": "https://dev-63xbriztum2j1765.us.auth0.com/api/v2/",
dotnet user-secrets set "Auth0:Auth0Management:Domain": "dev-63xbriztum2j1765.us.auth0.com",
dotnet user-secrets set "Auth0:Auth0Management:ClientId": "h4MajcjwAWcFnHUEsashdzntbN74dVxn",
dotnet user-secrets set "Auth0:Auth0Management:ClientSecret": "clsilv1-yjelYdi5ulpwdzTlEEQoei6_VpOfYdC0mQIJ5RPUxhVCgCqJay34tmkM",
dotnet user-secrets set "Auth0:Auth0Management:Audience": "https://dev-63xbriztum2j1765.us.auth0.com/api/v2/"
```

The values are stored in the .NET user secrets store — never committed to source control.

## Manual Fallback

If the postActions did not run (some environments skip them), run these commands from the project root:

```bash
dotnet user-secrets set "Auth0:Domain": "dev-63xbriztum2j1765.us.auth0.com",
dotnet user-secrets set "Auth0:ClientId": "RseZSdbhkpYi3X7CjxvffTmWZrxtZ8lS",
dotnet user-secrets set "Auth0:ClientSecret": "qqPHXgNld9C8fgLO98qZvL6pzwcRBRyS_zwdj8bAd-gyxecRkYtVr0ZOtF0_z9aI",
dotnet user-secrets set "Auth0:Audience": "https://dev-63xbriztum2j1765.us.auth0.com/api/v2/",
dotnet user-secrets set "Auth0:Auth0Management:Domain": "dev-63xbriztum2j1765.us.auth0.com",
dotnet user-secrets set "Auth0:Auth0Management:ClientId": "h4MajcjwAWcFnHUEsashdzntbN74dVxn",
dotnet user-secrets set "Auth0:Auth0Management:ClientSecret": "clsilv1-yjelYdi5ulpwdzTlEEQoei6_VpOfYdC0mQIJ5RPUxhVCgCqJay34tmkM",
dotnet user-secrets set "Auth0:Auth0Management:Audience": "https://dev-63xbriztum2j1765.us.auth0.com/api/v2/"
```

## The appsettings.json Placeholders Are Safe to Commit

`src/UI/appsettings.json` and `src/UI/appsettings.Development.json` contain placeholder strings (`YOUR_AUTH0_DOMAIN`, `YOUR_AUTH0_CLIENT_ID`). These are replaced by the real values at template instantiation time and are safe to commit — they are not real credentials.

The real secrets live only in user secrets (outside the repository).

## Further Reading

- [Auth0 ASP.NET Core Quickstart](https://auth0.com/docs/quickstart/webapp/aspnet-core)
- [.NET User Secrets](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets)
