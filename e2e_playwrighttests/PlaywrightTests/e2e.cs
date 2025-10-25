using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DotNetEnv;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
[Category("E2ETest")]
public class E2eTest : PageTest
{
    /*Run Test with Browser:
    
    dotnet test -- Playwright.BrowserName=chromium Playwright.LaunchOptions.Headless=false Playwright.LaunchOptions.Channel=msedge
    */

    /*For easy tests writing run:

        powershell bin/Debug/net9.0/playwright.ps1 codegen
        or
        pwsh bin/Debug/net9.0/playwright.ps1 codegen
    */

    /*Test Template:
    
        [Test]
        public async Task TestTemplate()
        {
            await Page.GotoAsync("/");
            
        }
    */

    [Test]
    public async Task HasTitle()
    {
        await Page.GotoAsync(Environment.GetEnvironmentVariable("BASEURL"));

        //await Page.GotoAsync("http://localhost:8080");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Fake Personal Data Generator"));
    }

    [Test]
    public async Task PartialCPR()
    {
        await Page.GotoAsync(Environment.GetEnvironmentVariable("BASEURL"));
        //await Page.GotoAsync("http://localhost:8080");

        //Finds Radio and presses it
        await Page.GetByLabel(new Regex("Partial generation:")).CheckAsync();
        await Expect(Page.Locator("#chkPartialOptions")).ToBeCheckedAsync();

        //Finds Dropdown and selects CPR
        await Page.Locator("#cmbPartialOptions").SelectOptionAsync("cpr");
        await Expect(Page.Locator("#cmbPartialOptions")).ToHaveValueAsync("cpr");

        //Finds Generate Button and presses it
        await Page.GetByRole(AriaRole.Button, new() { Name = "Generate" }).ClickAsync();

        //Finds Person Card and checks for CPR value
        var cprValue = Page.Locator(".personCard .cprValue").First;

        //Checks that CPR value is visible and has 10 digits
        await Expect(cprValue).ToBeVisibleAsync();
        await Expect(cprValue).ToHaveTextAsync(new Regex(@"^\d{10}$"));
    }

    [Test]
    public async Task PartialNameGender()
    {
        await Page.GotoAsync(Environment.GetEnvironmentVariable("BASEURL"));
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Partial generation:" }).CheckAsync();
        await Page.Locator("#cmbPartialOptions").SelectOptionAsync(new[] { "name-gender" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Generate" }).ClickAsync();
        await Page.GetByText("First name:").ClickAsync();
        await Page.GetByText("Last name:").ClickAsync();
        await Page.GetByText("Gender:").ClickAsync();
    }

    [Test]
    public async Task PartialNameGenderBirthdate()
    {
        await Page.GotoAsync(Environment.GetEnvironmentVariable("BASEURL"));
        await Page.GetByRole(AriaRole.Radio, new() { Name = "Partial generation:" }).CheckAsync();
        await Page.Locator("#cmbPartialOptions").SelectOptionAsync(new[] { "name-gender-dob" });
        await Page.GetByRole(AriaRole.Button, new() { Name = "Generate" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("First name:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Last name:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Gender:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Date of birth:");
    }

    [Test]
    public async Task PratialCPRNameGender()
    {
        await Page.GotoAsync(Environment.GetEnvironmentVariable("BASEURL"));

        await Page.GetByRole(AriaRole.Radio, new() { Name = "Partial generation:" }).CheckAsync();
        await Page.Locator("#cmbPartialOptions").SelectOptionAsync(new[] { "cpr-name-gender" });

        await Page.GetByRole(AriaRole.Button, new() { Name = "Generate" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("CPR:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("First name:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Last name:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Gender:");
    }

    [Test]
    public async Task PratialCPRNameGenderBirthDate()
    {
        await Page.GotoAsync(Environment.GetEnvironmentVariable("BASEURL"));

        await Page.GetByRole(AriaRole.Radio, new() { Name = "Partial generation:" }).CheckAsync();
        await Page.Locator("#cmbPartialOptions").SelectOptionAsync(new[] { "cpr-name-gender-dob" });

        await Page.GetByRole(AriaRole.Button, new() { Name = "Generate" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("CPR:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("First name:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Last name:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Gender:");
        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Date of birth:");
    }

    [Test]
    public async Task PratialAddress()
    {
        await Page.GotoAsync(Environment.GetEnvironmentVariable("BASEURL"));

        await Page.GetByRole(AriaRole.Radio, new() { Name = "Partial generation:" }).CheckAsync();
        await Page.Locator("#cmbPartialOptions").SelectOptionAsync(new[] { "address" });

        await Page.GetByRole(AriaRole.Button, new() { Name = "Generate" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Address:");
    }

    [Test]
    public async Task PratialPhoneNumber()
    {
        await Page.GotoAsync(Environment.GetEnvironmentVariable("BASEURL"));

        await Page.GetByRole(AriaRole.Radio, new() { Name = "Partial generation:" }).CheckAsync();
        await Page.Locator("#cmbPartialOptions").SelectOptionAsync(new[] { "phone" });

        await Page.GetByRole(AriaRole.Button, new() { Name = "Generate" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Article)).ToContainTextAsync("Phone number:");

        var phoneNumberValue = Page.Locator(".personCard .phoneNumberValue").First;
        await Expect(phoneNumberValue).ToBeVisibleAsync();
        await Expect(phoneNumberValue).ToHaveTextAsync(new Regex(@"^\d{8}$"));
    }

    public override BrowserNewContextOptions ContextOptions()
    {
        Env.TraversePath().Load();

        return new BrowserNewContextOptions
        {
            ColorScheme = ColorScheme.Light,
            ViewportSize = new() { Width = 1280, Height = 720 },
            BaseURL = Environment.GetEnvironmentVariable("BASEURL") ?? "http://localhost:8080/",
        };
    }
}
