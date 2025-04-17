# Voting System

<p align="center">
  <img src="https://github.com/hdbr00/SVotacion/raw/main/Assets/vote.PNG" />
</p>

## 1. Introduction
<p>This system was created to enable users to exercise their right to vote, facilitating access for groups with disabilities and/or health risks to exercise this right. Additionally, any other person facing inconveniences on election day can use the system.
</p>

## Table of Contents
* [1. Introduction](#1-introduction)
* [2. Objectives](#2-objectives)
* [3. Project Description](#3-project-description)
* [4. Success Criteria](#4-success-criteria)
* [5. Technical Stack](#5-technical-stack)
* [6. Database Diagram](#6-database-diagram)
* [7. Sequence Diagram](#7-sequence-diagram)
* [8. Project Structure](#8-project-structure)
  * [Layered Architecture](#layered-architecture)
  * [Identity](#identity)
  * [Email Sending](#email-sending)
  * [Web APIs](#web-apis)
  * [Voting List](#voting-list)
* [9. Modules](#9-modules)
* [10. Author](#10-author)

## 2. Objectives

- [ ] Enable a system that facilitates voting.
- [ ] Allow voting from outside Costa Rica.

## 3. Project Description
<p>
  The system allows managing candidates and generates instant vote counting for each of them. Voter authentication is used to ensure unique voting.
</p>

## 4. Success Criteria

- [x] Automatic vote counting.
- [x] Single validation per person.
- [x] Candidate creation and management.
- [x] User creation.
- [x] Session termination after voting.
- [x] Party/team management.

## 5. 🛠️ Technical Stack

### Core Development
- **.NET 5.0** - Core framework
- **C#** - Primary programming language
- **ASP.NET Core** - Web framework
- **Entity Framework Core 5.0.5** - ORM and database management
- **SQL Server** - Database management system

### Architecture & Design Patterns
- **Repository Pattern** - Data access abstraction
- **Unit of Work Pattern** - Transaction management
- **MVC Architecture** - Model-View-Controller pattern
- **Dependency Injection** - Dependency management
- **Layered Architecture** - Basic separation of concerns

### Frontend Development
- **Razor Pages** - Server-side web pages
- **Bootstrap 4.3.1** - Frontend framework
- **jQuery & jQuery UI** - Interactivity and UI
- **DataTables** - Table management
- **HTML5/CSS3** - Structure and styling

### Security & Authentication
- **ASP.NET Core Identity** - Authentication and authorization
- **Facebook Authentication** - Social login
- **Data Annotations** - Data validation
- **Secure Configuration** - Secret management

## 6. Database Diagram
<p> Below is the database diagram that supports the system's functionality:</p>

![Database Diagram](https://github.com/hdbr00/SVotacion/raw/main/Assets/DiagramaBD.png)

## 7. Sequence Diagram
<p>The sequence diagram illustrates the flow of interactions during the voting process:</p>

![Sequence Diagram](https://github.com/hdbr00/SVotacion/raw/main/Assets/Diagrama-de-secuencia.png)

## 8. Project Structure

### Layered Architecture
<p> The system is designed using a layered architecture to improve code organization and maintenance:</p>

![Layered Architecture](https://github.com/hdbr00/VotingSystem/assets/119827170/fa8318a0-d81b-49bb-8c29-55e9660b37db)

### Identity
<p>The Identity module is used for user management and authentication</p>

![Identity](https://github.com/hdbr00/VotingSystem/assets/119827170/97e67733-d0e1-4c1f-81ba-6aa710662091)

### Email Sending
<p> Includes functionality for sending emails, used to notify users about their voting:</p>

![Email Sending](https://github.com/hdbr00/VotingSystem/assets/119827170/0eae8b11-6eb6-4bad-8b09-dc83aba9181a)

### Web APIs
<p> The system exposes several Web APIs to allow integration with other systems:</p>

![Web APIs](https://github.com/hdbr00/VotingSystem/assets/119827170/c9893df0-f8e2-43a4-bebf-edfce0eaf163)

### Voting List
<p>Users can view a list of available votes:</p>

![Voting List](https://github.com/hdbr00/VotingSystem/assets/119827170/548f0038-2ab2-4b59-b46e-7307bd6b680c)

## 9. Modules

<p>The system is divided into modules that handle different functionalities, facilitating extension and maintenance:</p>

<table>
  <tr>
    <td align="center" width="350">
      <strong>Modules</strong><br/>
      <img src="https://github.com/hdbr00/VotingSystem/assets/119827170/b429c306-a267-43fe-be72-f812ce0fd64e" width="300"/><br/>
    </td>
    <td align="center" width="350">
      <strong>Candidate Management</strong><br/>
      <img src="https://github.com/hdbr00/VotingSystem/assets/119827170/c2a4df5a-1992-47ad-bde4-816125fff9b7" width="300"/><br/>
    </td>
    <td align="center" width="350">
      <strong>Authentication</strong><br/>
      <img src="https://github.com/hdbr00/VotingSystem/assets/119827170/60dac356-9906-4922-879c-007457f050db" width="300"/><br/>
    </td>
  </tr>
</table>

## 10. Developed by:
Henry Ledezma - [@hdbr00](https://github.com/hdbr00) Ⓡ

