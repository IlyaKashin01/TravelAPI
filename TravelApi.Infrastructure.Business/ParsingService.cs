using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TravelApi.Common.OperationResult;
using TravelApi.Services.Interfaces.DTO.Parsing;
using TravelApi.Services.Interfaces.Interfaces;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TravelApi.Infrastructure.Business
{
    public class ParsingService : IParsingService
    {
        
        public Task<OperationResult<IEnumerable<Flight>>> ParseFlightsYandexAsync(ParamsAviaTickets request)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://travel.yandex.ru/avia/");

            var clear = driver.FindElement(By.CssSelector("div[class='_3Tq3s QDUng']"));
            clear.Click();

            var departureCityInput = driver.FindElement(By.CssSelector("input[class='w_eHd input_center']"));
            departureCityInput.Click();
            Thread.Sleep(500);
            departureCityInput.Clear();
            departureCityInput.SendKeys(request.WhereFrom);

            var arrivalCityInput = driver.FindElement(By.CssSelector("input[class='w_eHd input_center']"));
            arrivalCityInput.Click();
            Thread.Sleep(500);
            arrivalCityInput.Clear();
            arrivalCityInput.SendKeys(request.Where);

            var date = driver.FindElement(By.CssSelector("div[class='XLV3x']"));
            date.Click();

            var months = driver.FindElements(By.CssSelector("div[class='_3Tq3s pmUrk']"));
            months.FirstOrDefault(x => x.Text == "Сентябрь")!.Click();

            Thread.Sleep(500);
            var monthNumbers = driver.FindElements(By.CssSelector("div[class='PFU5n TqyF6']"));
            var nameMonth = request.MonthFrom;
            var state = false; 
            restart:
            foreach (var month in monthNumbers)
            {
                var div = month.FindElement(By.CssSelector("div[class='mToLv']"));
                if (div.Text == nameMonth)
                {
                    var days = month.FindElements(By.TagName("span"));
                    foreach (var day in days)
                    {
                        if (!state)
                            if (day.Text == request.DayFrom)
                            {
                                day.Click();
                                months.FirstOrDefault(x => x.Text == request.MonthAnd)!.Click();
                                Thread.Sleep(500);
                                monthNumbers = driver.FindElements(By.CssSelector("div[class='PFU5n TqyF6']"));
                                nameMonth = request.MonthAnd;
                                state = true;
                                goto restart;
                            }
                        if(state)
                            if (day.Text == request.DayAnd)
                            {
                                day.Click();
                                goto sendForm;
                            }
                    }
                }
            }
            sendForm:
            var passangers = driver.FindElement(By.ClassName("NVrJX"));
            passangers.Click();
            var search = driver.FindElement(By.ClassName("z8gtM"));
            search.Click();
            Thread.Sleep(45000);

            var flights = new List<Flight>();
            
            var tickets = driver.FindElements(By.CssSelector("div[class='EhCXF k1OFp']"));
            var key = 1;
            foreach (var ticket in tickets)
            {
                var flight = new Flight();
                var items = ticket.FindElements(By.CssSelector("div[class='EhCXF oGe6o k1OFp']"));
                foreach (var item in items)
                {
                    flight.Id = key;
                    var airline = item.FindElement(By.CssSelector("span[class='_1m7jk TQ2-5 b9-76']")).Text == "прямой" ? 
                        ticket.FindElement(By.CssSelector("div[class='EhCXF uCNy4 zDZzf']")).FindElement(By.CssSelector("span[class='_1m7jk TQ2-5 b9-76']")) :
                        item.FindElement(By.CssSelector("span[class='_1m7jk TQ2-5 b9-76']"));
                    if (item == items.First())
                    {
                        flight.FromAirline = airline.Text;
                        flight.FromDepartureTime = item.FindElement(By.CssSelector("span[class='tKp9d BUBpx PwvPC b9-76']")).Text;
                        flight.FromArrivalTime = item.FindElement(By.CssSelector("span[class='BUBpx PwvPC b9-76']")).Text;
                        flight.FromTimeline = item.FindElement(By.CssSelector("span[class='VIfp0 _1m7jk TQ2-5 dNANh']")).Text;
                        var airports = item.FindElements(By.CssSelector("div[class='_dhHj _1m7jk TQ2-5 b9-76']"));
                        flight.FromDepartureAirport = airports.First().Text;
                        flight.FromArrivalAirport = airports.Last().Text;
                        flight.FromTypeFlight = item.FindElement(By.CssSelector("span[class='WTN66 _1m7jk TQ2-5 dNANh']")).Text;
                    }
                    if (item == items.Last())
                    {
                        flight.BackAirline = airline.Text;
                        flight.BackDepartureTime = item.FindElement(By.CssSelector("span[class='tKp9d BUBpx PwvPC b9-76']")).Text;
                        flight.BackArrivalTime = item.FindElement(By.CssSelector("span[class='BUBpx PwvPC b9-76']")).Text;
                        flight.BackTimeline = item.FindElement(By.CssSelector("span[class='VIfp0 _1m7jk TQ2-5 dNANh']")).Text;
                        var airports = item.FindElements(By.CssSelector("div[class='_dhHj _1m7jk TQ2-5 b9-76']"));
                        flight.BackDepartureAirport = airports.First().Text;
                        flight.BackArrivalAirport = airports.Last().Text;
                        flight.BackTypeFlight = item.FindElement(By.CssSelector("span[class='WTN66 _1m7jk TQ2-5 dNANh']")).Text;
                    }
                }
                key ++;
                flight.Price = ticket.FindElement(By.CssSelector("span[class='bQcBE price IiUVx']")).Text;
                flights.Add(flight);
            }

            return Task.FromResult(new OperationResult<IEnumerable<Flight>>(flights));
        }

        public Task<OperationResult<IEnumerable<Hotel>>> ParseHotelsYandexAsync(ParamsHotels request)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://travel.yandex.ru");

            var inputPlace = driver.FindElement(By.ClassName("input_center"));
            inputPlace.Click();
            inputPlace.SendKeys(request.City);

            var date = driver.FindElement(By.CssSelector("div[class='XLV3x']"));
            date.Click();

            var months = driver.FindElements(By.CssSelector("div[class='_3Tq3s pmUrk']"));
            months.FirstOrDefault(x => x.Text == request.NameMonthFrom)!.Click();

            Thread.Sleep(500);
            var monthNumbers = driver.FindElements(By.CssSelector("div[class='PFU5n TqyF6']"));
            var nameMonth = request.NameMonthFrom;
            var state = false;
        restart:
            foreach (var month in monthNumbers)
            {
                var div = month.FindElement(By.CssSelector("div[class='mToLv']"));
                if (div.Text == nameMonth)
                {
                    var days = month.FindElements(By.TagName("span"));
                    foreach (var day in days)
                    {
                        if(!state)
                            if (day.Text == request.DayFrom)
                            {
                                day.Click();
                                months.FirstOrDefault(x => x.Text == request.NameMonthAnd)!.Click();
                                Thread.Sleep(500);
                                monthNumbers = driver.FindElements(By.CssSelector("div[class='PFU5n TqyF6']"));
                                nameMonth = request.NameMonthAnd;
                                state = true;
                                goto restart;
                            }
                        if(state)
                        if (day.Text == request.DayAnd)
                        {
                            day.Click();
                            goto sendForm;
                        }
                    }
                }
            }
        sendForm:
            var persons = driver.FindElement(By.ClassName("NVrJX"));
            persons.Click();
            var countPersons = driver.FindElement(By.ClassName("Ym9Jl"));
            var search = driver.FindElement(By.ClassName("z8gtM"));
            if (Int32.Parse(countPersons.Text) == request.CountPersons)
            {
                search.Click();
            }
            else if(Int32.Parse(countPersons.Text) < request.CountPersons)
            {
                for (int i = 1; i <= request.CountPersons - Int32.Parse(countPersons.Text); i++)
                    driver.FindElements(By.ClassName("_18Bed")).Last().Click();
                search.Click();
            }
            else if (Int32.Parse(countPersons.Text) > request.CountPersons)
            {
                for (int i = 1; i <= Int32.Parse(countPersons.Text) - request.CountPersons; i++)
                    driver.FindElements(By.ClassName("_18Bed")).First().Click();
                search.Click();
            }
            Thread.Sleep(45000);
            var hotels = new List<Hotel>();
            var items = driver.FindElements(By.ClassName("NDSPt"));
            foreach(var item in items)
            {
                var hotel = new Hotel();
                hotel.Name = item.FindElement(By.CssSelector("a[class='Link Link_theme_normal Link_view_default STEEy Y_QIb Link_lego KlhYG']")).Text;
                //hotel.CountStars = item.FindElement(By.ClassName("PqUjy")).Text;
                hotel.Type = item.FindElement(By.CssSelector("span[class='Ei8Gm']")).Text;
                //hotel.Position = item.FindElement(By.CssSelector("div[class='diui0 KFllc dTWYX']")).FindElement(By.CssSelector("span[class='G7iZ5']")).Text;
                var tags = item.FindElements(By.CssSelector("p[class='bryzW']"));
                foreach (var tag in tags) hotel.Tags.Add(tag.Text);
                hotel.Price = item.FindElement(By.CssSelector("span[class='bQcBE PotX_']")).Text;
                hotel.CountNights = item.FindElement(By.CssSelector("div[class='rs5NW']")).Text;
                var images = item.FindElements(By.CssSelector("img[class='cRpSH oRzfW']"));
                foreach (var image in images) hotel.SrcImages.Add(image.GetAttribute("src"));
                hotels.Add(hotel);
            }
            return Task.FromResult(new OperationResult<IEnumerable<Hotel>>(hotels));
        }
    }
}
