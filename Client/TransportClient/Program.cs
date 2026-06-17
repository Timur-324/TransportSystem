using TransportClient.Models;
using TransportClient.Services;

var api = new ApiClient();

while (true)
{
    Console.WriteLine("\n=== TRANSPORT SYSTEM CLIENT ===");
    Console.WriteLine("1. Add driver");
    Console.WriteLine("2. Show drivers");
    Console.WriteLine("3. Add transport");
    Console.WriteLine("4. Show transports");
    Console.WriteLine("5. Add repair");
    Console.WriteLine("6. Show repairs");
    Console.WriteLine("0. Exit");
    Console.Write("Choose: ");

    var choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            // DRIVER
            case "1":
            {
                Console.Write("Full name: ");
                var name = Console.ReadLine() ?? "";

                Console.Write("Experience years: ");
                if (!int.TryParse(Console.ReadLine(), out var exp))
                {
                    Console.WriteLine("Invalid number");
                    break;
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
                break;
            }

            case "2":
            {
                var drivers = await api.GetDrivers();

                Console.WriteLine("\n--- DRIVERS ---");
                foreach (var d in drivers)
                {
                    Console.WriteLine($"{d.Id}. {d.FullName} | {d.ExperienceYears} years | {d.LicenseNumber}");
                }
                break;
            }

            // TRANSPORT
            case "3":
            {
                Console.Write("Number plate: ");
                var plate = Console.ReadLine() ?? "";

                Console.Write("Type: ");
                var type = Console.ReadLine() ?? "";

                Console.Write("Is active (true/false): ");
                if (!bool.TryParse(Console.ReadLine(), out var active))
                {
                    Console.WriteLine("Invalid boolean");
                    break;
                }

                var transport = new Transport
                {
                    NumberPlate = plate,
                    Type = type,
                    IsActive = active
                };

                await api.AddTransport(transport);
                Console.WriteLine("Transport added!");
                break;
            }

            case "4":
            {
                var list = await api.GetTransports();

                Console.WriteLine("\n--- TRANSPORTS ---");
                foreach (var t in list)
                {
                    Console.WriteLine($"{t.Id}. {t.NumberPlate} | {t.Type} | Active: {t.IsActive}");
                }
                break;
            }

            // REPAIR
            case "5":
            {
                Console.Write("TransportId: ");
                if (!int.TryParse(Console.ReadLine(), out var transportId))
                {
                    Console.WriteLine("Invalid id");
                    break;
                }

                Console.Write("Description: ");
                var desc = Console.ReadLine() ?? "";

                Console.Write("Cost: ");
                if (!decimal.TryParse(Console.ReadLine(), out var cost))
                {
                    Console.WriteLine("Invalid cost");
                    break;
                }

                var repair = new Repair
                {
                    TransportId = transportId,
                    Description = desc,
                    Cost = cost,
                    Date = DateTime.UtcNow
                };

                await api.AddRepair(repair);
                Console.WriteLine("Repair added!");
                break;
            }

            case "6":
            {
                var repairs = await api.GetRepairs();

                Console.WriteLine("\n--- REPAIRS ---");
                foreach (var r in repairs)
                {
                    Console.WriteLine($"{r.Id}. {r.Description} | {r.Cost} | {r.Date}");
                }
                break;
            }

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