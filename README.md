📦 Rice Production and Distribution Management System
A comprehensive C# Windows Forms application designed to streamline rice production, sales, and government-private buyer coordination. This system helps farmers register their fields, manage stock, submit damage reports, and connect with buyers while ensuring role-based access and data security.

🚀 Features
👤 User Roles & Management (Admin, Farmer, Government, Private Buyer)

🧑‍🌾 Field Registration & Crop Monitoring

📊 Stock Management with Real-time Updates

🛒 Sales Module with Buyer Type Tracking

📦 Paddy Requests (Govt & Private Buyers)

⚠️ Damage Reporting Workflow

💰 Price Monitoring & Deviation Calculation

📌 Authentication Logs & Security

📄 Exportable Reports (PDF/Excel)

🛠️ Tech Stack
Frontend/UI: C# Windows Forms

Backend: MSSQL Server

ORM (Optional): Entity Framework

Reporting: Crystal Reports / iTextSharp / RDLC

Security: Password Hashing, Role-Based Access Control

🗃️ Database Tables
Roles
Admin (1), Farmer (2), Government (3), Private Buyer (4)

Users
Role-based users with authentication and status tracking

AuthLogs
Logs every login attempt with timestamps and status

Fields
Stores farmer field data (location, size, soil condition, etc.)

Sales
Tracks rice sales, price, quantity, buyer info, and payment status

RequestPaddy
Handles paddy purchase requests from buyers to farmers

Stock
Monitors rice stock quantities per farmer by crop type

DamageReports
Farmers can submit reports on field damage

PriceMonitoring
Tracks market price vs. government price for each rice type

🔐 Default Roles & Access
Role	Access
Admin	Full Access
Farmer	Field, Stock, Sales, Reports
Government	Buy Requests, Price Monitor
Private Buyer	Paddy Requests, Sales

👨‍🎓 Academic Use
This project was developed as part of an academic requirement. You are free to use, learn, and extend it with credit.
