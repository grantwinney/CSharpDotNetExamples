using RestSharp;
using SwitchPatternMatchingVsIfElse;

var client = new RestClient();
var request = new RestRequest("http://api.open-notify.org/iss-now.json");
var response = await client.GetAsync<IssResponse>(request);

decimal.TryParse(response?.Position.Latitude, out var latitude);
decimal.TryParse(response?.Position.Longitude, out var longitude);



// EXAMPLE 1 - SWITCH/CASE WITH NESTED IF

switch (response?.Message)
{
  case "success":
    if (latitude > 0)
    {
      if (longitude > 0)
        Console.WriteLine("The ISS is over the northern hemisphere, east of the prime meredian.");
      else if (longitude == 0)
        Console.WriteLine("The ISS is over the northern hemisphere, on the prime meredian.");
      else
        Console.WriteLine("The ISS is over the northern hemisphere, west of the prime meredian.");
    }
    else if (latitude == 0)
    {
      if (longitude > 0)
        Console.WriteLine("The ISS is over the equator, east of the prime meredian.");
      else if (longitude == 0)
        Console.WriteLine("The ISS is over the equator, on the prime meredian.");
      else
        Console.WriteLine("The ISS is over the equator, west of the prime meredian.");
    }
    else
    {
      if (longitude > 0)
        Console.WriteLine("The ISS is over the southern hemisphere, east of the prime meredian.");
      else if (longitude == 0)
        Console.WriteLine("The ISS is over the southern hemisphere, on the prime meredian.");
      else
        Console.WriteLine("The ISS is over the southern hemisphere, west of the prime meredian.");
    }
    break;

  default:
    Console.WriteLine(@" ¯\_(ツ)_/¯ ");
    break;
}


// EXAMPLE 2 - NESTED SWITCH/CASES (not enough by itself)

switch (response?.Message)
{
  case "success":
    {
      switch (latitude)
      {
        case 0:   // What about greater or less than 0?
          break;
        default:  // This would catch greater AND less than 0...
          break;
      }
      // etc, etc...
    }
    break;

  default:
    Console.WriteLine(@" ¯\_(ツ)_/¯ ");
    break;
}


// EXAMPLE 3 - SWITCH/CASE WITH PATTERN MATCHING

switch (response?.Message)
{
  case "success" when latitude > 0 && longitude > 0:
    Console.WriteLine("The ISS is over the northern hemisphere, east of the prime meredian.");
    break;
  case "success" when latitude > 0 && longitude == 0:
    Console.WriteLine("The ISS is over the northern hemisphere, on the prime meredian.");
    break;
  case "success" when latitude > 0 && longitude < 0:
    Console.WriteLine("The ISS is over the northern hemisphere, west of the prime meredian.");
    break;

  // etc, etc...

  default:
    Console.WriteLine(@" ¯\_(ツ)_/¯ ");
    break;
}


// EXAMPLE 4 - SWITCH EXPRESSIONS WITH PATTERN MATCHING

var message = response?.Message switch
{
  "success" when latitude > 0 && longitude > 0 => "The ISS is over the northern hemisphere, east of the prime meredian.",
  "success" when latitude > 0 && longitude == 0 => "The ISS is over the northern hemisphere, on the prime meredian.",
  "success" when latitude > 0 && longitude < 0 => "The ISS is over the northern hemisphere, west of the prime meredian.",
  // and on and on...
  _ => @" ¯\_(ツ)_/¯ "
};

Console.WriteLine(message);


// EXAMPLE 4b - YET ANOTHER EXAMPLE USING PATTERN MATCHING

void RunReport(string userAction, User user)
{
  var d = DateTime.Now;

  var reportToRun = userAction.ToLower() switch
  {
    "sale" => "CustomerPurchase",

    "audit" when user.Position == "manager" || user.Department == "accounting" => "AuditDetail",
    "audit" => "AuditPersonal",

    "timecard" when user.Department == "hr" => "CorporateSchedule",
    "timecard" when d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday => "OvertimeSchedule",
    "timecard" => "Schedule",

    "support" when user.Position == "lead" => "DailySupportTickets",
    "support" when user.Position == "softwaredeveloper" => "SupportTicketDetail",
    "support" => "SupportTicketSummary",
  };

  // ExecuteReport(reportToRun);
}


// EXAMPLE 5 - SMARTER?

var latMsg = latitude > 0 ? "northern hemisphere" : latitude == 0 ? "equator" : "southern hemisphere";
var lngMsg = longitude > 0 ? "east of" : longitude == 0 ? "on" : "west of";

Console.WriteLine(response?.Message == "success"
    ? $"The ISS is over the {latMsg}, {lngMsg} the prime meridian."
    : " ¯\\_(ツ)_/¯ ");
