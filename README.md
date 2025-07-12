<!DOCTYPE html>
<html lang="en">


  <h1>📦 Rice Production and Distribution Management System</h1>
  <p>A comprehensive C# Windows Forms application designed to streamline rice production, sales, and government-private buyer coordination. This system helps farmers register their fields, manage stock, submit damage reports, and connect with buyers while ensuring role-based access and data security.</p>

  <h2>🚀 Features</h2>
  <ul>
    <li>👤 User Roles & Management (Admin, Farmer, Government, Private Buyer)</li>
    <li>🧑‍🌾 Field Registration & Crop Monitoring</li>
    <li>📊 Stock Management with Real-time Updates</li>
    <li>🛒 Sales Module with Buyer Type Tracking</li>
    <li>📦 Paddy Requests (Govt & Private Buyers)</li>
    <li>⚠️ Damage Reporting Workflow</li>
    <li>💰 Price Monitoring & Deviation Calculation</li>
    <li>📌 Authentication Logs & Security</li>
    <li>📄 Exportable Reports (PDF/Excel)</li>
  </ul>

  <h2>🛠️ Tech Stack</h2>
  <ul>
    <li><strong>Frontend/UI:</strong> C# Windows Forms</li>
    <li><strong>Backend:</strong> MSSQL Server</li>
    <li><strong>ORM (Optional):</strong> Entity Framework</li>
    <li><strong>Reporting:</strong> Crystal Reports / iTextSharp / RDLC</li>
    <li><strong>Security:</strong> Password Hashing, Role-Based Access Control</li>
  </ul>

  <h2>🗃️ Database Tables</h2>
  <ul>
    <li><strong>Roles:</strong> Admin (1), Farmer (2), Government (3), Private Buyer (4)</li>
    <li><strong>Users:</strong> Role-based users with authentication and status tracking</li>
    <li><strong>AuthLogs:</strong> Logs every login attempt with timestamps and status</li>
    <li><strong>Fields:</strong> Stores farmer field data (location, size, soil condition, etc.)</li>
    <li><strong>Sales:</strong> Tracks rice sales, price, quantity, buyer info, and payment status</li>
    <li><strong>RequestPaddy:</strong> Handles paddy purchase requests from buyers to farmers</li>
    <li><strong>Stock:</strong> Monitors rice stock quantities per farmer by crop type</li>
    <li><strong>DamageReports:</strong> Farmers can submit reports on field damage</li>
    <li><strong>PriceMonitoring:</strong> Tracks market price vs. government price for each rice type</li>
  </ul>

  <h2>🔐 Default Roles & Access</h2>
  <table>
    <tr>
      <th>Role</th>
      <th>Access</th>
    </tr>
    <tr>
      <td>Admin</td>
      <td>Full Access</td>
    </tr>
    <tr>
      <td>Farmer</td>
      <td>Field, Stock, Sales, Reports</td>
    </tr>
    <tr>
      <td>Government</td>
      <td>Buy Requests, Price Monitor</td>
    </tr>
    <tr>
      <td>Private Buyer</td>
      <td>Paddy Requests, Sales</td>
    </tr>
  </table>

  <h2>👨‍🎓 Academic Use</h2>
  <p>This project was developed as part of an academic requirement. You are free to use, learn, and extend it with credit.</p>

</body>
</html>

