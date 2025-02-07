# Supermarket Management

### Admin Mode
https://github.com/user-attachments/assets/1aeaae43-0d62-41c7-a756-10471ac8946a

### Cashier Mode
![SupermarketCashier](https://github.com/user-attachments/assets/5fd4e400-75d2-489a-99ea-e924252346c6)

## Description

The **Supermarket Management Application** is a desktop application built using **C#**, **WPF (.NET Framework)**, **Entity Framework**, and **SQL Server**. The application is designed to manage various aspects of a supermarket's operations, including product inventory, suppliers, categories, and user management. It follows the **MVVM (Model-View-ViewModel)** design pattern, ensuring a clear separation between the application's logic and its UI.

Key features of the application include:
- Management of products, including name, barcode, expiration date, category, and supplier information.
- Handling product categories (e.g., food, clothing, stationery).
- Management of stock quantities and purchase prices.
- User management with two roles: **Administrator** and **Cashier**.
- Administrator functionalities like adding, editing, and deleting users, products, suppliers, categories, and stocks.
- Cashier functionalities for searching products by different criteria (name, barcode, etc.) and issuing sales receipts.
- Sales receipts include detailed product information, quantities, subtotals, and total amounts.

The application is designed to ensure data integrity, preventing deletion of records, and implementing logical deletion by marking data as inactive. Additionally, price calculations are automated, and validation is performed on input fields.

## Technologies Used

- C#.
- WPF (.NET Framework).
- Entity Framework.
- SQL Server.
- SSMS (SQL Server Management Studio).

## Installation and Usage

**1. Clone the repository**  
git clone https://github.com/AndreiCIlies/Supermarket_Management.git

**2. Open the project in Visual Studio**  
Navigate to the folder where you cloned the repository and open the .sln file.

**3. Set up the database**  
* Open SQL Server Management Studio (SSMS) and connect to your SQL Server instance.
* Import the supermarket.sql file located in the Database folder to set up the database schema:
  - Open the supermarket.sql file from the Database folder.
  - Execute the SQL script in SSMS to create the necessary tables and relationships.

**4. Configure database connection**  
Update the connection string in the App.config file with your SQL Server details.

**5. Build the project**  
Click Build in the top menu, then select Build Solution (or press Ctrl+Shift+B).

**6. Run the application**  
Click the green Start button (or press F5) to run the application.
