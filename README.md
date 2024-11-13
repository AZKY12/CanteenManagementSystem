# Canteen Management System

The **Canteen Management System** is a comprehensive desktop application developed in C# to streamline canteen operations. The application assists canteen staff in managing customer orders, tracking food inventory, and processing payments. It provides an intuitive, user-friendly interface for tasks like viewing available food items, processing orders, handling payments, and managing customer data.

## Table of Contents
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Database Structure](#database-structure)
  - [Food Table](#food-table)
  - [Customer Table](#customer-table)
  - [Order Table](#order-table)
  - [Payment Table](#payment-table)
- [Application Structure](#application-structure)
- [Setup Instructions](#setup-instructions)
- [Code Examples](#code-examples)
- [Future Enhancements](#future-enhancements)
- [License](#license)

## Features

### 1. Food Inventory Management
   - Add, update, delete, and view food items.
   - Track food item details including `FoodId`, `FoodName`, `Price`, `Quantity`, and `Status`.
   - Display food items and their availability status.

### 2. Customer Management
   - Create and update customer profiles with information such as `CustomerId`, `CustomerName`, `ContactNumber`, `Email`, and `Address`.
   - Search and edit customer records for personalized order tracking.

### 3. Order Processing
   - Manage orders placed by customers.
   - Store details for each order, including associated customer and ordered items.
   - Track order status and record `OrderDate`.

### 4. Payment Handling
   - Process payments for each order, with options for various payment methods (e.g., cash, credit card).
   - Track payment details including `PaymentMethod` and `Amount`.
   - Generate payment records for each completed order.

### 5. Dashboard Analytics
   - Display total counts of foods, customers, and orders on the main dashboard.
   - Provide a summary for staff to quickly understand the canteen's performance.

## Technology Stack
- **Language**: C# (Windows Forms)
- **Database**: SQL Server (Integrated with ADO.NET)
- **IDE**: Visual Studio
- **UI Framework**: Windows Forms

## Database Structure

### Food Table (`foodTable`)
Stores information on available food items in the canteen.
```sql
CREATE TABLE [dbo].[foodTable] (
    [FoodId] INT PRIMARY KEY,
    [FoodName] NVARCHAR(50),
    [Price] DECIMAL(10, 2),
    [Quantity] INT,
    [Status] NVARCHAR(20)
);
```
Sample Data:
```sql
INSERT INTO [dbo].[foodTable] VALUES (1, N'Kottu', 300, 1, 'ready');
INSERT INTO [dbo].[foodTable] VALUES (2, N'Parippu Wade', 40, 5, 'ready');
-- Additional records...
```

### Customer Table (`customerTable`)
Stores customer details for the canteen.
```sql
CREATE TABLE [dbo].[customerTable] (
    [CustomerId] INT PRIMARY KEY,
    [CustomerName] NVARCHAR(50),
    [ContactNumber] NVARCHAR(15),
    [Email] NVARCHAR(50),
    [Address] NVARCHAR(100)
);
```
Sample Data:
```sql
INSERT INTO [dbo].[customerTable] VALUES (1, N'Anura Silva', N'0711234567', N'anura.silva@example.com', N'123 Galle Road, Colombo');
-- Additional records...
```

### Order Table (`orderTable`)
Records each order placed by customers, including the ordered items and order date.
```sql
CREATE TABLE [dbo].[orderTable] (
    [OrderId] INT PRIMARY KEY,
    [CustomerName] NVARCHAR(50),
    [Food1] NVARCHAR(50),
    [Food2] NVARCHAR(50),
    [Food3] NVARCHAR(50),
    [OrderDate] DATETIME
);
```

### Payment Table (`paymentTable`)
Tracks payment transactions related to orders.
```sql
CREATE TABLE [dbo].[paymentTable] (
    [PaymentId] INT PRIMARY KEY,
    [CustomerName] NVARCHAR(50),
    [Food1] NVARCHAR(50),
    [Food2] NVARCHAR(50),
    [Food3] NVARCHAR(50),
    [PaymentMethod] NVARCHAR(50),
    [Amount] DECIMAL(10, 2)
);
```

## Application Structure

### 1. Main Form (Dashboard)
Displays summary metrics such as total food items, customer count, and order count. Provides navigation buttons to the other sections (e.g., Food Management, Customer Management, Order Management, Payment Processing).

### 2. Forms for Functional Modules
- **Food Management**: Enables staff to add, update, delete, and view food items.
- **Customer Management**: Allows staff to add, update, and view customer profiles.
- **Order Management**: Records new orders, associating them with specific customers and tracking order status.
- **Payment Processing**: Handles payment entries for orders, records payment method, and confirms successful transactions.

## Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/AZKY12/CanteenManagementSystem.git
   cd CanteenManagementSystem
   ```

2. **Database Setup**:
   - Open SQL Server Management Studio (SSMS).
   - Create a new database named `CMS_DB`.
   - Run the provided SQL scripts in SSMS to create tables (`foodTable`, `customerTable`, `orderTable`, `paymentTable`).
   - Insert sample data if necessary.

3. **Modify Connection String**:
   - Update the connection string in `App.config` or directly within the code to match your SQL Server instance:
     ```csharp
     string connectionString = @"Data Source=DESKTOP-HEEKBHE\SQLEXPRESS;Initial Catalog=CMS_DB;Integrated Security=True";
     ```

4. **Build and Run the Application**:
   - Open the project in Visual Studio.
   - Build the project to ensure all dependencies are resolved.
   - Run the application (F5).

## Code Examples

### Display Total Counts on Dashboard

```csharp
private void DisplayCounts()
{
    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();

        string queryFood = "SELECT COUNT(*) FROM foodTable";
        labelFoodCount.Text = "Food Count: " + (int)new SqlCommand(queryFood, con).ExecuteScalar();

        string queryCustomer = "SELECT COUNT(*) FROM customerTable";
        labelCustomerCount.Text = "Customer Count: " + (int)new SqlCommand(queryCustomer, con).ExecuteScalar();

        string queryOrder = "SELECT COUNT(*) FROM orderTable";
        labelOrderCount.Text = "Order Count: " + (int)new SqlCommand(queryOrder, con).ExecuteScalar();
    }
}
```

### Insert Customer Record

```csharp
private void AddCustomer()
{
    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CMS_DB;Integrated Security=True";
    using (SqlConnection con = new SqlConnection(connectionString))
    {
        con.Open();
        string query = "INSERT INTO customerTable (CustomerId, CustomerName, ContactNumber, Email, Address) VALUES (@CustomerId, @CustomerName, @ContactNumber, @Email, @Address)";
        
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@CustomerId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@CustomerName", textBox2.Text);
            cmd.Parameters.AddWithValue("@ContactNumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@Email", textBox4.Text);
            cmd.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd.ExecuteNonQuery();
        }
    }

    MessageBox.Show("Customer record saved successfully");
}
```

## Future Enhancements
- **User Authentication**: Add user roles (e.g., admin, staff) to restrict access based on permissions.
- **Reporting**: Implement daily sales and inventory reports for better insights.
- **Mobile/Web Extension**: Develop a web or mobile interface to access the application remotely.
- **Enhanced UI**: Improve user interface with modern components and styling.

## License
This project is open-source and available under the [MIT License](LICENSE).

---

