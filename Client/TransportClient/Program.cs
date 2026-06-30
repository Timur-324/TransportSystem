using TransportClient.Models;
using TransportClient.Services;

var api = new ApiClient();

while (true)
{
    ShowMenu();

    Console.Write("Choose: ");
    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                await AddDriver(api);
                break;

            case "2":
                await ShowDrivers(api);
                break;

            case "3":
                await AddTransport(api);
                break;

            case "4":
                await ShowTransports(api);
                break;

            case "5":
                await AddRepair(api);
                break;

            case "6":
                await ShowRepairs(api);
                break;

            case "0":
                return;

            default:
                Console.WriteLine("Unknown option");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERROR: {ex.Message}");
    }
}






static void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("=== TRANSPORT SYSTEM CLIENT ===");
    Console.WriteLine("1. Add driver");
    Console.WriteLine("2. Show drivers");
    Console.WriteLine("3. Add transport");
    Console.WriteLine("4. Show transports");
    Console.WriteLine("5. Add repair");
    Console.WriteLine("6. Show repairs");
    Console.WriteLine("0. Exit");
}

static async Task AddDriver(ApiClient api)
{
    Console.Write("Full name: ");
    var name = Console.ReadLine() ?? "";

    Console.Write("Experience years: ");
    if (!int.TryParse(Console.ReadLine(), out var exp))
    {
        Console.WriteLine("Invalid number");
        return;
    }

    Console.Write("License number: ");
    var license = Console.ReadLine() ?? "";

    var driver = new Driver
    {
        FullName = name,
        ExperienceYears = exp,
        LicenseNumber = license
    };

    await api.AddDriver(driver);

    Console.WriteLine("Driver added!");
}

static async Task ShowDrivers(ApiClient api)
{
    var drivers = await api.GetDrivers();

    Console.WriteLine("\n--- DRIVERS ---");

    foreach (var d in drivers)
    {
        Console.WriteLine($"{d.Id}. {d.FullName} | {d.ExperienceYears} years | {d.LicenseNumber}");
    }
}

static async Task AddTransport(ApiClient api)
{
    Console.Write("Number plate: ");
    var plate = Console.ReadLine() ?? "";

    Console.Write("Type: ");
    var type = Console.ReadLine() ?? "";

    Console.Write("Is active (true/false): ");

    if (!bool.TryParse(Console.ReadLine(), out var active))
    {
        Console.WriteLine("Invalid boolean");
        return;
    }

    var transport = new Transport
    {
        NumberPlate = plate,
        Type = type,
        IsActive = active
    };

    await api.AddTransport(transport);

    Console.WriteLine("Transport added!");
}

static async Task ShowTransports(ApiClient api)
{
    var transports = await api.GetTransports();

    Console.WriteLine("\n--- TRANSPORTS ---");

    foreach (var t in transports)
    {
        Console.WriteLine($"{t.Id}. {t.NumberPlate} | {t.Type} | Active: {t.IsActive}");
    }
}

static async Task AddRepair(ApiClient api)
{
    Console.Write("TransportId: ");

    if (!int.TryParse(Console.ReadLine(), out var transportId))
    {
        Console.WriteLine("Invalid id");
        return;
    }

    Console.Write("Description: ");
    var description = Console.ReadLine() ?? "";

    Console.Write("Cost: ");

    if (!decimal.TryParse(Console.ReadLine(), out var cost))
    {
        Console.WriteLine("Invalid cost");
        return;
    }

    var repair = new Repair
    {
        TransportId = transportId,
        Description = description,
        Cost = cost,
        Date = DateTime.UtcNow
    };

    await api.AddRepair(repair);

    Console.WriteLine("Repair added!");
}

static async Task ShowRepairs(ApiClient api)
{
    var repairs = await api.GetRepairs();

    Console.WriteLine("\n--- REPAIRS ---");

    foreach (var r in repairs)
    {
        Console.WriteLine($"{r.Id}. {r.Description} | {r.Cost} | {r.Date}");
    }
}