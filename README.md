# Fragance Tracker Project
Project is made for perfume and fragance enthusiasts to keep track of their existing vault, longetivity and occasion.

* Target Audience: Fragrance enthusiasts and collectors.
* CRUD Functionality: Users can add new perfumes to their digital shelf, edit wear-time notes (longevity, projection), delete bottles they've emptied, and view a dashboard of their collection.

## Project Members:
* Victor Jared Cruz Onato
* Emilio Ernesto Sosa Carrillo

## App Structure
MyBlazorApp/
│
├── Components/
│   ├── Layout/          # MainLayout, NavMenu
│   ├── Pages/           # Routable components (@page "/dashboard")
│   └── Shared/          # Reusable UI pieces (Modals, Custom Inputs)
│
├── Models/              # Data classes and DTOs
│
├── Services/            # Business logic, API clients, or DB access
│
├── wwwroot/             # Static files (CSS, Images, JS)
│
├── _Imports.razor       # Global using directives
└── Program.cs           # App startup and service configuration