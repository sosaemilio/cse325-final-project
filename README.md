# Fragance Tracker Project
Project is made for perfume and fragance enthusiasts to keep track of their existing vault, longetivity and occasion.

* Target Audience: Fragrance enthusiasts and collectors.
* CRUD Functionality: Users can add new perfumes to their digital shelf, edit wear-time notes (longevity, projection), delete bottles they've emptied, and view a dashboard of their collection.

## Project Members:
* Victor Jared Cruz Onato
* Emilio Ernesto Sosa Carrillo

## App Structure
```
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
```
## Features 
```
• User authentication (Register, Login, Logout)  
• Browse a curated fragrance collection  
• Filter fragrances by brand, notes, and concentration  
• Add fragrances to a personal vault  
• Edit fragrance details (notes, rating, season, occasion)  
• Delete fragrances from vault  
• Clean and consistent image display  
• User-specific data storage
```
## Technologies 
```
• Blazor Server  
• ASP.NET Core Identity  
• Entity Framework Core  
• SQLite (development database)  
• HTML, CSS 
```
## Installation
```
1. Clone Repository: https://github.com/sosaemilio/cse325-final-project 
2. Open the project in Visual Studio Code
3. Apply database migration: dotnet ef database update
4. Run the application: dotnet run
5. Open the browser and navigate to: http://localhost:52
```
## How to use the System
### 1. Register 
 - Enter first name, last name, email, and password
 - Submit to create an account 
### 2. Log-in 
 - Enter your registered email and password
### 3. Browse Fragrances
 - Click "Browse" in Navbar
 - View available fragrances
 - Use filters to narrow results
### 4. Add to Vault
 - Click one perfume to open perfume details
 - Add it to your personal collections by clicking the button: Add to Vault
### 5. Manage Your Vault
 - Click Profile, then to Vault. 
 - Edit fragrance details
 - Notes
 - Rating
 - Season 
 - Occasion
 - Delete Items if needed

## Troubleshooting
### Cannot login 
 - Ensure correct email and password
 - Make sure the account is registered
### Registration fails
 - Email may already be in use
 - Make sure the password follows password requirement given through the message
### Data not saving
 - Ensure the server is running
 - Refresh the page
### Images not displaying correctly
 - Ensure image links are valid
 - Check static files are properly configured.

### Project Highlights
This project demonstrates: 
• Full-stack web application development  
• Secure authentication using ASP.NET Identity  
• Dynamic UI with Blazor Server  
• Database integration using Entity Framework  
• User-centered design and feedback handling 

##  Future Improvements

• Add search functionality  
• Improve UI animations and styling  
• Implement persistent cloud database  
• Add user profile customization 
