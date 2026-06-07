# 📋 Software Requirements Specification (SRS)
## Psychology Appointment System

---

## 1. Introduction

### 1.1 Purpose
This system is designed to manage psychological appointments between counselors and clients.

---

### 1.2 Scope
The system allows:
- Managing counselors
- Registering clients
- Booking appointments
- Viewing weekly schedules

---

### 1.3 Users
- Administrators
- Counselors
- Clients

---

## 2. Functional Requirements

### FR1 - Counselor Management
- Add counselor
- Edit counselor
- Delete counselor

---

### FR2 - Client Management
- Register client
- Store client data

---

### FR3 - Appointment System
- Select counselor
- Select date
- Show available time slots
- Book appointment
- Prevent duplicate booking

---

### FR4 - Weekly Calendar
- Show weekly schedule
- Show booked slots
- Show client names

---

## 3. Non-Functional Requirements

- Fast response time (< 2 seconds)
- Simple RTL UI
- Reliable booking system
- Clean MVC architecture

---

## 4. Constraints

- ASP.NET Core MVC
- SQL Server
- Persian RTL support

---

## 5. Future Improvements

- Authentication system
- SMS/Email notifications
- Mobile UI improvement
- API version