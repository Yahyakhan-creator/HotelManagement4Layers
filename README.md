# Hotel Management System (4-Layer Architecture, C#)

A console application written in C# (.NET 8) that manages hotel room bookings.
It is built with a clean 4-layer architecture and saves all data in plain text files (file handling), so no database is needed.

## Features

**Admin** (login with 3 attempts)
- View all bookings
- Search a booking by room number
- Update a booking (name, days, rent)
- Delete a booking
- See the total revenue

**Customer**
- Book a room (a booked room cannot be booked again, maximum 100 bookings)
- View my booking
- Delete my booking
- Update my booking (room and days)
- See my total bill

## Architecture

Calls only go downward: UI -> Logic -> DataAccess -> text file. The Model objects travel between the layers.

| Layer | Files | Job |
|---|---|---|
| 1. Model | `*Model.cs` | Holds the data (private fields and properties) |
| 2. Business Logic | `*Logic.cs` | Rules and decisions, no `Console` code |
| 3. UI | `*UI.cs` | Menus, input and output with `Console` only |
| 4. Data Access | `*DataAccess.cs` | Reads and writes the text files |

## Project structure

```
HotelManagement4Layers
|-- Program.cs                 main menu (starting point)
|-- Person/
|   `-- PersonModel.cs         base class (Name)
|-- Admin/
|   |-- AdminModel.cs          Admin : Person
|   |-- AdminLogic.cs          login rule
|   |-- AdminDataAccess.cs     reads admin.txt
|   `-- AdminUI.cs             admin login and admin menu
|-- Customer/
|   |-- CustomerModel.cs       Customer : Person
|   `-- CustomerUI.cs          customer menu
`-- Booking/
    |-- BookingModel.cs        a booking (room, customer, days, rent)
    |-- BookingLogic.cs        booking rules, bill, revenue
    |-- BookingDataAccess.cs   reads and writes bookings.txt
    `-- BookingUI.cs           booking screens
```

## How the layers are connected

Each class creates the object of the layer below it:

```
Program     -> AdminUI, CustomerUI
AdminUI     -> AdminLogic, BookingUI
CustomerUI  -> BookingUI
BookingUI   -> BookingLogic
AdminLogic  -> AdminDataAccess
BookingLogic-> BookingDataAccess
```

## File handling

The files are created automatically next to the program (`bin/Debug/net8.0/`) the first time it runs.

| File | Format (one line per record) | Example |
|---|---|---|
| `bookings.txt` | `room\|name\|days\|rent\|booked` | `101\|Ali\|2\|2000\|True` |
| `admin.txt` | `username\|password` | `admin\|1234` |

On the first run, `bookings.txt` is filled with 3 sample bookings.
To start fresh, delete the `.txt` files.

## Default admin login

```
username: admin
password: 1234
```

## How to run

You need the [.NET 8 SDK](https://dotnet.microsoft.com/download) (or newer).

```
git clone https://github.com/Yahyakhan-creator/HotelManagement4Layers.git
cd HotelManagement4Layers
dotnet run
```

Or open `HotelManagement.sln` in Visual Studio and press F5.

## Concepts used

Classes and objects, encapsulation (private fields with properties), inheritance (`: Person`, `: base(...)`), constructors, method overriding (`ToString`), composition (a Booking has a Customer), `List<T>`, file handling (`File`, `Path`), and the 4-layer architecture.
