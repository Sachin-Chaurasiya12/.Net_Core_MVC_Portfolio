# 💼 Personal Portfolio & Project Management System

## 📌 Overview

This project is a **personal portfolio web application** built to showcase projects, manage content, and provide an admin-controlled interface for updating project details.

It includes a secure backend where only the **admin** can add, edit, or delete project data, while users can view projects publicly.

---

## 🚀 Features

### 👤 User Features

* View all projects
* Responsive UI (mobile + desktop)
* Clean and modern design
* Project details with tech stack tags

### 🔐 Admin Features

* Add new projects
* Edit project details
* Delete projects
* Upload and manage project images
* Role-based access (Admin only)

---

## 🛠️ Tech Stack

### Frontend

* HTML5
* CSS3 (Custom responsive design)
* JavaScript

### Backend

* ASP.NET Core MVC

### Database

* SQL Server

### Other

* Entity Framework Core
* Razor Views

---

## 📂 Project Structure

```
/Controllers
/Models
/Views
/wwwroot
    /css
    /js
    /images
```

---

## ⚙️ Installation & Setup

1. Clone the repository

```
git clone https://github.com/yourusername/your-repo-name.git
```

2. Open in Visual Studio

3. Configure database in `appsettings.json`

4. Run migrations

```
Update-Database
```

5. Run the project

```
Ctrl + F5
```

---

## 🔑 Authentication & Authorization

* Role-based access control implemented
* Only **Admin** can:

  * Add/Edit/Delete projects
* Users have **read-only access**

---

## 🖼️ Image Handling

* Images are stored in:

```
wwwroot/images/
```

* File upload handled via `IFormFile`
* Unique naming using GUID

---

## 📊 Sample Projects Included

### 🏦 Banking Management System

* Java-based system
* JNI integration with C++
* Secure transaction handling

### 🛒 E-commerce Backend

* REST API using Spring Boot
* JWT Authentication
* MySQL integration

---

## 🎯 Future Improvements

* Add user authentication (login/register)
* Implement AJAX (no page reload)
* Add project filtering & search
* Deploy to cloud (Azure / AWS)

---

## 📬 Contact

* Email: [your-email@example.com](mailto:your-email@example.com)
* GitHub: https://github.com/yourusername
* LinkedIn: https://linkedin.com/in/yourusername

---

## 📄 License

This project is for learning and portfolio purposes.
