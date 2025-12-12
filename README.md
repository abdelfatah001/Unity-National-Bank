## 📘 Overview
**Unity National Bank System** is a C# application built using a **three-tier architecture**, separating the project into the **Presentation Layer**, **Business Logic Layer (BBL)**, and **Data Access Layer (DAL)**.  
The system is designed to manage core banking operations and ensure efficient access to data through structured entity management and in-memory caching.

The project follows **SOLID principles** to maintain a modular, scalable, and maintainable codebase.  
Each component — whether an entity, manager, or cache — has a single, clear responsibility and communicates only through well-defined interfaces and abstract classes.

Recently, major updates were applied to the **Business Logic Layer (BBL)** to optimize data access and structure.  
This involved replacing linear data collections with `Dictionary` and `SortedSet` structures to significantly improve lookup speed and overall efficiency.  
These changes helped achieve better separation between the logic and data access layers while maintaining high performance for frequently used data.

---
===================+
## 🧩 Architecture |
===================+


### **0. Model Layer (Entities)**
=================================

- Defines all **domain objects** that represent real-world banking components such as `clsAccount`, `clsClient`, `clsCurrency`, etc.  
- Each model follows **IHasId** and, when necessary, **IUpdateObject<T>** interfaces to ensure consistency in identity and update behavior.  
- Responsibilities:
  - Represent structured data and state used across the system.
  - Provide **update methods** (like `UpdateIAccount account)`) to synchronize object state when modifications occur.
- Designed with **strong typing** and clear contracts, making them reusable and easy to maintain.

### **1. Presentation Layer (UI)**
==================================

- Built using **WinForms** to handle all user interactions and display information.
- Contains *Entity Classes* that directly access read-only data from the **Cache Layer** for quick loading without repeated database calls.
- Communicates with the **Business Logic Layer (BBL)** through *Entity Classes* to access read-only data from the **Cache Layer** 
   , and execute business rules
   , perform validation through PL_WinForm.Validation namespace
   , and handle user requests such as loading lists or processing updates through UpdateService and proccess adding records through AddService.

---

### **2. Business Logic Layer (BBL)**
=====================================

-Link the DAL with PL via classes of repo and cache and manager :
   the repo classes access the data of database via DAL,
   the cache classes control the data in the datastructure according database,
   the Manager classes link both cache and layer together to reflect the data stored in the database on the datastructure.

- Contain the logic operations like transaction

### **3. Data Access Layer (DAL)**
==================================

- Responsible for all **communication with the database**.  
- Implemented using **ADO.NET** for fast, efficient, and direct data access without relying on external ORMs.  
- Handles:
  - Executing SQL queries and stored procedures.
  - Opening and managing database connections.
  - Mapping query results into business entities or model objects.
- Designed to return simple and reusable data structures (lists) to the **BBL**.  
- The DAL classes are kept **independent of UI or caching logic**, following the separation of concerns principle.  

---

### **4. Model Layer (Entities)**
=================================
- Defines all **domain objects** that represent real-world banking components such as `clsAccount`, `clsClient`, `clsCurrency`, etc.  
- Each model follows **IHasId** and, when necessary, **IUpdateObject<T>** interfaces to ensure consistency in identity and update behavior.  
- Responsibilities:
  - Represent structured data and state used across the system.
  - Provide **update methods** (like `UpdateIAccount account)`) to synchronize object state when modifications occur.
- Designed with **strong typing** and clear contracts, making them reusable and easy to maintain.

---

================+
## 🧩 Data Flow |
================+

1. **User Action (UI):** The user performs an operation (e.g., load account, update client).  
2. **UI  → PL : ** The request is handled by an Entity in the Presentation Layer, which performs initial validation and processing.
3. **PL  → BBL: ** The Entity pass it  to a Manager in the BBL, which validates and processes it.  
4. **BBL → DAL: ** If data needs to be retrieved or saved, the Manager calls the DAL.  
5. **DAL → BBL: ** The DAL executes queries, retrieves data via ADO.NET, and returns it to the Manager.  
6. **BBL → Cache: ** The Manager updates or reads from the Cache for faster future access.  
7. **BBL → UI : ** A processed, read-only copy of data is returned to the Presentation Layer for display or further user interaction.

========================+
## 🧭 Namespace Summary |
========================+

### 🖥 **1. Presentation Layer (PL_WinForm)**
---------------------------------------------
| Namespace | Description |



### ⚙️ **2. Business Logic Layer (BBL)**
----------------------------------------
| Namespace | Description |

1. BLL_Templete            ====> Contain interfaces of Manager,Cache and repo and operations must done on the datastructure its linking with DAL and PL layers and interfaces of the transaction proccesses.
2. BLL_Manager             ====> Contain the implementation of Manager, Cache and Repo classes of each entity.
3. BLL_Manager.Transaction ====> Contain the implementation of transaction classes ( depositing, withdrawing and transfering).


### 🧩 **3. Data Access Layer (DAL)**
-------------------------------------
| Namespace | Description |

1. DAL.Templete      ===> Contain interfaces of operation we must do and interfaces of the entities must implement this operations on database.
2. DAL.Repository    ===> Contain the implementation of these entities and the operations them do in the database.


### 🧱 **4. Models (Entities / Domain Layer)**
----------------------------------------------
| Namespace              | Description |

1. Model_Templete    ===> Contain the interfaces of all models.
2. Model             ===> Contain all models classes implementation.

==================+
🧠 Developer Note |
==================+

    The main purpose of this project was to apply and practice everything I have learned and continue to learn in software development.
I regularly update and refine it as my knowledge grows. Not all the features I intended to implement are fully completed; in some cases, 
I focused on building the infrastructure and architecture to prepare for future implementations that may or may not be applied later. 
The primary goal of this project was not to finish a complete banking system and making it be full and has all featurs, but to practice real-world application of programming concepts,
with a particular focus on the backend rather than the frontend or UI/UX. The user interface was included mainly to make the project functional and testable, not as a design priority.


By : Mohamed Ahmed Abdelfatah 
From : Alex in Egypt
Date :Dec in 2025.
