using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
new DriverManager().SetUpDriver(new ChromeConfig());
var options = new ChromeOptions();
var driver = new ChromeDriver(options);
driver.Navigate().GoToUrl("https://www.instagram.com/");
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(6000);
var usernamebox = driver.FindElement(By.Name("username"));
var password = driver.FindElement(By.Name("password"));
Console.WriteLine("Enter Instagram Username : ");
var username = Console.ReadLine();
Console.WriteLine("Enter Instagram Password : ");
var pass = Console.ReadLine();
usernamebox.SendKeys(username);
password.SendKeys(pass);
var btn = driver.FindElement(By.ClassName("sqdOP"));
btn.Submit();
try
{
    var error = driver.FindElement(By.Id("slfErrorAlert"));
    if (error != null)
    {
        Console.WriteLine(error.Text);
        Console.ReadKey();
    }

}
catch (Exception)
{
   
}
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);
if (driver.Url == "https://www.instagram.com/accounts/login/two_factor?next=%2F")
{
    var aoth = driver.FindElement(By.ClassName("_2hvTZ"));
    Console.WriteLine(driver.FindElement(By.Id("verificationCodeDescription")).Text);
    aoth.SendKeys(Console.ReadLine());
    var confirm = driver.FindElement(By.ClassName("sqdOP"));
    confirm.Submit();
    //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(2000);
    if (driver.Url.Contains($"https://www.instagram.com/{username}")){
        Console.WriteLine($"{username} page now is accessable");
    }
}
//driver.Quit(); 
Console.ReadKey();
