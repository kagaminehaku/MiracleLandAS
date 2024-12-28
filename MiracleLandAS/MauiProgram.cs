using Microsoft.Extensions.Logging;
using MiracleLandAS.Services;
namespace MiracleLandAS
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("http://kagaminehaku.softether.net:25565/") });
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<RegisterService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<AccountService>();
            builder.Services.AddSingleton<CsProductsService>();
            builder.Services.AddSingleton<CsShoppingCartService>();
            builder.Services.AddSingleton<OrderService>();
            builder.Services.AddSingleton<UserManager>();
            builder.Services.AddSingleton<AdminProductsService>();
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
